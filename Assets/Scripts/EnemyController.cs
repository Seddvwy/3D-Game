using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    CharacterStates states;
    //public Transform Player;
    NavMeshAgent agent;
    Animator anim;
    public float attackRadius = 5;

    bool canAttack = true;
    float attackCooldown = 3f;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        states = GetComponent<CharacterStates>(); 
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
        float distance = Vector3.Distance(transform.position, LevelManager.instance.Player.position);
        if(distance < attackRadius )
        { 
            agent.SetDestination(LevelManager.instance.Player.position);
            if(distance <= agent.stoppingDistance)
            {
                if (canAttack)
                {
                    StartCoroutine(cooldown());
                    anim.SetTrigger("Attack");


                }
            }
        }

    }


    IEnumerator cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player Contacted!");
            states.ChangeHealth(-other.GetComponentInParent<CharacterStates>().power);
            //Destroy(gameObject);
        }
    }

    public void DamagePlayer()
    {
        LevelManager.instance.Player.GetComponent<CharacterStates>().ChangeHealth(-states.power);
        FindObjectOfType<audioManager>().Play("PlayerDamage");
    }

}
