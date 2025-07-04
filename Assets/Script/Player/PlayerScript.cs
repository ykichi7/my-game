using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector2 mousPos;
    Vector2 playerPos;
    private bool canMove = false;

    const int donC=5;

    [SerializeField] Camera cam; //Maincamera

    [SerializeField] GameObject player; //body

    [SerializeField] GameObject[] objec;  // 配置したいオブジェクト
    public GameObject LinePrefabs;

    [SerializeField] Transform bulletPos; //BulletPos
    public GameObject bulletPrefab; //BulletPrefab

    public float bulletSpeed = 7;

    [SerializeField] GameObject bulletText; //Bulletの弾数
    [SerializeField] GameObject bulletgameover; //弾数切れのtext

    private float gameoverTime =0;
    private float gameoverMaxTime = 3;

    private float bulletmin;
    public float bullets; //打てる弾数

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(OnMove());
        // objectPrefabs配列の初期化（オブジェクトをシーン上から見つけて格納する場合）
        objec = new GameObject[donC];
        for(int i = 0; i < donC; ++i)
        {
            objec[i] = Instantiate(LinePrefabs);
        }
    }

    private IEnumerator OnMove()
    {
        // 3秒間待つ
        yield return new WaitForSeconds(3);
        // フラグをtrueに設定する
        canMove = true;

    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        //向きを取得
        Vector2 lookDir = mousPos - rb.position;
        //角度を取得
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        
    }


    void OnSS()
    {
        if (bullets > bulletmin)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("joystick button 0"))
            {
                OnShot();
                bullets--;
            }
        }
        else
        {
            bulletgameover.SetActive(true);
            gameoverMaxTime -= Time.deltaTime;
            bulletgameover.GetComponent<Text>().text = gameoverMaxTime.ToString("F0");
        }

        if (Input.GetMouseButtonDown(1))
        {
            // 現在のシーンを再読み込みする
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    void Update()
    {

        if (canMove)
        {
            OnSS();
        }

        //マウス座標
        mousPos = cam.ScreenToWorldPoint(Input.mousePosition);

        playerPos = player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, 0);


        bulletText.GetComponent<Text>().text = bullets.ToString("F0");

        
        

        if(gameoverMaxTime < gameoverTime)
        {
            SceneManager.LoadScene
                ("gameover");
        }

        PlaceObjects(mousPos,playerPos);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();  // ゲームを終了する場合
            // or
            // gameObject.SetActive(false);  // ゲームオブジェクトを非アクティブにする場合
        }
    }


    void OnShot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletPos.up * bulletSpeed, ForceMode2D.Impulse);
    }


    void PlaceObjects(Vector3 start , Vector3 end )
    {

        for (int i = 0; i < donC; i++)
        {
            var val = (float)i / donC;
            var pos =Vector3.Lerp(start, end,val);
            objec[i].transform.position = pos;
        }
    }
}
