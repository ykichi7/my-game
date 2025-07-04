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

    public Transform arrowTrans; // �������I�u�W�F�N�g�̃g�����X�t�H�[��
    public Transform TargetTrans; // �^�[�Q�b�g�̃I�u�W�F�N�g�̃g�����X�t�H�[��
    private bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(OnStart());
    }

    private IEnumerator OnStart()
    {
        // 3�b�ԑ҂�
        yield return new WaitForSeconds(3);
        // �t���O��true�ɐݒ肷��
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

            // ���������������v�Z
            Vector3 dir = (TargetTrans.position - arrowTrans.position);

            // �����Ō������������ɉ�]�����Ă܂�
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
