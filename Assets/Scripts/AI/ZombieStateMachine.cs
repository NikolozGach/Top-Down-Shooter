using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieStateMachine : MonoBehaviour
{
    public enum State{
        WANDER,
        MUTATE,
        CHASE
    }

    public State m_curr_state;
    public Stack<State> m_curr_state_stack = new Stack<State>();

    private void Start()
    {
        FindNewRandomWaypoint();
    }

    private void Update() {
        UpdateAI();
    }

    private void UpdateAI()
    {
        switch(m_curr_state)
        {
            case State.WANDER:
            {
                //If we have reached our waypoint
                if (HasReachedWaypoint())
                {
                    //Grab a new waypoint
                    FindNewRandomWaypoint();
                }
                break;
            }
            case State.MUTATE:
            {
                break;
            }
            case State.CHASE:
            {
                
                break;
            }
            default:
                break;
        }
    }

    private bool HasReachedWaypoint()
    {
        if (Vector3.Distance(gameObject.GetComponent<NavMeshAgent>().destination, gameObject.transform.position) <= 0.2f)
        {
            return true;
        }
        return false;
    }

    private void FindNewRandomWaypoint()
    {
        Vector3 random_pos = UnityEngine.Random.insideUnitSphere * 10;

        FindPathToTarget(random_pos);
    }

    private void FindPathToTarget(Vector3 target)
    {
        NavMeshPath path = new NavMeshPath();

        gameObject.GetComponent<NavMeshAgent>().CalculatePath(target, path);
        gameObject.GetComponent<NavMeshAgent>().SetPath(path);
    }

}
