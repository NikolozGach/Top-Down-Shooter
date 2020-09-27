using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{  //This will tell our gameobject/player what direction we would like to move. Normalized
    public Vector3 m_movementDirection;
    public float m_movementSpeed;
    public Rigidbody m_rigidBody;
    public float m_baseSpeed;
    public AudioSource m_audioSource;
    // Update is called once per frame
    void FixedUpdate()
    {
        ProcessInputs();
        Move();
        Mouselook();
    }

    private void Update()
        
    {
        Shoot();
    }

    private void ProcessInputs()
    {
        m_movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        m_baseSpeed = Mathf.Clamp(m_movementDirection.magnitude, 0.0f, 1.0f);
        m_movementDirection.Normalize();
        
    }

    private void Shoot()
    {
        //If LMB is pressed

        if (Input.GetMouseButtonDown(0))
        {
            m_audioSource.Play();
            //Did we hit something?
            if (Physics.Raycast(new Ray(transform.position, transform.forward), out RaycastHit hit, 100))
            {
                //Did we hit something interactable?
                if (hit.collider.gameObject.TryGetComponent(out Interactable interactable_script))
                {
                    interactable_script.Hit();
                }
            }
        }
    }

    private void Move()
    {
        m_rigidBody.velocity = m_movementDirection * (m_baseSpeed * m_movementSpeed);
    }
    private void Mouselook()

    {
        Ray ray;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 1000)) {

            Vector3 newPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(newPosition);
        }
    }
}