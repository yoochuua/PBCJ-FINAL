using System.Collections.Generic;
using System.Collections;
using UnityEngine;
///<summary> 
///Classe que controla o comportamento dos tiros
///</summary>

public class Munição : MonoBehaviour
{
    public int danoCausado; //Poder de dano causado

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is BoxCollider2D)
        {
            Inimigo inimigo = collision.gameObject.GetComponent<Inimigo>();
            StartCoroutine(inimigo.DanoCaractere(danoCausado, 0.0f));
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
