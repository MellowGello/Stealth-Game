using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacter : MonoBehaviour
{
    public AIState currentState;

    public GameObject Player;

    public Transform[] points;



    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");

       

        currentState = new PatrolState();


    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
}
