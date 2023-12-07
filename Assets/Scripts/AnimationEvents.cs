using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public CharacterMovement charMove;


    public void PlayerAttack()
    {
        Debug.Log("Player Attacked!");
        FindObjectOfType<audioManager>().Play("Attack");
        charMove.DoAttack();
    }

    public void PlayerDamage()
    {
        transform.GetComponentInParent<EnemyController>().DamagePlayer();
    }


    public void MoveSound()
    {
        FindObjectOfType<audioManager>().Play("PlayerSteps");

    }

}
