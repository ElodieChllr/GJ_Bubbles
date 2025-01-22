using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gO_PnlPause;
    public GameObject gO_PnlShop;
    void Start()
    {
        gO_PnlPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OpenPause()
    {
        Time.timeScale = 0f;
        gO_PnlPause.SetActive(true);
    }

    public void ClosePause()
    {
        Time.timeScale = 1f;
        gO_PnlPause.SetActive(false);
    }

    public void OpenShop()
    {
        gO_PnlShop.SetActive(true);
        gO_PnlPause.SetActive(false);
    }
    public void CloseShop()
    {
        gO_PnlShop.SetActive(false);
        gO_PnlPause.SetActive(true);
    }

    public void MyLoadScene(int sceneId)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneId);
    }

    public void Quit()
    {
        
    }
}
