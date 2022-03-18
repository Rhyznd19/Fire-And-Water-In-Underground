using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class benda : MonoBehaviour
{
    private Collider2D coll;
    private void Start()
    {
        coll = GetComponent<Collider2D>();
    }
    //darah musuh
    private void OnTriggerEnter2D(Collider2D benda)
    {
        if (benda.gameObject.tag == "Api")
        {
            Destroy(gameObject);
        }
        if(benda.gameObject.tag == "Air")
        {
            this.GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
