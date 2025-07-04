using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomarlBullet : MonoBehaviour
{
    public GameObject explosionPrefab;

    public GameObject wallefextPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            // 爆発エフェクトを生成する
            var exp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(exp, 3);
            Destroy(collision.gameObject);
            Destroy(gameObject);
           
        }

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            var exp = Instantiate(wallefextPrefab, transform.position, Quaternion.identity);
            Destroy(exp, 3);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
           
            Destroy(gameObject);
        }
    }

    void Explose(Vector3 pos)
    {
        var exp = Instantiate(explosionPrefab, pos, Quaternion.identity);
        Destroy(exp, 3);
    }

    void Exploses(Vector3 pos)
    {
        var exp = Instantiate(wallefextPrefab, pos, Quaternion.identity);
        Destroy(exp, 3);
    }
}
