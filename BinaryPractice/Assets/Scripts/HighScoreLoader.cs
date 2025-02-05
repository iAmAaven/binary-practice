using TMPro;
using UnityEngine;

public class HighScoreLoader : MonoBehaviour
{
    public TextMeshProUGUI classicHighScoreText, bulletHighScoreText;

    public void LoadHighScore(string mode)
    {
        classicHighScoreText.text = "" + PlayerPrefs.GetInt(mode + "ClassicHighScore", 0);
        bulletHighScoreText.text = "" + PlayerPrefs.GetInt(mode + "BulletHighScore", 0);
    }
}
