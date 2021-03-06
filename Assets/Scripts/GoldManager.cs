using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public int currentGold;
    public Text goldText;
    public Text totalGoldText;

    public void AddGold(int goldToAdd)
    {
        FindObjectOfType<AudioManager>().Play("GoldSnd");
        currentGold += goldToAdd;
        Debug.Log("GOLD : " + currentGold);
        goldText.text = "x " + currentGold;
        totalGoldText.text = currentGold.ToString();
    }  
}
