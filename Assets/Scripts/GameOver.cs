using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
///<summary> 
///Classe que controla o funcionamento do menu "GameOver"
///</summary>
public class GameOver : MonoBehaviour
{
    /* Callback para o botão de voltar ao menu principal */
    public void voltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    /* Callback para o botão de reiniciar o jogo */
    public void reiniciarJogo()
    {
        SceneManager.LoadScene("Horda");
    }
}
