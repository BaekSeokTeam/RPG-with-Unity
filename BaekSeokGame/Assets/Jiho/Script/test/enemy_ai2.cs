using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemy_ai2 : MonoBehaviour
{
    public enum CurrentState { idle, trace, attack };
    public CurrentState curState = CurrentState.idle;
    public Transform target;

    public float speed = 500f;
    public float nextWaypointDistance = 1f;

    Path path;
    public int currentWaypoint = 0;
    public bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();


        StartCoroutine(this.CheckState());
        StartCoroutine(this.CheckStateForAction());
        target = GameObject.Find("Player").transform;

    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }

    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            Debug.Log("enemy1 onptahtcompeltm if in");
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        rb.velocity = direction * 3.0f;

        
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

    }



    public IEnumerator CheckState()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);


            
            if (true)
            {
                curState = CurrentState.trace;
            }

        }
    }



    public IEnumerator CheckStateForAction()
    {
        while (true)
        {
            
            switch (curState)
            {
                case CurrentState.idle:
                    rb.velocity = new Vector2(0, 0);
                    break;
                case CurrentState.attack:
                    rb.velocity = new Vector2(0, 0);
                    break;
                case CurrentState.trace:
                    Debug.Log("cocococo");

                    UpdatePath();
                    break;
            }
            yield return new WaitForSeconds(0.2f);
        }

    }
}

