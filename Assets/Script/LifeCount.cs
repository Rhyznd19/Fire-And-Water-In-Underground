using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Image[] Lives;
    public int LivesRemaining;
 
    public void LoseLife()
    {
        LivesRemaining--;
        //menyembunyikan gambar 
        Lives[LivesRemaining].enabled = false;


        //jika live habis kita mati
        if(LivesRemaining == 0)
        {
            Debug.Log("Mati");
        }
    }

}
