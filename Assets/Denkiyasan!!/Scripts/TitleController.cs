using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public GameObject HelpPanel;

    public void OnStartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnHelpButton()
    {
        HelpPanel.SetActive(true);
    }
    public void ExitHelpButton()
    {
        HelpPanel.SetActive(false);
    }

}
