using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int rewardGold = 25;
    [SerializeField] int penaltyGold = 25;

    Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        bank.Deposit(rewardGold);
    }

    public void PenaltyGold()
    {
        bank.Withdraw(penaltyGold);
    }

}
