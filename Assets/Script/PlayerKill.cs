using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : MonoBehaviour
{
    public float Radius;
    public LayerMask tagetMask;
    public LayerMask deadMask;
    public float counter;
    public bool action;
    public List<EnemyMove> enemies = new List<EnemyMove>();
    float temp = 1;
    void Start()
    {
        
    }

    void Update()
    {
        KillTarget();
    }

    void KillTarget()
    {
        enemies.Clear();
        Collider[] target = Physics.OverlapSphere(transform.position, Radius, tagetMask);

        for (int i = 0; i < target.Length; i++)
        {
            if (target[i].gameObject.CompareTag("Enemy"))
            {
                enemies.Add(target[i].GetComponent<EnemyMove>());
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if(enemies[0] != null)
                {
                    action = true;
                    ExecuteKill();
                    Debug.Log("Die! Die! Die!");
                }
            }
        }

        if (action)
        {
            counter += Time.deltaTime;
        }
        else
        {
            counter = 0;
        }

        if (counter >= temp & enemies.Count > 0)
        {
            counter = 0;
            action = false;
            enemies[0].DeadFunc();
        }
    }

    void ExecuteKill()
    {
        if (enemies.Count > 0)
        {
            if (GetComponent<PlayerMove>().Switch)
            {
                temp = enemies[0].AstralKTime;
            }
            else
            {
                temp = enemies[0].RealKTime;
            }
            enemies[0].disable = true;
            transform.LookAt(new Vector3(enemies[0].gameObject.transform.position.x, transform.position.y, transform.position.z));
        }
        else
        {
            action = false;
        }
    }
}
