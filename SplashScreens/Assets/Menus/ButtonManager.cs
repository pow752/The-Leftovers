using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{

    public GameObject creditsWindow;
    public GameObject controlsWindow;
    private bool showCredits;
    private bool showControls;

    public void NewGame(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    public void Start()
    {
        showCredits = false;
    }

    public void Credits()
    {
        showCredits = !showCredits;
    }

    public void Controls()
    {
        showControls = !showControls;
    }


    public void Update()
    {
        if (showCredits)
        {
            creditsWindow.SetActive(true);
        }
        else
        {
            creditsWindow.SetActive(false);
        }

        if (showControls)
        {
            controlsWindow.SetActive(true);
        }
        else
        {
            controlsWindow.SetActive(false);
        }

    }


}
