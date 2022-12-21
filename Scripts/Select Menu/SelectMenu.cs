using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour
{
    public Text BoxName;

    public GameObject Panel;
    public GameObject AttemptPanel;

    [SerializeField] private int attempts;
    [SerializeField] private int points;

    private void Start()
    {
        Panel.SetActive(true);  
        AttemptPanel.SetActive(false);
        BoxName.text = PlayerPrefs.GetString("name");
        attempts = PlayerPrefs.GetInt("attempts");
    }
    public void Geography()
    {
        if (attempts > 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex.ToString("GameSceneGeography"));
        else
        {
            Panel.SetActive(false);
            AttemptPanel.SetActive(true);
        }

    }

    public void Physics()
    {
        if (attempts > 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex.ToString("GameScenePhysics"));
        else
        {
            Panel.SetActive(false);
            AttemptPanel.SetActive(true);
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex.ToString("StartScene"));
    }

}