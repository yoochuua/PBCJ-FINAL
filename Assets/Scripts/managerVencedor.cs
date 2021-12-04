using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
///<summary> 
///Classe que controla o funcionamento da tela de vitória
///</summary>
public class managerVencedor : MonoBehaviour
{
    /* 
       Função que carrega a cena de creditos
    */
    public void vaiCreditos()
    {
        SceneManager.LoadScene("creditos");
    }
}
