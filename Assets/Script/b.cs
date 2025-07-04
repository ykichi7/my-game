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
            yield return new WaitForSeconds(2f); // íœ‚ğ’x‚ç‚¹‚éŠÔi•bj
            OnChange();
        }
    }


    public void OnChange()
    {
        // ÀÛ‚Ìíœˆ—
        SceneManager.LoadScene("Ttile");
    }
}
