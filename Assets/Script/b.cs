using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class b : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(adfwf());

        IEnumerator adfwf()
        {
            yield return new WaitForSeconds(2f); // 削除を遅らせる時間（秒）
            OnChange();
        }
    }


    public void OnChange()
    {
        // 実際の削除処理
        SceneManager.LoadScene("Ttile");
    }
}
