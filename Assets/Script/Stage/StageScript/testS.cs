using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class testS : MonoBehaviour
{
    private GameObject[] enemyB;

    public GameObject clear;
    public GameObject countText;
    private float count = 3;

    public GameObject player;
    public GameObject gameovertext;
    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;
        countText.GetComponent<Text>().text = count.ToString("F0");

        enemyB = GameObject.FindGameObjectsWithTag("Enemy");
        print("ìGÇÃêî:" + enemyB.Length);



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
            yield return new WaitForSeconds(2f); // çÌèúÇíxÇÁÇπÇÈéûä‘ÅiïbÅj
            clear.gameObject.SetActive(false);
            OnChange();
        }

    }

    public void OnChange()
    {
        // é¿ç€ÇÃçÌèúèàóù
        SceneManager.LoadScene("clear");
    }
}
