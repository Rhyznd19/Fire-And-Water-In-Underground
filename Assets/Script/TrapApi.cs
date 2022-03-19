using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapApi : MonoBehaviour
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
    }
}
