using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardManager : MonoBehaviour
{
    [SerializeField] CardLib cardLib;
    [SerializeField] CardFactory cardFactory;
    Card[,] _cards;


    private void Awake()
    {
        LevelEvents.OnLevelDataSet += PrepareCards;
    }

    private void OnDestroy()
    {
        LevelEvents.OnLevelDataSet -= PrepareCards;
    }

    void PrepareCards(LevelData levelData)
    {
        var cardData = cardLib.CardDataList.ToList();
        var data = new List<CardData>();
        for (int i = 0; i < cardData.Count; i++)
        {
            var rndData = cardData.RemoveRandom();
            data.Add(rndData);
            data.Add(rndData);
        }
        
        _cards = new Card[levelData.amount.x, levelData.amount.y];

        if (data.Count < _cards.Length) 
        {
            while (_cards.Length != data.Count)
            {
                var rndData = cardLib.CardDataList.GetRandom();
                data.Add(rndData);
                data.Add(rndData);
            }
        }
        else if (data.Count > _cards.Length)
        {
            while (_cards.Length != data.Count)
            {
                data.RemoveAt(data.Count - 1);
                data.RemoveAt(data.Count - 1);
            }
        }

        data.Shuffle();

        var index = 0;
        for (int x = 0; x < levelData.amount.x; x++)
        {
            for (int y = 0; y < levelData.amount.y; y++)
            {
                _cards[x, y] = cardFactory.CreateCard(GetWorldPosition(x, y, levelData.cellSize));
                _cards[x, y].Prepare(data[index]);
                index++;
            }
        }
        
        CardEvents.OnCardsPrepared?.Invoke(_cards);
    }



    Vector3 GetWorldPosition(int x, int y, float cellSize)
    {
        return new Vector3 (x, y, 0) * cellSize;
    }
}
