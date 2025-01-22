using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gO_PnlPause;
    private bool isPause;
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
        isPause = true;
        Time.timeScale = 0f;
        gO_PnlPause.SetActive(true);
    }

    public void ClosePause()
    {
        isPause = false;
        Time.timeScale = 1f;
        gO_PnlPause.SetActive(false);
    }

    public void MyLoadScene(int sceneId)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneId);
    }

    public void Quit()
    {
        
    }
}
