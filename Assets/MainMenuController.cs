using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


[System.Serializable]
public class MainMenuController : MonoBehaviour
{
    [SerializeField] private VisualElement _userInterface;
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;
    private Label _saveStatus;

    private void Start() // Change Awake() to Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        if (uiDocument != null)
        {
            _userInterface = uiDocument.rootVisualElement;
        }
        else
        {
            Debug.LogError("UIDocument component not found on this GameObject!");
            return;
        }

        if (_userInterface == null)
        {
            Debug.LogError("_userInterface is still null. Ensure the UIDocument is correctly assigned.");
            return;
        }

        // Find Buttons by their correct names
        _newGameButton = _userInterface.Q<Button>("StartButton");
        _continueButton = _userInterface.Q<Button>("MechanicsButton");
        _exitButton = _userInterface.Q<Button>("ExitButton");

        if (_newGameButton != null)
            _newGameButton.clicked += OnNewGameClicked;
        else
            Debug.LogError("StartButton not found in UI Document!");

        if (_continueButton != null)
            _continueButton.clicked += OnContinueClicked;
        else
            Debug.LogError("MechanicsButton not found in UI Document!");

        if (_exitButton != null)
            _exitButton.clicked += OnExitClicked;
        else
            Debug.LogError("ExitButton not found in UI Document!");
    }

    private void OnNewGameClicked()
    {
        SceneManager.LoadScene("WinterLevel");
    }

    private void OnContinueClicked()
    {
        SceneManager.LoadScene("MechanicsScene");
    }

    private void OnExitClicked()
    {
        Application.Quit();
    }
}
