using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles all menu interaction
/// The class inherits from Singleton to make it a singleton
/// </summary>
public class MenuManager : Singleton<MenuManager>
{
    /// <summary>
    /// A reference to the MainMenu
    /// </summary>
    [SerializeField]
    private GameObject mainMenu;

    /// <summary>
    /// Shows the main menu
    /// </summary>
    public void ShowMain()
    {
        mainMenu.SetActive(true);
    }

    /// <summary>
    /// Loads the scene
    /// </summary>
    public void Play()
    {
        //Loads the ingame level
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Quits to the main menu
    /// </summary>
    public void QuitToMain()
    {
        //Sets timescale to 1 to unpause
        Time.timeScale = 1;

        //Loads the scene manager
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Quits the Game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
