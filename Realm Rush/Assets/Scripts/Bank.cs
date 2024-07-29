using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance = 0;
    public int CurrentBalance{get{return currentBalance;}}

    [SerializeField] GameObject boss;

    void Awake ()
    {
        currentBalance = startingBalance;
    }

    void Update()
    {
        if (currentBalance < 0)
        {
            ReloadLevel();
        }

        //temp
        //SummonBoss();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

     void SummonBoss()
    {
        if(boss == null)
        {
            return;
        }
        if (currentBalance >= 300)
        {
            boss.SetActive(true);
        }
    }


    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
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
