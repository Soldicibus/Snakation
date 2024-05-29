using System.Collections;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public TextMeshProUGUI scoreTMP, speedTMP;
    public TextMeshProUGUI resolvedTMP;
    public TextMeshProUGUI gameOverTMP;
    public int score, resolvedExamples, totalExamples;
    void Start()
    {
        score = 0;
        resolvedExamples = 0;
    }

    private void Update()
    {
        scoreTMP.text = $"Score: {score}";
        resolvedTMP.text = $"Solved: {resolvedExamples}/{totalExamples}";
    }
}
