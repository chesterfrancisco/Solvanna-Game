using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public string mainMenuScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        Debug.Log("Resume button clicked");
        GameManager.Instance.PauseUnpause();

    }

    public void MainMenu()
    {
        Debug.Log("Main Menu button clicked");
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quiting Game");
    }
}
