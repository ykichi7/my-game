using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loging1 : MonoBehaviour
{

    private float loding;

    // Update is called once per frame
    void Update()
    {

        loding += Time.deltaTime;


       if(loding > 2f)
        {
            SceneManager.LoadScene("game");
        }
    }

}
