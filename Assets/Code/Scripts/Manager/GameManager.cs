using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gO_PnlPause;
    public GameObject gO_PnlShop;

    private bool isShop;
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

    public void OpenCloseShop()
    {
        if (isShop)
        {
            Time.timeScale = 0f;
            gO_PnlShop.SetActive(true);
            gO_PnlPause.SetActive(false);
            isShop = false;
        }
        else
        {
            Time.timeScale = 1f;
            gO_PnlShop.SetActive(false);
            isShop = true;
        }
        
    }

    public void MyLoadScene(int sceneId)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneId);
    }

    public void Quit()
    {
        
    }
}
