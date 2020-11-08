using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateScript : MonoBehaviour
{
    State status = new State();
    State cur = new Attack();
    // Start is called before the first frame update
    void Start()
    {
        status.func();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

class State
{
    public void func()
    {
        Debug.Log("State");
    }
}

class Attack : State
{
    public int i;
}
