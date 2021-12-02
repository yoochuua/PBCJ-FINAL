using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
///<summary> Classe que controla o funcionamento do "Score" e dos "Rounds"
public class HandleRecord : MonoBehaviour
{
    int QuantidadeMortos;
    int Round;
    // Start is called before the first frame update
    void Start()
    {
         PlayerPrefs.SetInt("QuantidadeMortos",0);
         PlayerPrefs.SetInt("Round",1);
    }

    // Update is called once per frame
    void Update()
    {
        QuantidadeMortos = PlayerPrefs.GetInt("QuantidadeMortos",0);
        Round = PlayerPrefs.GetInt("Round",0);
        GameObject.Find("Mortos").GetComponent<Text>().text = "Mortos: " + QuantidadeMortos;
        GameObject.Find("Round").GetComponent<Text>().text = "Round: " + Round;
    }
     
}
