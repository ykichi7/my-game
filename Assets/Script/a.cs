using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();  // ゲームを終了する場合
            // or
            // gameObject.SetActive(false);  // ゲームオブジェクトを非アクティブにする場合
        }
    }
}
