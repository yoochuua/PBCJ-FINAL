using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
///<summary> Classe que controla o funcionamento do menu

public class menuManager : MonoBehaviour
{
    //inicia o jogo
    public void iniciaJogo (){
        SceneManager.LoadScene("Horda");
    }
    
    //inicia a tela de créditos
    public void iniciaCreditos(){
        SceneManager.LoadScene("creditos");
    }
}
