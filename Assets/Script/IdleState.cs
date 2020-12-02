using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AIState
{
    //if the player enters the character's view, change state to chase state
    //get player game object
    int index = 0;
    public override void UpdateState(AICharacter owner)
    {
        owner.transform.position = Vector3.MoveTowards(owner.transform.position, owner.points[index].position, 10 * Time.deltaTime);

        if (owner.points[index].position == owner.transform.position)
        {
            index++;
        }
        if(index > owner.points.Length-1)
        {
            index = 0;
        }
        //distance to player and radius
        float distance = Vector3.Distance(owner.Player.transform.position, owner.transform.position);

        // set a distance check
        if(distance <= 5)
        //if (Input.GetKeyDown(KeyCode.Space))
        {
            owner.currentState = new ChaseState();
        }
    }
}
