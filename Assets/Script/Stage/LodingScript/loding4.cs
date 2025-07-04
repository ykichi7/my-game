using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loding4 : MonoBehaviour
{

    private float loding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        loding += Time.deltaTime;

        if (loding > 2f)
        {
            SceneManager.LoadScene("stage4");
        }
    }
}
