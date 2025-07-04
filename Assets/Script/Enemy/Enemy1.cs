using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    
    private float moveSpeed = 2;
    private bool canMove = false;

    private Rigidbody2D rb;
    public float leftBoundary = 2f; // 往復の左端
    public float rightBoundary = 3f; // 往復の右端
    public float upperBoundary = 3f; // 上方向の移動の上限
    public float lowerBoundary = -3f; // 下方向の移動の下限
    private Vector2 startPosition; // 初期位置

    private enum MoveStage { MoveRight, MoveLeft, MoveToStartFromLeft, MoveUp, MoveDown, MoveToStartFromDown }
    private MoveStage currentStage = MoveStage.MoveRight; // 現在の移動ステージ


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position; // 初期位置を記録
        StartCoroutine(OnMove());
    }

    private IEnumerator OnMove()
    {
        // 3秒間待つ
        yield return new WaitForSeconds(3);
        // フラグをtrueに設定する
        canMove = true;

    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            switch (currentStage)
            {
                case MoveStage.MoveRight:
                    MoveRight();
                    break;
                case MoveStage.MoveLeft:
                    MoveLeft();
                    break;
                case MoveStage.MoveToStartFromLeft:
                    MoveToStartFromLeft();
                    break;
                case MoveStage.MoveUp:
                    MoveUp();
                    break;
                case MoveStage.MoveDown:
                    MoveDown();
                    break;
                case MoveStage.MoveToStartFromDown:
                    MoveToStartFromDown();
                    break;
            }
        }
    }

    private void MoveRight()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        if (transform.position.x >= rightBoundary)
        {
            rb.velocity = Vector2.zero;
            currentStage = MoveStage.MoveLeft;
        }
    }

    private void MoveLeft()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        if (transform.position.x <= leftBoundary)
        {
            rb.velocity = Vector2.zero;
            currentStage = MoveStage.MoveToStartFromLeft;
        }
    }

    private void MoveToStartFromLeft()
    {
        Vector2 direction = (startPosition - rb.position).normalized;
        rb.velocity = direction * moveSpeed;
        if (Vector2.Distance(rb.position, startPosition) < 0.1f)
        {
            rb.velocity = Vector2.zero;
            currentStage = MoveStage.MoveUp;
        }
    }

    private void MoveUp()
    {
        rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
        if (transform.position.y >= upperBoundary)
        {
            rb.velocity = Vector2.zero;
            currentStage = MoveStage.MoveDown;
        }
    }

    private void MoveDown()
    {
        rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);
        if (transform.position.y <= lowerBoundary)
        {
            rb.velocity = Vector2.zero;
            currentStage = MoveStage.MoveToStartFromDown;
        }
    }

    private void MoveToStartFromDown()
    {
        Vector2 direction = (startPosition - rb.position).normalized;
        rb.velocity = direction * moveSpeed;
        if (Vector2.Distance(rb.position, startPosition) < 0.1f)
        {
            rb.velocity = Vector2.zero;
            currentStage = MoveStage.MoveRight; // 初期ステージに戻す
        }
    }
}
