using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateScript : MonoBehaviour
{
    State curState;
    public GameObject pauseMenu;
    public GameObject fastMenu;
    void Start()
    {
        curState = new UnPause();
    }

    void Update()
    {
        curState.func(pauseMenu,fastMenu);
        if (Input.GetKeyDown(KeyCode.Space)) { goNext(); }
        if (Input.GetKeyDown(KeyCode.Alpha1)) { setState("UnPause"); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { setState("Pause"); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { setState("FastForward"); }
    }

    public void goNext()
    {
        if (curState.id == 1) { curState = new Pause(); }
        else if (curState.id == 2) { curState = new FastForward(); }
        else if (curState.id == 3) { curState = new UnPause(); }
    }

    public void setState(string stringState)
    {
        if(stringState == "UnPause") { curState = new UnPause(); }
        else if (stringState == "Pause") { curState = new Pause(); }
        else if (stringState == "FastForward") { curState = new FastForward(); }    
    }
}

public class State
{
    public int id = 0;
    public virtual void func(GameObject p, GameObject f)
    {
        Debug.Log("Nothing ");
        p.SetActive(false);
        f.SetActive(false);
    }
}

class UnPause : State
{
    public override void func(GameObject p, GameObject f)
    {
        id = 1;
        Time.timeScale = 1f;
        p.SetActive(false);
        f.SetActive(false);
    }
}

class Pause : State
{
    public override void func(GameObject p, GameObject f)
    {
        id = 2;
        Time.timeScale = 0f;
        p.SetActive(true);
        f.SetActive(false);
    }
}

class FastForward : State
{
    public override void func(GameObject p, GameObject f)
    {
        id = 3;
        Time.timeScale = 2f;
        p.SetActive(false);
        f.SetActive(true);
    }
}
