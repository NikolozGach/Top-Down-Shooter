using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject m_prefab;


    public void Hit()
    {
        Instantiate(m_prefab);
        Destroy(this.gameObject);
    }
}
