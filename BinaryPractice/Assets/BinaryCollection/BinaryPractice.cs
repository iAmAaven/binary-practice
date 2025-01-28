using System;
using TMPro;
using UnityEngine;

public class BinaryPractice : MonoBehaviour
{
    public TextMeshProUGUI questionText, correctOrIncorrectText;
    public Color wrongColor, correctColor;
    public TMP_InputField inputField;
    public string gameMode = "bin2dec";

    public GameObject mainMenu, gameMenu;


    private int limitNumber = 1024;

    private string binaryQuestion;
    private int decimalQuestion;

    [HideInInspector] public bool gameStarted = false;

    public void StartGame(string mode)
    {
        gameStarted = true;
        gameMode = mode;
    }

    public void ChooseMaxNumber(int maxNumber)
    {
        limitNumber = maxNumber;
    }

    void Update()
    {
        if (!gameStarted)
            return;

        if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C))
            || Input.GetKeyDown(KeyCode.Escape))
        {
            StopGame();
        }

        switch (gameMode)
        {
            case "bin2dec":
                BinaryToDecimal();
                break;
            case "dec2bin":
                DecimalToBinary();
                break;
        }
    }

    string RandomBinary()
    {
        int value = UnityEngine.Random.Range(1, limitNumber);
        binaryQuestion = Convert.ToString(value, 2);
        return binaryQuestion;
    }

    int RandomDecimal()
    {
        decimalQuestion = UnityEngine.Random.Range(1, limitNumber);
        return decimalQuestion;
    }

    int ConvertToDecimal(string binary)
    {
        return Convert.ToInt32(binary, 2);
    }

    string ConvertToBinary(int decimalValue)
    {
        return Convert.ToString(decimalValue, 2);
    }

    void BinaryToDecimal()
    {
        inputField.ActivateInputField();
        inputField.Select();

        int input = 0;

        if (inputField.text != "")
            input = int.Parse(inputField.text);

        if (questionText.text == "")
        {
            questionText.text = RandomBinary();
        }

        if (ConvertToDecimal(binaryQuestion) == input)
        {
            questionText.text = RandomBinary();
            inputField.text = "";
            correctOrIncorrectText.text = "Correct!";
            correctOrIncorrectText.color = correctColor;
            Invoke("ClearCorrectText", 1f);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                questionText.text = RandomBinary();
                inputField.text = "";
                correctOrIncorrectText.text = "Incorrect.";
                correctOrIncorrectText.color = wrongColor;
                Invoke("ClearCorrectText", 1f);
            }
        }
    }

    void DecimalToBinary()
    {
        inputField.ActivateInputField();
        inputField.Select();

        string input = inputField.text;

        if (questionText.text == "")
        {
            questionText.text = RandomDecimal().ToString();
        }

        if (input != "" && input == ConvertToBinary(int.Parse(questionText.text)))
        {
            questionText.text = RandomDecimal().ToString();
            inputField.text = "";
            correctOrIncorrectText.text = "Correct!";
            correctOrIncorrectText.color = correctColor;
            Invoke("ClearCorrectText", 1f);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                questionText.text = RandomDecimal().ToString();
                inputField.text = "";
                correctOrIncorrectText.text = "Incorrect.";
                correctOrIncorrectText.color = wrongColor;
                Invoke("ClearCorrectText", 1f);
                Debug.Log("Answer was incorrect. New question generated.");
            }
        }
    }

    void StopGame()
    {
        gameMode = "";
        questionText.text = "";
        inputField.text = "";
        Debug.Log("Game stopped.");
        mainMenu.SetActive(true);
        gameMenu.SetActive(false);
        Invoke("GameStopped", 0.1f);
    }

    void GameStopped()
    {
        gameStarted = false;
    }

    void ClearCorrectText()
    {
        correctOrIncorrectText.text = "";
    }
}
