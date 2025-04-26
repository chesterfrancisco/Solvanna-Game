using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    private VisualElement pausePanel;
    private Button continueButton;
    private Button mainMenuButton;
    private Button exitButton;

    private bool isPaused = false;

    void Awake()
    {
        // Get UIDocument reference early
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Get UI elements by name
        pausePanel = root.Q<VisualElement>("pausePanel");
        continueButton = root.Q<Button>("continueButton");
        mainMenuButton = root.Q<Button>("mainMenuButton");
        exitButton = root.Q<Button>("exitButton");

        // Setup button events
        continueButton.clicked += ResumeGame;
        mainMenuButton.clicked += LoadMainMenu;
        exitButton.clicked += ExitGame;

        // Always hide pause panel at start
        pausePanel.style.display = DisplayStyle.None;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                PauseGame();
            else
                ResumeGame();
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("StartScreen");
        }
    }

    void PauseGame()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
        pausePanel.style.display = DisplayStyle.Flex;
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame()
    {
        pausePanel.style.display = DisplayStyle.None;
        Time.timeScale = 1f;
        isPaused = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScreen");
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
