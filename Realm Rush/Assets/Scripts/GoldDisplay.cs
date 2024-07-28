using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldDisplay : MonoBehaviour
{
    Bank bank;
    TMP_Text gold;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
        gold = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if(bank != null)
        {
            gold.text = "Gold: " + bank.CurrentBalance.ToString();
        }
    }
}
