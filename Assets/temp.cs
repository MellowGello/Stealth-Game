using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    public GameObject target;
    float counter;
    void Start()
    {
        
    }

    void Update()
    {
        counter += Time.deltaTime;
        if(counter > 1)
        {
            target.transform.position = this.transform.position;
            counter = 0;
        }
    }
}
