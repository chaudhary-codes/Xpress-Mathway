using UnityEngine;
using TMPro;

public class QuestionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;

    public void ShowQuestion(string problem)
    {
        questionText.text = problem;
    }
}