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

    public enum FireAI
    {
        Run = 0,
        attack1,
        attack2,
        gethit,
        death1,
        death2
    } public FireAI fAI;

    public FireAI getState()
    {
        return fAI;
    }

    public void setState(FireAI state)
    {
        fAI = state;
    }
       

    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        speed = 5f;
        armor = 0f;
        nmAgent = GetComponent<NavMeshAgent>();
        nmAgent.speed = speed;
        animator = GetComponent<Animator>();
        fAI = FireAI.Run;
    }

    // Update is called once per frame
    void Update()
    {
        distancefromPlayer = Vector3.Distance(transform.position, target.transform.position);
        Debug.Log(distancefromPlayer);
        if (distancefromPlayer < 3.0f)
        {
            setState(FireAI.attack1);
        }
        else
        {
            setState(FireAI.Run);
        }

        switch (fAI)
        {
            case FireAI.Run:
                nmAgent.speed = speed;
                nmAgent.isStopped = false;
                nmAgent.SetDestination(target.transform.position);
                animator.SetBool("run 0", true);
                break;
            case FireAI.attack1:
                nmAgent.isStopped = true;
                nmAgent.speed = 0;
                animator.SetBool("run 0", false);
                animator.SetTrigger("atack1");
                break;
            case FireAI.attack2:
                break;
            case FireAI.gethit:
                break;
            case FireAI.death1:
                break;
            case FireAI.death2:
                break;
            default:
                break;
        }
    }
}
