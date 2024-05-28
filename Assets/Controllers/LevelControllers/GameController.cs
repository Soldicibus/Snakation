using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public TextMeshProUGUI scoreTMP;
    public TextMeshProUGUI resolvedTMP;
    public TextMeshProUGUI gameOverTMP;
    public int score, resolvedExamples;
    void Start()
    {
        score = 0;
        resolvedExamples = 0;
    }

    private void Update()
    {
        scoreTMP.text = $"Очки: {score}";
        resolvedTMP.text = $"Розв'язано: {resolvedExamples}/10";
    }
}
