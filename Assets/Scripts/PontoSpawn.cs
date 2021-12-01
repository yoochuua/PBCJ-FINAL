using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<sumary> Classe que define o funcionamento dos "SpawnPoints"

public class PontoSpawn : MonoBehaviour
{
    public GameObject[] prefabParaSpawn = {};

    public float intervaloRepeticao;
    
    private Vector3 posicaoDeSpawn;

    // Start is called before the first frame update
    void Start()
    {   
        if(intervaloRepeticao > 0){
            InvokeRepeating("SpawnO", 0.0f, intervaloRepeticao);
        }
    }

    public GameObject SpawnO(){
        if(prefabParaSpawn != null){
            return Instantiate(prefabParaSpawn[Random.Range(0, prefabParaSpawn.Length)], EscolheLocalSpawn(), Quaternion.identity);
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* 
        Retorna uma posição de Spawn aleatória
    */
    public Vector3 EscolheLocalSpawn(){
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
