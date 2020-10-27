using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireEnemy : EnemyBase
{
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
        damage = 25f;
        nmAgent = GetComponent<NavMeshAgent>();
        nmAgent.speed = speed;
        animator = GetComponent<Animator>();
        attackRange = 3.0f;
        fAI = FireAI.Run;
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distancefromPlayer = Vector3.Distance(transform.position, target.transform.position);
        //Debug.Log(distancefromPlayer);
        if (distancefromPlayer < 3.0f)
        {
            setState(FireAI.attack1);
        }

        switch (fAI)
        {
            case FireAI.Run:
                nmAgent.speed = speed;
                nmAgent.isStopped = false;
                nmAgent.SetDestination(target.transform.position);
                distancefromPlayer = Vector3.Distance(transform.position, target.transform.position);
                if (distancefromPlayer < attackRange)
                {
                    setState(FireAI.attack1);
                }
                break;
            case FireAI.attack1:
                nmAgent.isStopped = true;
                nmAgent.speed = 0;
                //target.GetComponent<PlayerHealth>().setHealth(damage);
                distancefromPlayer = Vector3.Distance(transform.position, target.transform.position);
                if (distancefromPlayer > attackRange)
                {
                    setState(FireAI.Run);
                }
                break;
            case FireAI.attack2:
                break;
            case FireAI.gethit:
                health -= damage;
                if (health <= 0.0f)
                {
                    fAI = FireAI.death2;
                }
                break;
            case FireAI.death1:
                break;
            case FireAI.death2:
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0.0f)
        {
            setState(FireAI.death2);
        }
    }
}
