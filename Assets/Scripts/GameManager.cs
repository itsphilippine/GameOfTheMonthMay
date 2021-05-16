using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject player;

    public Text scoreText;

    public void ScoreArrondi(float resultat)
    {
        scoreText.text = Mathf.Round(resultat).ToString();
    }

}