using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using System;

///<summary> Classe que controla o funcionamento do "Score" e dos "Rounds"
public class HandleRecord : MonoBehaviour
{
    int QuantidadeMortos; // quantidade inimigosMortos
    int Round;// quantidade de rounds
    // Start is called before the first frame update
    void Start()
    {
        
         int Recorde = PlayerPrefs.GetInt("Recorde",0);
         PlayerPrefs.SetInt("QuantidadeMortos",0);
         PlayerPrefs.SetInt("Round",1);
         GameObject.Find("Recorde").GetComponent<Text>().text = "Recorde: " + Recorde + " Mortos";
    }

    // Update is called once per frame
    void Update()
    {
        QuantidadeMortos = PlayerPrefs.GetInt("QuantidadeMortos",0);
        Round = 1 + QuantidadeMortos/2;//PlayerPrefs.GetInt("Round",0);
        GameObject.Find("Mortos").GetComponent<Text>().text = "Mortos: " + QuantidadeMortos;
        GameObject.Find("Round").GetComponent<Text>().text = "Round: " + Round;
    }
     
}
