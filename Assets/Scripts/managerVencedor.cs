using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
///<summary> Classe que controla o funcionamento da tela de vitória
public class managerVencedor : MonoBehaviour
{
    //ir aos creditos
  public void vaiCreditos (){
      SceneManager.LoadScene("creditos");
  }
}
