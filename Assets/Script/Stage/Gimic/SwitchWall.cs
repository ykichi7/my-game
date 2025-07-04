using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWall : MonoBehaviour
{

    public GameObject wallSet;
    private float settime=0;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && settime < 5)
        {
            settime += Time.deltaTime;
            SetAct();

            StartCoroutine(ActivateWallSetAfterDelay(2f));
        }
    }

    public void SetAct()
    {
        wallSet.SetActive(false);
        settime = 0;
    }

    private IEnumerator ActivateWallSetAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        wallSet.SetActive(true);
    }
}
