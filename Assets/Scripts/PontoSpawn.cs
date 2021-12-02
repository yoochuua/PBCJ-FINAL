using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<sumary> Classe que define o funcionamento dos "SpawnPoints"

public class PontoSpawn : MonoBehaviour
{
    public GameObject[] prefabParaSpawn = {};

    public float intervaloRepeticao;
    
    private Vector3 posicaoDeSpawn;
     int quantidadeInimigos;
     int quantidadeInimigosTotal;
    int QuantidadeMortos; 
    // Start is called before the first frame update
    void Start()
    {   
         quantidadeInimigos = 1;
         quantidadeInimigosTotal = 1;
         for(int i = 0 ; i< quantidadeInimigos; i++){
            // if(intervaloRepeticao > 0){
            //     InvokeRepeating("SpawnO", 0.0f, 0);
            // }
            SpawnO();
         }

    }

    public GameObject SpawnO(){
        if(prefabParaSpawn != null ){
            return Instantiate(prefabParaSpawn[Random.Range(0, prefabParaSpawn.Length)], EscolheLocalSpawn(), Quaternion.identity);
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        QuantidadeMortos = PlayerPrefs.GetInt("QuantidadeMortos",0);
        if(quantidadeInimigosTotal == QuantidadeMortos){
            int quantidadeRounds = PlayerPrefs.GetInt("Round",0) + 1;
           
            quantidadeInimigos++;
            quantidadeInimigosTotal = QuantidadeMortos + quantidadeInimigos;
            PlayerPrefs.SetInt("Round",quantidadeRounds);
            for(int i = 0 ; i< quantidadeInimigos; i++)
            {
                SpawnO();
            }
            
        }
        
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
