using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public string gameMode = "Classic";
    public int score = 0, highScore;
    public TextMeshProUGUI scoreText, newHighScoreText, newRecordAmountText;
    private BinaryPractice binaryPractice;


    void OnEnable()
    {
        binaryPractice = FindFirstObjectByType<BinaryPractice>();
        score = 0;
        scoreText.text = score.ToString();
        highScore = PlayerPrefs.GetInt(binaryPractice.binaryMode + gameMode + "HighScore", 0);
        newHighScoreText.gameObject.SetActive(false);
    }

    public void CorrectAnswer()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void WrongAnswer()
    {
        if (score > highScore)
        {
            highScore = score;

            if (gameMode == "Classic")
            {
                PlayerPrefs.SetInt(binaryPractice.binaryMode + "ClassicHighScore", highScore);
                newHighScoreText.gameObject.SetActive(true);
                newRecordAmountText.text = "" + highScore;
                score = 0;
                scoreText.text = score.ToString();
                StopCoroutine(HideNewHighScoreText());
                StartCoroutine(HideNewHighScoreText());
            }
        }

        if (gameMode == "Classic")
        {
            score = 0;
            scoreText.text = score.ToString();
        }
        else if (gameMode == "Bullet" && !GetComponent<BulletBinary>().isGameOver)
        {
            GetComponent<BulletBinary>().Reduction();
        }
    }

    IEnumerator HideNewHighScoreText()
    {
        yield return new WaitForSeconds(5f);
        newHighScoreText.gameObject.SetActive(false);
    }
}
