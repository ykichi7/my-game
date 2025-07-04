using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void OnTitle()
    {
        SceneManager.LoadScene("Ttile");
    }

    public void OnGame()
    {
        SceneManager.LoadScene("title_1-1");
    }

    public void OnGa()
    {
        SceneManager.LoadScene("title_cc");
    }
}
