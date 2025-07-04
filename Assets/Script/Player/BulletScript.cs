using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private int block;
    private int blockMax =1;

    public GameObject explosionPrefab;
    public GameObject explosionPrefabs;
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            block++;
        }

        if (collision.gameObject.tag == "Player")
        {
            // �����G�t�F�N�g�𐶐�����
            var exp = Instantiate(explosionPrefabs, transform.position, Quaternion.identity);
            Destroy(exp, 3);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            // �����G�t�F�N�g�𐶐�����
            var exp = Instantiate(explosionPrefabs, transform.position, Quaternion.identity);
            Destroy(exp, 3);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "EnemyBullet")
        {
            // �����G�t�F�N�g�𐶐�����
            var exp = Instantiate(explosionPrefabs, transform.position, Quaternion.identity);
            Destroy(exp, 3);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "En1")
        {
            Destroy(gameObject);
        }
    }

    void Explose(Vector3 pos)
    {
        var exp = Instantiate(explosionPrefabs, pos, Quaternion.identity);
        Destroy(exp, 3);
    }

    void Update()
    {
        if (block > blockMax)
        {
            // �����G�t�F�N�g�𐶐�����
            var exp = Instantiate(explosionPrefabs, transform.position, Quaternion.identity);
            Destroy(exp, 3);
            Destroy(gameObject);
        }
    }
}
