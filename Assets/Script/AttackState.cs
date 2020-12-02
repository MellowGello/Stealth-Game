using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AIState
{ 
    public override void UpdateState(AICharacter owner)
    {

        float distance = Vector3.Distance(owner.Player.transform.position, owner.transform.position);

        //check if player is in attack range
        //rotate when near the player

        if (distance <= 1)
        {
            owner.transform.Rotate(0, 2, 0);
        }
        
        else
        {
            owner.currentState = new ChaseState();
            
        }
        //stop attacking when player is out of reach


    }
}
