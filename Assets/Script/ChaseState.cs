using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : AIState
{
    public GameObject Player;

    int MoveSpeed = 4;
    int MaxDistance = 20;
    int MinDistance = 2;

    //Know the path to player (out of scsope)

    //know how far the player is

    public override void UpdateState(AICharacter owner)
    {

        //look towards the player
        Player = GameObject.FindWithTag("Player");
        owner.transform.LookAt(Player.transform);

        Debug.Log(Player.name);


        //move towards the player
        //AI postition
        //Player position

        owner.transform.position = Vector3.MoveTowards(owner.transform.position, Player.transform.position, 1 * Time.deltaTime);

        float distance = Vector3.Distance(Player.transform.position, owner.transform.position);

        if (distance <= 2)
        {
            owner.currentState = new AttackState();
        }
        if (distance >= 20)
        {
            owner.currentState = new IdleState();
        }
    }
}
