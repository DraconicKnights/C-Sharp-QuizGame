using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerGeography : MonoBehaviour
{
    public QuizGeography quiz;

    public bool isCorrect = false;
    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct");
            quiz.Correct();
        }
        else
        {
            Debug.Log("Wrong");
            quiz.wrong();
        }
    }
}
