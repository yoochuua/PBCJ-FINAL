using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<sumary> Classe que define o funcionamento dos "SpawnPoints"

public class PontoSpawn : MonoBehaviour
{
    public GameObject[] prefabParaSpawn = {};

    public float intervaloRepeticao; 
    
    private Vector3 posicaoDeSpawn;        // Guarda posição do "Spawn"
    int spawnRate;                  // Quantidade de inimigos em um determinado round
    int spawnedEnemyCount;          // Quantidade de inimigos spawnados até agora
    int quantidadeMortos;           // Guarda a quantidade de inimigos mortos

    // Start is called before the first frame update
    void Start()
    {   
        spawnRate = 1;
        spawnedEnemyCount = 1;
        for(int i = 0 ; i < spawnRate; i++){
            SpawnO();
        }
        // if(intervaloRepeticao > 0){
        //     InvokeRepeating("SpawnO", 0.0f, 0);
        // }

    }

    /*
        Função que instancia um novo objeto com base em uma prefab em uma posição Vector3
    */
    public GameObject SpawnO(){
        if(prefabParaSpawn != null ){
            return Instantiate(prefabParaSpawn[Random.Range(0, prefabParaSpawn.Length)], EscolheLocalSpawn(), Quaternion.identity);
        }
        return null;
    }
    int c = 0;
    // Update is called once per frame
    void Update()
    {
        quantidadeMortos = PlayerPrefs.GetInt("QuantidadeMortos",0);
        if(quantidadeMortos == spawnedEnemyCount){
            
            spawnRate++;
            spawnedEnemyCount += spawnRate;
            
            for(int i = 0 ; i< spawnRate; i++)
            {
                SpawnO();
            }
            
            int roundAtual = PlayerPrefs.GetInt("Round", 0) + 1;
            PlayerPrefs.SetInt("Round", roundAtual);
            
            print("novo round!" + c);
            print(PlayerPrefs.GetInt("Round", 0));
            print(roundAtual);
            c++;
            
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
