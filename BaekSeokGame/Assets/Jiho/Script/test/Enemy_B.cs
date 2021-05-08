using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_B : Enemy
{

    // Start is called before the first frame update
    public override void Start()
    {
        

        enemyRigid = GetComponent<Rigidbody2D>();

        _transform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();

        StartCoroutine(this.CheckState());
        StartCoroutine(this.CheckStateForAction());
    }

    // Update is called once per frame
    public override void Update()
    {

    }

    public override void TakeDamage(int damage)
    {
        


    }

    public override void Die()
    {

        Debug.Log("enemy died!");
        //지호가 추가한 내용

        GameObject.Find("QuestManager").GetComponent<QuestManager>().QuestEmemyDied(this.GetComponent<EnemyData>().id);
        //
        anim.SetBool("IsDead", true);
        isDead = true;

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    public override IEnumerator CheckState()
    {

        yield return new WaitForSeconds(0.2f);


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
                    movement.x = playerTransform.position.x - _transform.position.x;
                    movement.y = playerTransform.position.y - _transform.position.y;
                    enemyRigid.velocity = movement.normalized * 3.0f;
                    break;
            }
            yield return null;
        }

    }

    //공격 미구현 상태에서 접촉에 따른 데미지 주기 용도. 나중에 폐기하자
    public override void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
