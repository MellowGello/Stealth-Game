using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : AIState
{
    public Transform path;
    public GameObject player;
    public EnemyAnimation EAScript;

    public EnemyFOV FOVScript;
    public float moveSpeed = 5;
    public float turnSpeed = 90;
    public float pause = .5f;

    public Vector3 movePosition;

    public bool ded;
    public bool disable;
    public bool stop;
    public bool playerSpotted;

    public float RealKTime = 2f;
    public float AstralKTime = 4f;

    public Vector3[] waypoints;
    Vector3 targetWaypoints;
    int targetWaypointIndex = 1;

    void Start()
    {
        waypoints = new Vector3[path.childCount];
        EAScript = GetComponent<EnemyAnimation>();
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = path.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }

        transform.position = waypoints[0];

        targetWaypoints = waypoints[targetWaypointIndex];
        transform.LookAt(targetWaypoints);
    }

    public override void UpdateState(AICharacter owner)
    {
        if(!playerSpotted & !ded & !disable)
        {
            movePosition = Vector3.MoveTowards(owner.transform.position, targetWaypoints, moveSpeed * Time.deltaTime);
            owner.transform.position = movePosition;
            if (owner.transform.position == targetWaypoints)
            {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWaypoints = waypoints[targetWaypointIndex];
                stop = true;

                StartCoroutine(TurnToFace(targetWaypoints));
            }
        }

        if (playerSpotted)
        {
            owner.currentState = new ChaseState();
        }
    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

        if (!playerSpotted & !disable & !ded)
        {
            while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
            {
                float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
                transform.eulerAngles = Vector3.up * angle;
                yield return null;
            }
        }
    }
}
