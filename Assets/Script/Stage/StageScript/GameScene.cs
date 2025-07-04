using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    private GameObject[] enemyB;

    public GameObject clear;
    public GameObject countText;
    private float count = 3;

    public GameObject player;
    public GameObject gameovertext;

    //public GameObject enemy1;

    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;
        countText.GetComponent<Text>().text = count.ToString("F0");

        enemyB = GameObject.FindGameObjectsWithTag("Enemy");
        print("敵の数:" + enemyB.Length);



        if (count < 0)
        {
            countText.SetActive(false);
        }

        if (enemyB.Length == 0)
        {
            StartCoroutine(DestroyDelayed());
            clear.gameObject.SetActive(true);
            player.gameObject.SetActive(false);
            gameovertext.gameObject.SetActive(false);
        }

        IEnumerator DestroyDelayed()
        {
            yield return new WaitForSeconds(2f); // 削除を遅らせる時間（秒）
            clear.gameObject.SetActive(false);
            OnChange1();
        }

    }

    public void OnChange1()
    {
        // 実際の削除処理
        SceneManager.LoadScene("1-1");
    }
}
