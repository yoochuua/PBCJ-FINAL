using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
///<summary> Classe que controla o funcionamento da tela de creditos
public class creditosManager : MonoBehaviour
{
   Text textoCreditos;
   public float speed;
   void Start()
    {
      textoCreditos = GameObject.Find("Creditos").GetComponent<Text>();
    }
     //volta para o menu
    public void voltarMenu (){
      SceneManager.LoadScene("Menu");
  }

    //Reinicia o jogo
  public void reiniciarJogo (){
      SceneManager.LoadScene("Horda");
  }
   void Update()
    {
      Vector3 oldPosition = textoCreditos.transform.position;
      Vector3 newPosition = oldPosition + (Vector3.down)*speed;
      textoCreditos.transform.position = newPosition;
    }
}
