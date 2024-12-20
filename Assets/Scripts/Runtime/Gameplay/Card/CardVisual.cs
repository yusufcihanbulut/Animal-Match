using UnityEngine;

public class CardVisual : MonoBehaviour
{
    [SerializeField] SpriteRenderer iconSpriteRenderer;

    public void SetIcon(Sprite iconSprite)
    {
        iconSpriteRenderer.sprite = iconSprite;
    }
}
