using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool isLeft;
    public SpriteRenderer spriter;

    SpriteRenderer player;

    Vector3 rightPos = new Vector3(0.35f, -0.15f, 0);
    Vector3 rightPosReverse = new Vector3(-0.15f, -0.15f, 0);
    Quaternion leftRot = Quaternion.Euler(0,0,-35);
    Quaternion leftRotReverse = Quaternion.Euler(0,0,-135);

    private void Awake()
    {
        player = GetComponentsInParent<SpriteRenderer>()[1];
    }

    private void LateUpdate()
    {
        bool isRevers = player.flipX;

        if (isLeft) // 근접무기
        {
            transform.localRotation = isRevers ? leftRotReverse : leftRot;
            spriter.flipY = isRevers;
            spriter.sortingOrder = isRevers ? 4 : 6;
        }
        else // 원거리
        {
            transform.localPosition = isRevers ? rightPosReverse : rightPos;
            spriter.flipX = isRevers;
            spriter.sortingOrder = isRevers ? 6 : 4;
        }
    }
}
