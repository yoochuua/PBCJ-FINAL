using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que representa a arma do jogador
/// </summary>
public class Armas : MonoBehaviour
{
    public GameObject municaoPrefab;        //armazena o prefab da municao
    static List<GameObject> municaoPiscina; //Pool de municao
    public int tamanhoPiscina;              //Tamano da Piscina
    public float velocidadeMunicao;         //Velocidade da municao

    bool atirando;                          //Flag que indica se o jogador esta atirando
    // [HideInInspector]
    //public Animator animator;

    Camera cameraLocal;                     //Armazena a camera local, usada para converter a posicao do mouse em coordenadas do mundo

    float slopePositivo;                    //Armazena o valor do slope positivo (diagonal da tela)
    float slopeNegativo;                    //Armazena o valor do slope negativo (diagonal da tela)

    /// <summary>
    /// Enum quadrante: identifica os 4 quadrantes da tela
    /// </summary>
    enum Quadrante
    {
        Leste,
        Sul,
        Oeste,
        Norte
    }

    /* Start is called before the first frame update*/
    private void Start()
    {
        //Inicializa variaveis e referencias
        atirando = false;
        cameraLocal = Camera.main;

        //Calcula slope positivo e negativo
        Vector2 abaixoEsquerda = cameraLocal.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 acimaDireita = cameraLocal.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 acimaEsquerda = cameraLocal.ScreenToWorldPoint(new Vector2(0, Screen.height));
        Vector2 abaixoDireita = cameraLocal.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        slopePositivo = PegaSlope(abaixoEsquerda, acimaDireita);
        slopeNegativo = PegaSlope(acimaEsquerda, abaixoDireita);
    }

    /* AcimaSlopePositivo(Vector2 posicaoEntrada)
        Retorna true se a posicao esta acima do slope positivo relativo ao eixo X do player
    */
    bool AcimaSlopePositivo(Vector2 posicaoEntrada)
    {
        Vector2 posicaoPlayer = gameObject.transform.position;
        Vector2 posicaoMouse = cameraLocal.ScreenToWorldPoint(posicaoEntrada);
        float interseccaoY = posicaoPlayer.y - (slopePositivo * posicaoPlayer.x);
        float entradaInterseccao = posicaoMouse.y - (slopePositivo * posicaoPlayer.x);
        return entradaInterseccao > interseccaoY;
    }

    /* AcimaSlopeNegativo(Vector2 posicaoEntrada)
        Retorna true se a posicao esta acima do slope negativo relativo ao eixo X do player
    */
    bool AcimaSlopeNegativo(Vector2 posicaoEntrada)
    {
        Vector2 posicaoPlayer = gameObject.transform.position;
        Vector2 posicaoMouse = cameraLocal.ScreenToWorldPoint(posicaoEntrada);
        float interseccaoY = posicaoPlayer.y - (slopeNegativo * posicaoPlayer.x);
        float entradaInterseccao = posicaoMouse.y - (slopeNegativo * posicaoPlayer.x);
        return entradaInterseccao > interseccaoY;
    }

    /* PegaQuadrante()
        Retorna o quadrante do mouse em relacao à tela
    */
    Quadrante PegaQuadrante()
    {
        Vector2 posicaoMouse = Input.mousePosition;
        Vector2 posicaoPlayer = transform.position;
        bool acimaSlopePositivo = AcimaSlopePositivo(posicaoMouse);
        bool acimaSlopeNegativo = AcimaSlopeNegativo(posicaoMouse);
        if (!acimaSlopePositivo && acimaSlopeNegativo)
        {
            return Quadrante.Leste;

        }
        else if (!acimaSlopePositivo && !acimaSlopeNegativo)
        {
            return Quadrante.Sul;
        }
        else if (acimaSlopePositivo && !acimaSlopeNegativo)
        {
            return Quadrante.Oeste;
        }
        else
        {
            return Quadrante.Norte;
        }
    }

    /* Awake is called when the script instance is being loaded */
    public void Awake()
    {
        if (municaoPiscina == null)
        {
            municaoPiscina = new List<GameObject>();
        }

        for (int i = 0; i < tamanhoPiscina; i++)
        {
            GameObject municaoO = Instantiate(municaoPrefab);
            municaoO.SetActive(false);
            municaoPiscina.Add(municaoO);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            atirando = true;
            DisparaMunicao();
        }
        UpdateEstado();

    }

    /* UpdateEstado()
        Atualiza o estado do jogador
    */
    private void UpdateEstado()
    {
        if (atirando)
        {
            Vector2 vetorQuadrante;
            Quadrante quadranteEnum = PegaQuadrante();
            switch (quadranteEnum)
            {
                case Quadrante.Leste:
                    vetorQuadrante = new Vector2(1.0f, 0.0f);
                    break;
                case Quadrante.Sul:
                    vetorQuadrante = new Vector2(0.0f, -1.0f);
                    break;
                case Quadrante.Oeste:
                    vetorQuadrante = new Vector2(-1.0f, 0.0f);
                    break;
                case Quadrante.Norte:
                    vetorQuadrante = new Vector2(0.0f, 1.0f);
                    break;
                default:
                    vetorQuadrante = new Vector2(0.0f, 0.0f);
                    break;
            }
            //animator.SetBool("Atirando", true);
            //animator.SetFloat("AtiraX", vetorQuadrante.x);
            //animator.SetFloat("AtiraY", vetorQuadrante.y);
            atirando = false;
        }
        else
        {
            //animator.SetBool("Atirando", false);
        }
    }

    /* PegaSlope()
        Calcula o slope entre dois pontos
    */
    float PegaSlope(Vector2 ponto1, Vector2 ponto2)
    {
        return (ponto2.y - ponto1.y) / (ponto2.x - ponto1.x);
    }

    /* SpawnMunicao(Vector3 posicao)
        Spawna uma municao na posicao passada
    */
    public GameObject SpawnMunicao(Vector3 posicao)
    {
        foreach (GameObject municao in municaoPiscina)
        {
            if (municao.activeSelf == false)
            {
                municao.SetActive(true);
                municao.transform.position = posicao;
                return municao;
            }
        }
        return null;
    }

    /*
        Método que dispara a munição
    */
    private void DisparaMunicao()
    {
        Vector3 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject municao = SpawnMunicao(transform.position);
        if (municao != null)
        {
            Arco arcoScript = municao.GetComponent<Arco>();
            float velocidadeArma1 = velocidadeMunicao;
            float duracaoTrajetoria = 1.0f / velocidadeArma1;
            StartCoroutine(arcoScript.ArcoTrajetoria(posicaoMouse, duracaoTrajetoria));


        }
    }

    /* OnDestroy is called when the behaviour is destroyed */
    private void OnDestroy()
    {
        municaoPiscina = null;
    }
}