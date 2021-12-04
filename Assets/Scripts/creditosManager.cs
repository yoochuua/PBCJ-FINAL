using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
///<summary> Classe que controla o funcionamento da tela de creditos
public class creditosManager : MonoBehaviour
{
   public int posX; // posição do texto em relação a x
   public int posY; // posição do texto em relação a y
   public int posZ; // posição do texto em relação a z
   Text posicaoCreditos;
   float posicaoDecremento;
   void Start()
    {
      posicaoCreditos = GameObject.Find("Creditos").GetComponent<Text>();
      posicaoCreditos.transform.position = new Vector3(posX,posY,posZ);
      posicaoDecremento = posY;
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
      posicaoDecremento = posicaoDecremento + 0.3f ;
      posicaoCreditos.transform.position = new Vector3(posX,posicaoDecremento,posZ);
    }
}
