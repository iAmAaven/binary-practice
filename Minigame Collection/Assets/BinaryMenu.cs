using UnityEngine;

public class BinaryMenu : MonoBehaviour
{
    public BinaryPractice binaryPractice;


    // void Update()
    // {
    //     if (!binaryPractice.gameStarted
    //         && ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C))
    //         || Input.GetKeyDown(KeyCode.Escape)))
    //     {
    //         QuitGame();
    //     }
    // }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
