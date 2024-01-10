using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public Scanner scanner;
    public Hand[] hands;
    public RuntimeAnimatorController[] animCon;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    private void OnEnable()
    {
        speed *= Character.Speed;
        anim.runtimeAnimatorController = animCon[GameManager.instance.playerId];
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        hands = GetComponentsInChildren<Hand>(true);
    }

    private void Update()
    {
        if (!GameManager.instance.isLive)
            return;
    }
    private void FixedUpdate() //������ ���ؼ��� FixedUpdate���� ȣ��
    {

        if (!GameManager.instance.isLive)
            return;

        {
            // 1. ���� �ش�
            //rigid.AddForce(inputVec); // ���� �ɾ�ٴϵ��� ������

            // 2. �ӵ� ����
            //rigid.velocity = inputVec; // �ӵ��� ���� �����ؼ� ������
        }

        // nomalized : �ӵ��� �����ϰ� ���� (�밢������ �� ������ ������ �ִ°� ������)
        // Time.fixedDeltaTime : fixedDeltaTime�� fixedUpdate���� ����ϰ� DeltaTime�� Update���� �����
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        // 3. ��ġ �̵�
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    private void LateUpdate()
    {

        if (!GameManager.instance.isLive)
            return;

        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0; 
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!GameManager.instance.isLive)
            return;

        GameManager.instance.health -= Time.deltaTime * 10;

        if(GameManager.instance.health < 0)
        {
            for(int i = 2; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            anim.SetTrigger("Dead");
            GameManager.instance.GameOver();
        }
    }
}
