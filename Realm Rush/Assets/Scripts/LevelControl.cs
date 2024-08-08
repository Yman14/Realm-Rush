using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] GameObject resetPanel;



    readonly int bossSummoningCost = 200;
    bool bossCondition = false;
    Bank bank;

    void Start()
    {
        //bad code i think
        bank = FindObjectOfType<Bank>();
        resetPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Reset();
        SummonBoss();
        Debug.Log(Time.timeScale);
    }

    void SummonBoss()
    {
        if(boss == null)
        {
            return;
        }
        if (bank.CurrentBalance >= bossSummoningCost && !bossCondition)
        {
            boss.SetActive(true);
            bossCondition = true;
        }
        
        //if boss was summoned and killed
        if(bossCondition && !boss.activeSelf)
        {
            LoadNextScene();
        }
    }

    void Reset()
    {
        if (bank.CurrentBalance < 0 && !resetPanel.activeSelf)
        {
            Time.timeScale = 0f;    //pause the game
            resetPanel.SetActive(true);
        }
    }


    public void Exit()
    {
        Application.Quit();
    }


    public void LoadCurrentScene()
    { 
        Time.timeScale = 1f;    //resume the paused game

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

}
