using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    public Transform player;
    public Transform[] patrolPoints;

    public Transform currentPath;

    private int endPoint = 0;
    private NavMeshAgent enemy;

    public bool canSeePlayer = false;
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();

        enemy.autoBraking = false;

        //navToPoints();

    }

    // Update is called once per frame
    void Update()
    {
        if (canSeePlayer == true)
        {
            enemy.destination = player.position;
        }
        else
        {
            enemy.destination = currentPath.position;

        }

        //if(!enemy.pathPending && enemy.remainingDistance < 0.5f)
        //{
        //    navToPoints();
        //}
    }

    //void navToPoints()
    //{
    //    if(patrolPoints.Length == 0)
    //    {
    //        return;
    //    }

    //    enemy.destination = patrolPoints[endPoint].position;

    //    endPoint = (endPoint + 1) % patrolPoints.Length;

    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            canSeePlayer = true;
            Debug.Log("Player Detected");
        }
        if (other.CompareTag("Checkpoint1"))
        {
            enemy.destination = patrolPoints[1].position;
            currentPath.position = patrolPoints[1].position;
            Debug.Log("test");
        }
        if (other.CompareTag("Checkpoint2"))
        {
            enemy.destination = patrolPoints[2].position;
            currentPath.position = patrolPoints[2].position;

        }
        if (other.CompareTag("Checkpoint3"))
        {
            enemy.destination = patrolPoints[3].position;
            currentPath.position = patrolPoints[3].position;

        }
        if (other.CompareTag("Checkpoint4"))
        {
            enemy.destination = patrolPoints[0].position;
            currentPath.position = patrolPoints[0].position;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            canSeePlayer = true;
            StartCoroutine(wait());
            Debug.Log("Player Detected");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player Out of Sight");
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
        canSeePlayer = false;
        yield break;
    }
}
