using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireEnemy : EnemyBase
{
    [SerializeField]
    GameObject target;
    NavMeshAgent nmAgent;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        speed = 5f;
        armor = 0f;
        nmAgent = GetComponent<NavMeshAgent>();
        nmAgent.speed = speed;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distancefromPlayer = Vector3.Distance(transform.position, target.transform.position);
        Debug.Log(distancefromPlayer);
        if (distancefromPlayer < 3.0f)
        {
            animator.SetTrigger("Attack(1)");
            animator.SetBool("Run", false);
            nmAgent.isStopped = true;
        }
        else
        {
            animator.SetBool("Run", true);
            nmAgent.isStopped = false;
            nmAgent.SetDestination(target.transform.position);
        }
    }
}
