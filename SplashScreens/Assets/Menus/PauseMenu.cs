using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject RequestWindow;
    private bool showRequestDialog = false;

    private bool paused = false;

    void Start()
    {
        showRequestDialog = false;
        RequestWindow.SetActive(false);
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if(paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }

        if (showRequestDialog)
        {
            RequestWindow.SetActive(true);
        }
        else
        {
            RequestWindow.SetActive(false);
        }
    }

    public void Resume()
    {
        paused = false;
    }

    public void ShowRequestDialog()
    {
        showRequestDialog = true;
    }

    public void CloseRequestDialog()
    {
        showRequestDialog = false;
    }


    public void ReturnToMenu()
    {
        paused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Uhh");
    }

}
