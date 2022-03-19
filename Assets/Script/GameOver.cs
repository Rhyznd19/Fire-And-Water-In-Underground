using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text points;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        points.text = "Diamonds Acquired: " + score.ToString();
    }

    public void Respawn()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
