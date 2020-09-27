using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject m_player;

    void FixedUpdate()
    {
        GetComponent<NavMeshAgent>().destination = m_player.transform.position;
    }


}