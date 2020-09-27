using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObject : MonoBehaviour
{
    public AudioSource m_audioSource;
    public GameController m_gameController;
    private void FixedUpdate()
        
    {
       
        if(m_audioSource.isPlaying == false)
        {
            m_gameController.Restart();
            Destroy(this.gameObject);
        }

        
        
    }
    void Awake()
    {
        m_audioSource.Play();
        m_gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>(); 
    }
}
