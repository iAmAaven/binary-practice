using TMPro;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    private BinaryPractice binaryPractice;
    public TextMeshProUGUI questionText, correctOrIncorrectText;
    public TMP_InputField inputField;


    void OnEnable()
    {
        binaryPractice = FindFirstObjectByType<BinaryPractice>();
        binaryPractice.questionText = this.questionText;
        binaryPractice.correctOrIncorrectText = this.correctOrIncorrectText;
        binaryPractice.inputField = this.inputField;
    }

}
