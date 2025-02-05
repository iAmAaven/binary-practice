using System.Collections;
using TMPro;
using UnityEngine;

public class BulletBinary : MonoBehaviour
{
    public int solveTimerInMinutes = 5, reductionAmountInSeconds = 10;
    public GameObject gameOverMenu, newRecordShower;
    public TextMeshProUGUI recordText, timeText, reductionText;
    public ScoreKeeper scoreKeeper;
    [HideInInspector] public bool isGameOver = false;
    private BinaryPractice binaryPractice;
    private int solveTimerInSeconds;
    private float timer = 1f;

    void OnEnable()
    {
        solveTimerInSeconds = solveTimerInMinutes * 60;
        timeText.text = solveTimerInMinutes + ":00";
        reductionText.gameObject.SetActive(false);
        isGameOver = false;
    }

    void Update()
    {
        if (isGameOver)
            return;

        if (solveTimerInSeconds > 0)
        {
            if (Time.time >= timer)
            {
                solveTimerInSeconds--;
                timer = Time.time + 1f;
                RefreshTimeText();
            }
        }
        else
            GameOver();
    }

    void RefreshTimeText()
    {
        int minutes = solveTimerInSeconds / 60;
        int seconds = solveTimerInSeconds % 60;

        timeText.text = minutes + ":" + (seconds < 10 ? "0" : "") + seconds;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverMenu.SetActive(true);
        binaryPractice = FindFirstObjectByType<BinaryPractice>();
        binaryPractice.gameStarted = false;

        if (scoreKeeper.score > PlayerPrefs.GetInt(binaryPractice.binaryMode + "BulletHighScore", 0))
        {
            newRecordShower.SetActive(true);
            PlayerPrefs.SetInt(binaryPractice.binaryMode + "BulletHighScore", scoreKeeper.score);
        }
        else
            newRecordShower.SetActive(false);

        recordText.text = "" + scoreKeeper.score;

        gameObject.SetActive(false);
    }
    public void Reduction()
    {
        solveTimerInSeconds -= reductionAmountInSeconds;
        RefreshTimeText();
        reductionText.gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(HideReductionText());
    }

    IEnumerator HideReductionText()
    {
        yield return new WaitForSeconds(1f);
        reductionText.gameObject.SetActive(false);
    }
}
