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

    void Awake ()
    {
        currentBalance = startingBalance;
    }

    void Update()
    {

    }


    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }



}
