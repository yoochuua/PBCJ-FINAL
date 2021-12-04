using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
///<summary> 
///Classe que controla o funcionamento da tela de creditos
///</summary>
public class creditosManager : MonoBehaviour
{
    Text textoCreditos; //Texto que sera mostrado na tela de creditos
    public float speed; //Velocidade com que o texto ira se movimentar (para cima)

    /* Start is called before the first frame update */
    void Start()
    {
        textoCreditos = GameObject.Find("Creditos").GetComponent<Text>();
    }

    /* Callback do botão de voltar */
    public void voltarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    /* Callback do botão de jogar novamente */
    public void reiniciarJogo()
    {
        SceneManager.LoadScene("Horda");
    }

    /* Update is called once per frame */
    void Update()
    {
        //Atualiza a posição do texto de acordo com a velocidade
        Vector3 oldPosition = textoCreditos.transform.position;
        Vector3 newPosition = oldPosition + (Vector3.up) * speed;
        textoCreditos.transform.position = newPosition;
    }
}
