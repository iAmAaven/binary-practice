using UnityEngine;

public class BinaryMenu : MonoBehaviour
{
    public GameObject mainMenu, settingsMenu, gameModeMenu;
    public BinaryPractice binaryPractice;


    void Update()
    {
        if (!binaryPractice.gameStarted
            && ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C))
            || Input.GetKeyDown(KeyCode.Escape)))
        {
            if (settingsMenu.activeSelf)
            {
                settingsMenu.SetActive(false);
                mainMenu.SetActive(true);
            }
            else if (gameModeMenu.activeSelf)
            {
                gameModeMenu.SetActive(false);
                mainMenu.SetActive(true);
            }
            else if (mainMenu.activeSelf)
            {
                QuitGame();
            }
        }
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
