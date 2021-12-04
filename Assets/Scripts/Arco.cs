using System.Collections;
using UnityEngine;

///<summary> 
/// Classe referente ao arco utilizado pelo personagem
///</summary>
public class Arco : MonoBehaviour
{
    /* Método que controla a trajetória do arco
    */
    public IEnumerator ArcoTrajetoria(Vector3 destino, float duracao) //Trajet�ria da muni��o
    {
        var posicaoInicial = transform.position;
        var percentualCompleto = 0.0f;
        while (percentualCompleto < 1.0f)
        {
            percentualCompleto += Time.deltaTime / duracao;
            //var alturaCorrente = Mathf.Sin(Mathf.PI * percentualCompleto);
            transform.position = Vector3.Lerp(posicaoInicial, destino, percentualCompleto); //+ Vector3.up*alturaCorrente;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
