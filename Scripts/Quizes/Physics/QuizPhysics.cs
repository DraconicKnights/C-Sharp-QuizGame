using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizPhysics : MonoBehaviour
{
    public List<QuestionList> questionLists;
    public GameObject[] options;
    public int currentQuestions;

    public Text QuestionTxt;

    public GameObject Quizpannel;
    public GameObject RetryPannel;

    public Text ScoreTxt;
    public Text TimeTxt;

    public int score;

    int totalquestions = 0;

    private float timeRemaining;

    private void Start()
    {
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

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex.ToString("StartScene"));
    }

    public void GameOver()
    {
        Quizpannel.SetActive(false);
        RetryPannel.SetActive(true);
        ScoreTxt.text = score + "/" + totalquestions;
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
            options[i].GetComponent<AnswerPhysics>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = questionLists[currentQuestions].Awnsers[i];
            
            if (questionLists[currentQuestions].CorrectAnswers == i+1)
            {
                options[i].GetComponent<AnswerPhysics>().isCorrect = true;
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
