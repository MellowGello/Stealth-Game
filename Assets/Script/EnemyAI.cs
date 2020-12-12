using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public Vector3 velocity;
    public float speed = 2;

    void Start()
    {
        
    }


    void Update()
    {
        velocity = (target.position - this.transform.position).normalized * speed;
        this.transform.position += velocity * Time.deltaTime;
        
    }
}
