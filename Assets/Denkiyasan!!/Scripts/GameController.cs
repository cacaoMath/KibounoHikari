using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int score = 0;

    public PlayerController playerController;
    public LightController lightController;
    public AudioSource bgm;
    public GameObject resultPanel;
    public Text scoreText,lightGazeText;
    public WrenchPanel wrenchPanel;

    // Start is called before the first frame update
    void Update()
    {
        score = CalcScore();
        scoreText.text = "Score : " + score + "m";
        lightGazeText.text = lightController.GetLightGaze() + "%";
        wrenchPanel.UpdateWrench(playerController.Life());

        if(playerController.Life() <= 0 || lightController.IsBlackOut())
        {
            bgm.Stop();
            enabled = false;
            resultPanel.SetActive(true);
            Invoke("CallRanking",1.0f);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) GameExit();

    }

    int CalcScore()
    {
        return playerController.HikariScore();
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene("Main");
    }

    void CallRanking()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
    }
}
