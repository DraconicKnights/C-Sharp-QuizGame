using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewUser : MonoBehaviour
{
    public InputField textBox;

    [SerializeField] private int attempts;
    [SerializeField] private int points;

    public void ClickSave()
    {
        PlayerPrefs.SetString("name", textBox.text);
        Debug.Log("Your name is " + PlayerPrefs.GetString("name"));
        attempts = 5;
        points = 0;
        PlayerPrefs.SetInt("attempts", attempts);
        PlayerPrefs.SetInt("points", points);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex.ToString("StartScene"));
    }
}
