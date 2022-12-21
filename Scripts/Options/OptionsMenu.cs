using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void Sound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex.ToString("MusicScene"));
    }

    public void Score()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex.ToString("QuizScores"));
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex.ToString("StartScene"));
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("name");
        PlayerPrefs.DeleteKey("Geography Score");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex.ToString("FirstLogin"));
    }
}
