using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary> 
///Função que controla o spawn dos itens pelo mapa
///</summary>
public class SpawnItens : MonoBehaviour
{
    public GameObject[] prefabParaSpawn = { }; // Array de objetos que serão spawnados
    private Vector3 posicaoDeSpawn;           // Guarda posição do "Spawn"
    public float intervaloRepeticao;          // Intervalo de tempo entre spawn

    // Start is called before the first frame update
    void Start()
    {
        if (intervaloRepeticao > 0)
        {
            InvokeRepeating("SpawnO", 0.0f, intervaloRepeticao);
        }
    }

    /*
        Função que instancia um novo objeto com base em uma prefab em uma posição Vector3
    */
    public GameObject SpawnO() 
    {
        if (prefabParaSpawn != null)
        {
            return Instantiate(prefabParaSpawn[Random.Range(0, prefabParaSpawn.Length)], EscolheLocalSpawn(), Quaternion.identity);
        }
        return null;
    }

    /* 
        Retorna uma posição de Spawn aleatória
    */
    public Vector3 EscolheLocalSpawn()
    {
        float[] limitesDoMapa = {
            -19.4f,  // Limite Min X
            25.44f,  // Limite Max X
            5.65f,   // Limite Min Y
            23.28f   // Limite Max Y
        };
        float xAleatorio = Random.Range(limitesDoMapa[0], limitesDoMapa[1]);
        float yAleatorio = Random.Range(limitesDoMapa[2], limitesDoMapa[3]);
        posicaoDeSpawn = new Vector3(xAleatorio, yAleatorio, 0.0f);
        return posicaoDeSpawn;
    }
}
