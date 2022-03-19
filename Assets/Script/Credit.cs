using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{

    public int iLevelToLoad;
    public string sLevelLoad;

    public bool UseIntegerToLoadLevel;
    // Start is called before the first frame update
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name == "Player")
        {
            StartCoroutine(waitscene());
            LoadScene();
        }
    }

    private void LoadScene()
    {
        if (UseIntegerToLoadLevel)
        {
            SceneManager.LoadScene(iLevelToLoad);
        }
        else
        {
            SceneManager.LoadScene(sLevelLoad);
        }
    }

    IEnumerator waitscene()
    {
        yield return new WaitForSeconds(0.2f);
    }


}
