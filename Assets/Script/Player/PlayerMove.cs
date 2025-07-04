using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 2;
    Vector2 movement;
    private bool canMove = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(OnMove());
    }

    private IEnumerator OnMove()
    {
        // 3ïbä‘ë“Ç¬
        yield return new WaitForSeconds(3);
        // ÉtÉâÉOÇtrueÇ…ê›íËÇ∑ÇÈ
        canMove = true;

    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            OnMoving();
        }
    }

    void OnMoving()
    {
        //à⁄ìÆ
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //playerÇÃà⁄ìÆ
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Bullet")
        {
            SceneManager.LoadScene("gameover");
        }
    }
}
