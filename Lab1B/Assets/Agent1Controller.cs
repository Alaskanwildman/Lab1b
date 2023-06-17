using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent1Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public float speed = 5.0f;
    public float playerDistanceThreshold = 5.0f;
    public float targetDistanceThreshold = 3.0f;

    private void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);

        if (targetDistance < targetDistanceThreshold)
        {
            if (playerDistance < playerDistanceThreshold)
            {
                FleeFromPlayer();
            }
            else
            {
                ChasePlayer();
            }
        }
        else
        {
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    private void FleeFromPlayer()
    {
        Vector3 direction = transform.position - player.transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }
}
