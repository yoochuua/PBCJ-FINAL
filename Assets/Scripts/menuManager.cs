using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
///<summary>
///Classe que controla o funcionamento do menu
///</summary>

public class menuManager : MonoBehaviour
{
    /*
        Carrrega a cena do jogo
    */
    public void iniciaJogo()
    {
        SceneManager.LoadScene("Horda");
    }

    /*
        Carrega a cena de creditos
    */
    public void iniciaCreditos()
    {
        SceneManager.LoadScene("creditos");
    }
}
