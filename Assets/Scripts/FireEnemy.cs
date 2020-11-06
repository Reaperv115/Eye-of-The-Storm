using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class FireEnemy : EnemyBase
{
    GameObject target;
    [SerializeField]
    Transform lavapuddlePlacement;
    [SerializeField]
    GameObject lavaPuddle;
    [SerializeField]
    GameObject floor;

    NavMeshAgent nmAgent;
    Animator animator;

    float temperature = 0.0f;
    float timeuntilleavingPuddle = 0.0f;

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
        enemyDamage = 1f;
        nmAgent = GetComponent<NavMeshAgent>();
        nmAgent.speed = speed;
        animator = GetComponent<Animator>();
        attackRange = 3.0f;
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //distancefromPlayer = Vector3.Distance(transform.position, target.transform.position);
        //Debug.Log(distancefromPlayer);

        if (timeuntilleavingPuddle >= 20.0f)
        {
            GameObject lavapuddleClone = Instantiate(lavaPuddle, lavapuddlePlacement.position, transform.rotation);
            lavapuddleClone.transform.localScale += new Vector3(5.0f, 0.0f, 5.0f);
            lavapuddleClone.transform.parent = null;
            lavapuddleClone.transform.SetParent(floor.transform);
            timeuntilleavingPuddle = 0.0f;
        }

        switch (fAI)
        {
            case FireAI.Run:
                nmAgent.speed = speed;
                nmAgent.isStopped = false;
                nmAgent.SetDestination(target.transform.position);
                distancefromPlayer = Vector3.Distance(transform.position, target.transform.position);
                if (distancefromPlayer <= attackRange)
                {
                    setState(FireAI.attack1);
                }
                else
                {
                    timeuntilleavingPuddle += 0.01f;
                    Debug.Log(timeuntilleavingPuddle);
                }
                if (health <= 0.0f)
                {
                    setState(FireAI.death2);
                }
                break;
            case FireAI.attack1:
                nmAgent.isStopped = true;
                nmAgent.speed = 0;
                ++temperature;
                Debug.Log(temperature);
                if (temperature >= 400f)
                {
                    Destroy(gameObject);
                    distancefromPlayer = Vector3.Distance(transform.position, target.transform.position);
                    if (distancefromPlayer <= 5f)
                    {
                        target.GetComponent<PlayerHealth>().changeHealth(enemyDamage);
                    }
                }
                distancefromPlayer = Vector3.Distance(transform.position, target.transform.position);
                if (distancefromPlayer > attackRange)
                {
                    setState(FireAI.Run);
                }
                break;
            case FireAI.attack2:
                break;
            case FireAI.gethit:
                if (target.GetComponent<AR>())
                {
                    health -= target.GetComponent<AR>().weaponDamage;
                    if (health <= 0.0f)
                    {
                        fAI = FireAI.death2;
                    }
                    break;
                }
                if (target.GetComponent<smg>())
                {
                    health -= target.GetComponent<smg>().weaponDamage;
                    if (health <= 0.0f)
                    {
                        fAI = FireAI.death2;
                    }
                    break;
                }
                if (target.GetComponent<RocketLauncher>())
                {
                    health -= target.GetComponent<RocketLauncher>().weaponDamage;
                    if (health <= 0.0f)
                    {
                        fAI = FireAI.death2;
                    }
                    break;
                }
                if (target.GetComponent<GrenadeLauncher>())
                {
                    health -= target.GetComponent<GrenadeLauncher>().weaponDamage;
                    if (health <= 0.0f)
                    {
                        fAI = FireAI.death2;
                    }
                    break;
                }
                if (target.GetComponent<pistol>())
                {
                    health -= target.GetComponent<pistol>().weaponDamage;
                    if (health <= 0.0f)
                    {
                        fAI = FireAI.death2;
                    }
                    break;
                }
                if (target.GetComponent<SniperRifle>())
                {
                    health -= target.GetComponent<SniperRifle>().weaponDamage;
                    if (health <= 0.0f)
                    {
                        fAI = FireAI.death2;
                    }
                    break;
                }
                if (target.GetComponent<shotgun>())
                {
                    health -= target.GetComponent<shotgun>().weaponDamage;
                    if (health <= 0.0f)
                    {
                        fAI = FireAI.death2;
                    }
                    break;
                }
                if (target.GetComponent<EnergyHammer>())
                {
                    health -= target.GetComponent<EnergyHammer>().weaponDamage;
                    if (health <= 0.0f)
                    {
                        fAI = FireAI.death2;
                    }
                }
                break;
                
            case FireAI.death1:
                break;
            case FireAI.death2:
                Destroy(gameObject);
                target.GetComponent<PlayerScore>().playerScore += target.GetComponent<PlayerScore>().pointsperKill;
                int randomnumber = Random.Range(0, 100);
                if (randomnumber % 4 == 0)
                {
                    int randompowerup = Random.Range(0, 2);
                    Instantiate(target.GetComponent<Arsenal>().powerups[randompowerup], transform.position, transform.rotation);
                }
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
