using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreMenu : MonoBehaviour
{
    [Header("Text Objects")]
    public Text _geography;
    public Text _physics;
    public Text BoxName;

    [Header("Int Objects")]
    public int _geography_score;
    public int _physics_score;
    void Start()
    {
        //Geography Score and Format
        _geography_score = PlayerPrefs.GetInt("Geography Score");
        _geography.text = string.Format("{0}", _geography_score);

        //Player Name

        BoxName.text = PlayerPrefs.GetString("name");

    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex.ToString("SceneOptions"));
    }


}
