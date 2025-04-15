using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    public QuestionDatabase database;
    public QuestionUI ui;
    public OptionSpawner spawner;
    public GameObject LevelDonePanel;

    [Header("Stats")]
    public int score = 0;
    public float runnerSpeed = 20f;
    public float horizontalSpeed = 20f;
    public int health = 5;

    private List<Question> pool;
    private Question currentQuestion;
    private PlayerHealth PlayerHealth;
    public TextMeshProUGUI scoreText;
    private int idx=0;

    void Start()
    {
        pool = new List<Question>(database.questions);
        NextQuestion();
        PlayerHealth = FindObjectOfType<PlayerHealth>();
        PlayerHealth.Start();
        scoreText.text = "Score : " + score.ToString();
        UpdateScoreUI();
    }

    void NextQuestion()
    {
        if(idx==pool.Count && health>0){
            Debug.Log("Level Complete!");
            if (LevelDonePanel != null)
                LevelDonePanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if (pool.Count == 0)
            pool = new List<Question>(database.questions);

        //int idx = Random.Range(0, pool.Count);
        currentQuestion = pool[idx];
        //pool.RemoveAt(idx);

        ui.ShowQuestion(currentQuestion.problemText);
        spawner.ClearOptions();
        spawner.SpawnOptions(currentQuestion.options);
        idx++;
    }

    public void OnOptionHit(int chosenValue)
    {
        bool correct = (chosenValue == currentQuestion.options[currentQuestion.correctOptionIndex]);
        if (correct)
        {
            score += 10;
            runnerSpeed += 2f;
            horizontalSpeed += 2f;
            UpdateScoreUI();
        }
        else
        {
            PlayerHealth.TakeDamage();
        }

        NextQuestion();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score : " + score.ToString();
        }
    }

}