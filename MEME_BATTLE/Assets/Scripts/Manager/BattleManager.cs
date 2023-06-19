using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private Player player01;
    [SerializeField] 
    private Player player02;

    [SerializeField]
    private Transform p1SpawnPos;
    [SerializeField]
    private Transform p2SpawnPos;

    public void Respawn(bool isPlayer1)
    {
        if (isPlayer1)
        {
            player01.transform.position = p1SpawnPos.position;
            player01.SetHitCount(0);
        }
        else
        {
            player02.transform.position = p2SpawnPos.position;
            player02.SetHitCount(0);
        }
    }
}
