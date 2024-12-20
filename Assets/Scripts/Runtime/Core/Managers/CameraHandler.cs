using System;
using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vCam;
    [SerializeField] CinemachineTargetGroup targetGroup;
    [Range(1, 11), SerializeField] float weight = 4;
    [Range(1, 11), SerializeField] float offset = 4;

    private void Awake()
    {
        CardEvents.OnCardsPrepared += Prepare_Callback;
    }

    void Start()
    {
        StartCoroutine(WaitAndCloseTargetGroup_Cor());
    }

    private void OnDestroy()
    {
        CardEvents.OnCardsPrepared -= Prepare_Callback;
    }

    IEnumerator WaitAndCloseTargetGroup_Cor()
    {
        yield return null;

        targetGroup.enabled = false;
    }
    
    void Prepare_Callback(Card[,] cards)
    {
        var count = cards.GetLength(0) * cards.GetLength(1);
        targetGroup.m_Targets = new CinemachineTargetGroup.Target[count];

        var minX = float.MaxValue;
        var maxX = float.MinValue;
        var minY = float.MaxValue;
        var maxY = float.MinValue;

        foreach (var card in cards)
        {
            var cardPos = card.transform.position; 
            if (cardPos.x < minX) minX = cardPos.x; 
            if (cardPos.x > maxX) maxX = cardPos.x;
            if (cardPos.y < minY) minY = cardPos.y;
            if (cardPos.y > maxY) maxY = cardPos.y;
        }

        var distanceX = maxX - minX; 
        var distanceY = maxY - minY;
        var cameraSize = Mathf.Max(distanceX / 2, distanceY / 2); 

        vCam.m_Lens.OrthographicSize = cameraSize + (weight * offset);

        int counter = 0; 

        for (int i = 0; i < cards.GetLength(0); i++)
        {
            for (int j = 0; j < cards.GetLength(1); j++)
            {
                targetGroup.m_Targets[counter].target = cards[i, j].transform;
                targetGroup.m_Targets[counter].weight = weight;
                counter++;
            }
        }
    }

   
}
