using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary> 
///Classe que controla o funcionamento da movimentação do jogador
///</summary>
public class MovimentaPlayer : MonoBehaviour
{
    public float VelocidadeMovimento = 3.0f;    // equivale ao momento (impulso) a ser dado ao player
    Vector2 Movimento = new Vector2();          // detectar movimento pelo teclado

    Animator animator;  // guarda a componente do Controlador de Animação
    // string estadoAnimacao = "EstadoAnimacao";   // guarda o nome do parâmetro de Animação
    Rigidbody2D rb2D;   // guarda a componente CorpoRígido do Player

    /*enum EstadosCaractere{
        andaLeste = 1,
        andaOeste = 2,
        andaNorte = 3,
        andaSul = 4,
        idle = 5
    }*/

    enum EstadoCaractere
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEstado();
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    private void FixedUpdate()
    {
        MoveCaractere();
    }
    /* Método para a movimentação de caractere*/
    private void MoveCaractere()
    {
        Movimento.x = Input.GetAxisRaw("Horizontal");
        Movimento.y = Input.GetAxisRaw("Vertical");
        Movimento.Normalize();
        rb2D.velocity = Movimento * VelocidadeMovimento;
    }

    /* Método para atualizar o estado do caractere*/
    private void UpdateEstado()
    {
        /*
        if (Movimento.x > 0){
            animator.SetInteger(estadoAnimacao, (int)EstadosCaractere.andaLeste);
        }
        else if (Movimento.x < 0){
            animator.SetInteger(estadoAnimacao, (int)EstadosCaractere.andaOeste);
        }
        else if (Movimento.y > 0){
            animator.SetInteger(estadoAnimacao, (int)EstadosCaractere.andaNorte);
        }
        else if (Movimento.y < 0){
            animator.SetInteger(estadoAnimacao, (int)EstadosCaractere.andaSul);
        }
        else{
            animator.SetInteger(estadoAnimacao, (int)EstadosCaractere.idle);
        }*/

        animator.SetBool("Caminhando", !(Mathf.Approximately(Movimento.x, 0) && Mathf.Approximately(Movimento.y, 0)));
        animator.SetFloat("dirX", Movimento.x);
        animator.SetFloat("dirY", Movimento.y);

    }

    public void incrementaVelocidade(float soma){
        VelocidadeMovimento += soma;
    }
}
