using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSwicth : MonoBehaviour
{
    public GameObject Set;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(Set);
            Destroy(gameObject);
        }
    }

}
