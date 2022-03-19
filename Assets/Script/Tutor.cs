using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutor : MonoBehaviour
{
    public Player p;
    public void Appear()
    {
        gameObject.SetActive(true);
    }
    
    public void Read()
    {
        gameObject.SetActive(false);
    }
}
