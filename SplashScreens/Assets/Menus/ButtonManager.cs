using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{

    public GameObject creditsWindow;
    private bool showCredits;

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

    }


}
