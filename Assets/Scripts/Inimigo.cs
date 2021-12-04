using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
///<summary> 
///Classe que controla os pontos de danos causados pelo inimigo
///</summary>
public class Inimigo : Caractere
{

    float pontosVida; // saúde do inimigo
    public int forcaDano; // poder de dano
    public int dropChance; // chance de dropar algum item
    public GameObject[] drop = { }; // array de itens que podem ser dropados
    Coroutine danoCoroutine; // coroutine que aplica dano
    public int tipo; // tipo do inimigo

    /* Start is called before the first frame update*/
    void Start()
    {

    }

    /* OnEnable is called when the object becomes enabled and active */
    private void OnEnable()
    {
        ResetCaractere();
    }

    /*
        Método que adicina danos ao player de acordo com o que foi setado em força dano quando ele entra em contato com o inimigo
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is BoxCollider2D)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Player player = collision.gameObject.GetComponent<Player>();
                if (danoCoroutine == null)
                {
                    danoCoroutine = StartCoroutine(player.DanoCaractere(forcaDano, 1.0f));
                }

            }
        }
    }

    /*
        Método que verifica se o player já não está mais em contato com o inimigo, caso não, ele para o dano
    */
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision is BoxCollider2D)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (danoCoroutine != null)
                {
                    StopCoroutine(danoCoroutine);
                    danoCoroutine = null;
                }
            }
        }
    }

    /*
        Co-rotina que aplica o dano:
        verifica se o inimigo ainda tem vida, caso sim, retira a quantidade de danos causados.
        Caso não, ele morre.
    */
    public override IEnumerator DanoCaractere(int dano, float intervalo)
    {
        while (true)
        {
            StartCoroutine(FlickerCaractere());

            pontosVida = pontosVida - dano;
            if (pontosVida <= float.Epsilon)
            {
                int QuantidadeMortos = PlayerPrefs.GetInt("QuantidadeMortos", 0) + 1;
                PlayerPrefs.SetInt("QuantidadeMortos", QuantidadeMortos);
                KillCaractere();
                DropO(gameObject.transform.position);
                if (tipo == 2)
                {
                    SceneManager.LoadScene("vitoria");
                }
                break;
            }
            if (intervalo > float.Epsilon)
            {
                yield return new WaitForSeconds(intervalo);
            }
            else
            {
                break;
            }
        }
    }

    /*
        Método que dropa um item aleatório no local do inimigo
    */
    public GameObject DropO(Vector3 posicao)
    {
        while (drop != null && Random.Range(0, 100) < dropChance)//Probabilidade de haver drops
        {
            return Instantiate(drop[Random.Range(0, drop.Length)], posicao, Quaternion.identity);
            dropChance = dropChance - (dropChance / 3);
        }
        return null;
    }

    /*
        Método que reseta o inimigo (faz override do método da classe Caractere)
    */
    public override void ResetCaractere()
    {
        pontosVida = inicioPontosDano;
    }
}
