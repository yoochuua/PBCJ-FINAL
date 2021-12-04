using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
///<summary> 
///Classe abstrata que indica caracteristicas similares dos personagens
///</summary>
public abstract class Caractere : MonoBehaviour
{
    public float inicioPontosDano; // valor minimo inicial de saude do player 
    public float MaxPontosDano; // valor maximo permitido de saude
    public int QuantidadeMortosTotal;
    public abstract void ResetCaractere(); //caractere volta
    
    /* 
        Coroutine que faz o caractere piscar quando toma dano
    */ 
    public virtual IEnumerator FlickerCaractere()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    /* IEnumerator DanoCaractere(int dano, float intervalo);
        Coroutine que aplica dano ao caractere
    */
    public abstract IEnumerator DanoCaractere(int dano, float intervalo);

    /*
        Metodo que tira o personagem de cena caso ele morra
    */
    public virtual void KillCaractere(){
        Destroy(gameObject);
    }
}
