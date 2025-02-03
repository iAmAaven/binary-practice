using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public string gameMode = "Classic";
    public int streak = 0, highScore;
    public TextMeshProUGUI streakText, newHighScoreText, newRecordAmountText;

    private BinaryPractice binaryPractice;

    void Start()
    {
        binaryPractice = FindFirstObjectByType<BinaryPractice>();
        highScore = PlayerPrefs.GetInt(gameMode + "HighScore", 0);
    }

    public void CorrectAnswer()
    {
        streak++;
        streakText.text = streak.ToString();
    }

    public void WrongAnswer()
    {
        if (streak > highScore)
        {
            highScore = streak;
            PlayerPrefs.SetInt(gameMode + "HighScore", highScore);
            newHighScoreText.gameObject.SetActive(true);
            newRecordAmountText.text = "" + highScore;
            StopCoroutine(HideNewHighScoreText());
            StartCoroutine(HideNewHighScoreText());
        }

        streak = 0;
        streakText.text = streak.ToString();
    }

    IEnumerator HideNewHighScoreText()
    {
        yield return new WaitForSeconds(5f);
        newHighScoreText.gameObject.SetActive(false);
    }
}
