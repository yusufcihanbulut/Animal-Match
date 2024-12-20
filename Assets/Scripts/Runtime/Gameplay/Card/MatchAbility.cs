using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MatchAbility : MonoBehaviour
{
    Camera _camera;
    List<Card> _selectedCards = new();

    private int totalPairs;        // Toplam çift sayýsý
    private int matchedPairs = 0;  // Eþleþmiþ çift sayýsý
    private void Awake()
    {
        _camera = Camera.main;
    }

    void OnEnable()
    {
        TouchEvents.OnCardTapped += CardTapped_Callback;
        TouchEvents.OnEmptyTapped += EmptyTapped_Callback;
    }

    void OnDisable()
    {
        TouchEvents.OnCardTapped -= CardTapped_Callback;
        TouchEvents.OnEmptyTapped -= EmptyTapped_Callback;
    }

    void TryMatch()
    {
        if (_selectedCards.Count != 2)
        {
            return;
        }

        if (IsSelectedCardsSame())
        {
            CorrectMatch(_selectedCards);
        }
        else
        {
            foreach (var card in _selectedCards)
            {
                card.DelectWrong();
            }
        }

        _selectedCards.Clear();
    }

    void CorrectMatch(List<Card> selectedCards)
    {
        foreach(var card in selectedCards)
        {
            var targetPos = _camera.ViewportToWorldPoint(
                new Vector3(0.5f, 0.5f, _camera.nearClipPlane));

            card.Move(targetPos);
        }
        matchedPairs++;

       
    }
   

    bool IsSelectedCardsSame()
    {
        return _selectedCards[0].ID == _selectedCards[1].ID;
    }

    private void CardTapped_Callback(Card card)
    {
        if (IsCardAlreadySelected(card) == false)
        {
            card.Select();
            _selectedCards.Add(card);
            TryMatch(); 
        }
    }
    
    bool IsCardAlreadySelected(Card card)
    {
        return _selectedCards.Contains(card);
    }

    private void EmptyTapped_Callback()
    {
        foreach (var card in _selectedCards)
        {
            card.Deselect();
        }
        
        _selectedCards.Clear();
    }

    
}
