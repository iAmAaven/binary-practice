using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BinaryMenu : MonoBehaviour
{
    public GameObject mainMenu, settingsMenu, gameModeMenu, gameOverMenu;
    public BinaryPractice binaryPractice;
    public Color defaultTextColor, defaultBackgroundColor;


    void Start()
    {
        Light2D globalLight = FindFirstObjectByType<Light2D>();

        globalLight.color = new Color(
            PlayerPrefs.GetFloat("TextColor_R", defaultTextColor.r),
            PlayerPrefs.GetFloat("TextColor_G", defaultTextColor.g),
            PlayerPrefs.GetFloat("TextColor_B", defaultTextColor.b),
            PlayerPrefs.GetFloat("TextColor_A", defaultTextColor.a));

        Camera cam = Camera.main;

        cam.backgroundColor = new Color(
            PlayerPrefs.GetFloat("Background_R", defaultBackgroundColor.r),
            PlayerPrefs.GetFloat("Background_G", defaultBackgroundColor.g),
            PlayerPrefs.GetFloat("Background_B", defaultBackgroundColor.b),
            PlayerPrefs.GetFloat("Background_A", defaultBackgroundColor.a));
    }

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
            else if (gameOverMenu.activeSelf)
            {
                gameOverMenu.SetActive(false);
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
