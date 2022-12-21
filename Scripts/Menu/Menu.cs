using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void MenuClickStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex.ToString("SelectScene"));
    }

    public void MenuClickOptions()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex.ToString("SceneOptions"));
    }

    public void MenuClickShop()
    {
        Debug.Log("Comming soon...");
    }

}
