using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//enemy 틀 짜는 추상 클래스로 만들 예정. 실제 구현은 A B 이쪽가서 할 예정

/*
 * 이 클래스를 상속받은 개별 몬스터 스크립트에서 패턴 등 구현
 * 그 스크립트를 가진 유니티 오브젝트에서 스탯 수치 설정하고 프리팹으로 저장
 * 몬스터 생성은 해당 프리팹들을 매니저같은거 만들어서 인스턴스화! 
 * 맞나?


*/


public abstract class Enemy : MonoBehaviour
{

    //지호가 추가한 내용
    
    //
    

    //유니티 관리 용도
    public Animator anim;

    protected Transform _transform;
    protected Transform playerTransform;

    protected Rigidbody2D enemyRigid;
    protected Vector2 movement;



    //몬스터의 능력치

    public string enemyName;
    public enum enemyTypeTable
    {
        animal,
        demon
    };

    public enemyTypeTable enemyType;

    public int enemyLevel;

    public int enemyMaxHealth;
    public int enemyCurrentHealth;

    public int enemyAttackDamage;
    public int enemySkillDamage;

    public int enemyArmor;
    public int enemyResistance;

    public float enemyAttackMulti;
    public float enemyDefenseMulti;

    public float enemyTraceRange;
    public float enemyAttackMinRange;
    public float enemyAttackMaxRange;
    public float enemySkillMinRange;
    public float enemySkillMaxRange;





    //몬스터의 상태 체크용
    protected bool isDead = false;
    protected bool isInvulnerable = false;


    //ai 구현용
    public enum CurrentState { idle, trace, attack };
    public CurrentState curState = CurrentState.idle;




    // Start is called before the first frame update
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();

    public abstract void TakeDamage(int damage);

    public abstract void Die();

    public abstract IEnumerator CheckState();

    public abstract IEnumerator CheckStateForAction();

    //공격 미구현 상태에서 접촉에 따른 데미지 주기 용도. 나중에 폐기하자
    public abstract void OnCollisionEnter2D(Collision2D collision);
}
