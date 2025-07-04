using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lodingSS : MonoBehaviour
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
            SceneManager.LoadScene("SSscene");
        }
    }
}
