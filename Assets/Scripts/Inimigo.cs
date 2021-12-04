using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
///<summary> Classe que controla os pontos de danos causados pelo inimigo
public class Inimigo : Caractere
{
   
    float pontosVida; // equivalente a saúde do inimigo
    public int forcaDano; // poder de dano
    Coroutine danoCoroutine;
    public int tipo;
    /* Start is called before the first frame update*/
    void Start()
    {
        
    }

    private void OnEnable(){
        ResetCaractere();
    }

    /*
    Método que adicina danos ao player de acordo com o que foi setado em força dano
    */
    private void OnTriggerEnter2D(Collider2D collision) { 
        if(collision is BoxCollider2D){
            if(collision.gameObject.CompareTag("Player")){
                Player player = collision.gameObject.GetComponent<Player>();
                if(danoCoroutine == null){
                    danoCoroutine = StartCoroutine(player.DanoCaractere(forcaDano, 1.0f));
                }

            }
        }
    }

    /*
    Método que verifica se o player já não está mais em contato com o inimigo, caso não, ele para o dano
    */
    void OnTriggerExit2D(Collider2D collision) {
        if(collision is BoxCollider2D){
            if(collision.gameObject.CompareTag("Player")){
                if(danoCoroutine != null){
                    StopCoroutine(danoCoroutine);
                    danoCoroutine = null;
                }
            }
        }
    }

    /*
    Método que verifica se o inimigo ainda tem vida, caso sim, retira a quantidade de danos causados.
    Caso não, ele morre.
    */
    public override IEnumerator DanoCaractere(int dano, float intervalo)
    {
        while(true){
            StartCoroutine(FlickerCaractere());

            pontosVida = pontosVida - dano;
            if(pontosVida <= float.Epsilon){
                int QuantidadeMortos = PlayerPrefs.GetInt("QuantidadeMortos",0) + 1;
                PlayerPrefs.SetInt("QuantidadeMortos",QuantidadeMortos);
                KillCaractere();
                 if(tipo == 2){
                     SceneManager.LoadScene("vitoria");
                 }
                break;
            }
            if(intervalo > float.Epsilon){
                yield return new WaitForSeconds(intervalo);
            }
            else{
                break;
            }
        }
    }

    public override void ResetCaractere(){
        pontosVida = inicioPontosDano;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
