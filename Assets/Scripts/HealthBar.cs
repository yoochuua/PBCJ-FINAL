using UnityEngine;
using UnityEngine.UI;
///<summary> 
///Classe que controla o funcionamento da "HealthBar"
///</summary>
public class HealthBar : MonoBehaviour
{
    public PontosDano pontosDano; //objeto de leitura dos dados e quantos pontos tem o player
    public Player caractere; //receberá o objeto do player 
    public Image medidorImagem; //recebe a barra de medição
    public Text pdTexto; // Componente de texto que receberá o valor de pontos de dano
    float maxPontosDano; // armazena a quantidade de saude do player 

    /* Start is called before the first frame update*/
    void Start()
    {
        maxPontosDano = caractere.MaxPontosDano;

    }

    /*Update is called once per frame*/
    void Update()
    {
        //Se o personagem ainda existir, seta o medidor de vida do personagem e coloca a quantidade de vida no visor
        if (caractere != null)
        {
            medidorImagem.fillAmount = pontosDano.valor / maxPontosDano;
            pdTexto.text = "PD: " + (medidorImagem.fillAmount * 100);
        }
    }
}
