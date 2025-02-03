using TMPro;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    private BinaryPractice binaryPractice;
    public TextMeshProUGUI questionText, correctOrIncorrectText;
    public TMP_InputField inputField;
    public GameObject newHighScore;


    void OnEnable()
    {
        binaryPractice = FindFirstObjectByType<BinaryPractice>();
        binaryPractice.newRecordShower = newHighScore;
        binaryPractice.questionText = this.questionText;
        binaryPractice.correctOrIncorrectText = this.correctOrIncorrectText;
        binaryPractice.inputField = this.inputField;
    }

}
