using TMPro;
using UnityEngine;

public class HighScoreLoader : MonoBehaviour
{
    public TextMeshProUGUI classicHighScoreText, bulletHighScoreText;

    void OnEnable()
    {
        classicHighScoreText.text = "" + PlayerPrefs.GetInt("ClassicHighScore", 0);
        bulletHighScoreText.text = "" + PlayerPrefs.GetInt("BulletHighScore", 0);
    }
}
