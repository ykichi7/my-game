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
            Application.Quit();  // �Q�[�����I������ꍇ
            // or
            // gameObject.SetActive(false);  // �Q�[���I�u�W�F�N�g���A�N�e�B�u�ɂ���ꍇ
        }
    }
}
