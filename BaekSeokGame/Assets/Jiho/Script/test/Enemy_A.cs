using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_A : Enemy
{

    public Transform target;
    public float speed = 500f;
    public float nextWaypointDistance = 2f;

    Path path;
    public int currentWaypoint = 0;
    public bool reachedEndOfPath = false;

    Seeker seeker;

    // Start is called before the first frame update
    public override void Start()
    {
        
        enemyCurrentHealth = enemyMaxHealth;


        seeker = GetComponent<Seeker>();
        enemyRigid = GetComponent<Rigidbody2D>();

        

        _transform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        target = playerTransform;

        StartCoroutine(this.CheckState());
        StartCoroutine(this.CheckStateForAction());
    }


    // Update is called once per frame
    public override void Update()
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


        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - enemyRigid.position).normalized;
        enemyRigid.velocity = direction * 3.0f;



        float distance = Vector2.Distance(enemyRigid.position, path.vectorPath[currentWaypoint]);

        

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

    }



    public override void TakeDamage(int damage)
    {
        enemyCurrentHealth -= damage;

        anim.SetTrigger("Hurt");

        if (enemyCurrentHealth <= 0)
        {
            Die();
        }
    }
    //공격 미구현 상태에서 접촉에 따른 데미지 주기 용도. 나중에 폐기하자
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<Combat>().TakeHit(enemyAttackDamage);
        }
    }
    public override void Die()
    {

        Debug.Log("enemy died!");
        //지호가 추가한 내용
        //enemy에서 ememy_A로 옮기다가 뭐 잘못건드렸는지 에러나서 잠시 주석처리

        GameObject.Find("QuestManager").GetComponent<QuestManager>().QuestEmemyDied(this.GetComponent<EnemyData>().id);
        //
        anim.SetBool("IsDead", true);
        isDead = true;

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }


    public bool findTarget()
    {
        return false;
    }


    public override IEnumerator CheckState()
    {
        while (!isDead)
        {
            yield return new WaitForSeconds(0.2f);

            float dist = Vector3.Distance(playerTransform.position, _transform.position);

            if (dist < enemyTraceRange && dist > enemyAttackMinRange)
            {
                curState = CurrentState.trace;
            }
            else if (dist < enemyAttackMinRange)
            {
                curState = CurrentState.attack;
            }
            else
            {
                curState = CurrentState.idle;
            }
        }
    }

    public override IEnumerator CheckStateForAction()
    {
        while (!isDead)
        {
            switch (curState)
            {
                case CurrentState.idle:
                    enemyRigid.velocity = new Vector2(0, 0);
                    break;
                case CurrentState.attack:
                    enemyRigid.velocity = new Vector2(0, 0);
                    break;
                case CurrentState.trace:
                    
                    UpdatePath();
                    
                    break;
            }
            yield return new WaitForSeconds(0.2f);
        }

    }



    void UpdatePath()
    {
        
        if (seeker.IsDone())
        {
            
            seeker.StartPath(enemyRigid.position, target.position, OnPathComplete);
        }

    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            
            path = p;
            currentWaypoint = 0;
        }
    }



}
