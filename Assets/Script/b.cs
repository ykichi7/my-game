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
            yield return new WaitForSeconds(2f); // �폜��x�点�鎞�ԁi�b�j
            OnChange();
        }
    }


    public void OnChange()
    {
        // ���ۂ̍폜����
        SceneManager.LoadScene("Ttile");
    }
}
