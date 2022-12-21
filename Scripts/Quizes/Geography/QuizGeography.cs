using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizGeography : MonoBehaviour
{
    public List<QuestionList> questionLists;
    public GameObject[] options;
    public int currentQuestions;

    public Text QuestionTxt;

    public GameObject Quizpannel;
    public GameObject RetryPannel;
    public GameObject Button;

    public Text ScoreTxt;
    public Text TimeTxt;
    public Text liveTxt;

    [SerializeField] private int score;
    [SerializeField] private int attempts;
    [SerializeField] private int points;
    [SerializeField] private int _latestpercent;

    [SerializeField] private bool gameover;

    int totalquestions = 0;

    private float timeRemaining;

    private void Start()
    {
        gameover = false;
        timeRemaining = 10;
        totalquestions = questionLists.Count;
        RetryPannel.SetActive(false);
        generateQuestion();
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
           timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            if (!gameover)
                Debug.Log("Time has run out");
                timeRemaining = 0;
                GameOver();
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        TimeTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex.ToString("StartScene"));
    }

    public void retry()
    {
        attempts = PlayerPrefs.GetInt("attempts");

        if (attempts > 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex.ToString("StartScene"));
    }

    public void GameOver()
    {
        gameover = true;
        Quizpannel.SetActive(false);
        RetryPannel.SetActive(true);
        ScoreTxt.text = score + "/" + totalquestions;
        _latestpercent = score / totalquestions * 100;
        if (_latestpercent < 50)
        {
            attempts = PlayerPrefs.GetInt("attempts");
            attempts--;
        }
        if (_latestpercent > 50 && _latestpercent < 60)
        {
            points = PlayerPrefs.GetInt("points");
            points += 10;
        }
        if (_latestpercent > 60 && _latestpercent < 70)
        {
            points = PlayerPrefs.GetInt("points");
            points += 40;
        }
        if (_latestpercent > 70 && _latestpercent < 80)
        {
            points = PlayerPrefs.GetInt("points");
            points += 80;
        }
        PlayerPrefs.SetInt("Geography Score", _latestpercent);
        PlayerPrefs.SetInt("attempts", attempts);
        PlayerPrefs.SetInt("points", points);

        attempts = PlayerPrefs.GetInt("attempts");

        liveTxt.text = string.Format("{0}", attempts);

    }

    public void wrong()
    {
   
        questionLists.RemoveAt(currentQuestions);
        generateQuestion();
    }

    public void Correct()
    {
        score += 1;
        questionLists.RemoveAt(currentQuestions);
        generateQuestion();
    }

    private void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerGeography>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = questionLists[currentQuestions].Awnsers[i];

            if (questionLists[currentQuestions].CorrectAnswers == i + 1)
            {
                options[i].GetComponent<AnswerGeography>().isCorrect = true;
            }
        }
    }

    private void generateQuestion()
    {
        if (questionLists.Count > 0)
        {
            currentQuestions = Random.Range(0, questionLists.Count);

            QuestionTxt.text = questionLists[currentQuestions].Question;

            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
    }
}
