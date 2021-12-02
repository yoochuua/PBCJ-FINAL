using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
///<summary> Classe que controla o funcionamento do menu "GameOver"
public class GameOver : MonoBehaviour
{
    //volta para o menu
    public void voltarMenu (){
      SceneManager.LoadScene("Menu");
  }

    //Reinicia o jogo
  public void reiniciarJogo (){
      SceneManager.LoadScene("Horda");
  }
}
