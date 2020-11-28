using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacter : MonoBehaviour
{
    public Transform other;

    public AIState currentState;


    // Start is called before the first frame update
    void Start()
    {
        currentState = new IdleState();


    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, 5, 0);
        //other.position += new Vector3(0.5f, 0.5f, 0.5f);

        currentState.UpdateState(this);
    }
}
