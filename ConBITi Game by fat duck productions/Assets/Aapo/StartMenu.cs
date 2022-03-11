using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject thiscanvas;
    public GameObject creditcanvas;
    public GameObject productioncanvas;
    public GameObject production1;
    public GameObject production2;
    public GameObject production3;
    public GameObject production4;
    public AudioSource audiosource;
    private void Awake()
    {
        creditcanvas.SetActive(false);
 

    }

    public IEnumerator Intro()
    {
        Debug.Log("wait");
        production1.SetActive(true);
        yield return new WaitForSeconds(1f);
        production2.SetActive(true);
        yield return new WaitForSeconds(1f);
        production3.SetActive(true);
        yield return new WaitForSeconds(1f);
        production4.SetActive(true);
        yield return new WaitForSeconds(3f);
        productioncanvas.SetActive(false);
        audiosource.enabled = true;
        
    }

    private void Start()
    {
        StartCoroutine("Intro");
    }


  

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
        creditcanvas.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("quit");
    }

    public void Back()
    {
        creditcanvas.SetActive(false);
    }
}
