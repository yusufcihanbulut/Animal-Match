using System;
using System.Collections;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] string collisionTag;
    bool _canTouch;

    void Start()
    {
        _canTouch = false;
        StartCoroutine(WaitForTouch_Cor());
    }
    
    IEnumerator WaitForTouch_Cor()
    {
        yield return new WaitForSeconds(1.5f);

        _canTouch = true;
    }

    void Update()
    {
        if (_canTouch)
        {
            GetTouch(Input.mousePosition);
        }
    }
    
    private void GetTouch(Vector3 pos)
    {
        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.OverlapPoint(cam.ScreenToWorldPoint(pos));
            if (CanTouch(hit))
            {
                var selectedCard = hit.gameObject.GetComponent<Card>();
                TouchEvents.OnCardTapped?.Invoke(selectedCard);
            }
            else
            {
                TouchEvents.OnEmptyTapped?.Invoke();
            }
        }
    }

    private bool CanTouch(Collider2D hit)
    {
        return hit != null && hit.CompareTag(collisionTag);
    }

   
}
