using UnityEngine;

public class CardFactory : MonoBehaviour
{
    [SerializeField] Card cardPrefab;
    [SerializeField] Transform cardParent;

    public Card CreateCard(Vector3 pos)
    {
        var card = Instantiate(cardPrefab, cardParent);
        card.transform.position = pos;
        return card;
    }
}
