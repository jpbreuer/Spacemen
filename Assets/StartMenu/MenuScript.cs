using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas exitMenu;
    public Button startText;
    public Button exitText;

	// Use this for initialization
	void Start ()
    {
        exitMenu = exitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        exitMenu.enabled = false;
	
	}

    public void ExitPress()
    {
        exitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()
    {
        exitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

	public void StartLevel()
    {
        SceneManager.LoadScene (1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
