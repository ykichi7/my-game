using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] Transform bulletPos;
    [SerializeField] GameObject bulletPrefab;

    public float bulletSpeed = 5;

    private float ShootTime = 0;
    public float ShootMaxTime = 1.1f;

    public Transform arrowTrans; // 動かすオブジェクトのトランスフォーム
    public Transform TargetTrans; // ターゲットのオブジェクトのトランスフォーム
    private bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(OnStart());
    }

    private IEnumerator OnStart()
    {
        // 3秒間待つ
        yield return new WaitForSeconds(3);
        // フラグをtrueに設定する
        canMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            ShootTime += Time.deltaTime;

            if (ShootTime >= ShootMaxTime)
            {
                Shot();
                ShootTime = 0;
            }

            // 向きたい方向を計算
            Vector3 dir = (TargetTrans.position - arrowTrans.position);

            // ここで向きたい方向に回転させてます
            arrowTrans.rotation = Quaternion.FromToRotation(Vector3.left, dir);
        }
        
    }

    void Shot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-bulletPos.right* bulletSpeed, ForceMode2D.Impulse);
    }

}
