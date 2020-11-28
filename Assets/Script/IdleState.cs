using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AIState
{
    //if the player enters the character's view, change state to chase state

    //get player game object
    public GameObject Player;

    public override void UpdateState(AICharacter owner)
    {
        owner.transform.Rotate(0, 5, 0);

        //get player's position
        if (Player == null)
            Player = GameObject.FindWithTag("Player");

        //distance to player and radius
        float distance = Vector3.Distance(Player.transform.position, owner.transform.position);

        // set a distance check
        if(distance <= 5)
        //if (Input.GetKeyDown(KeyCode.Space))
        {
            owner.currentState = new ChaseState();
        }
    }
}
