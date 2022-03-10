using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject thiscanvas;


    public void Play()
    {
        Debug.Log("play");
        SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
        thiscanvas.SetActive(false);
    }
    public void Options()
    {
        Debug.Log("opt");
    }

    public void Credits()
    {
        Debug.Log("creds");
    }

    public void Quit()
    {
        Debug.Log("quit");
    }

}
