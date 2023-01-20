using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Precisamos obter o Rigidbody 2D que está no GameObject do Player
    // Para isso, precisamos definir uma variável que seja acessada tanto
    // pelo Start(), quanto pelo Update()

    // Para declarar uma variável na C#, utilizamos a seguinte estrutura:
    // TIPO_VARIAVEL NOME_VARIAVEL;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Como o Rigidbody2D está no mesmo objeto de jogo que o script Player está,
        // podemos utilizar a declaração GetComponent<TIPO_COMPONENTE>() para obter
        // o Rigidbody do jogador em si
        rb = GetComponent<Rigidbody2D>();
        print(rb);
    }

    // Update is called once per frame
    void Update()
    {
        // Para aplicar uma movimentação lateral,
        // devemos mover o eixo X.
        // Além disso, precisamos detectar se o jogador
        // está pressionando as setas esquerda/direita
        // Para isso, a Unity tem a declaração:
        // Input.GetAxis("EIXO_ESCOLHIDO")
        // Os eixos disponíveis são:
        // - Horizontal
        // - Vertical
        // Quando utilizamos Input.GetAxis("Horizontal"),
        // o valor recebido é um número entre -1 e 1
        // -1 -> Setinha para esquerda está sendo pressionada
        // 1 -> Setinha para direita está sendo pressionada

        var h = Input.GetAxis("Horizontal");

        // Com o valor da direção do movimento, que foi obtido
        // a partir das setinhas pressionadas, vamos aplicá-lo
        // na velocidade do Rigidbody2D
        // Fazemos isso através da declaração: rb.velocity
        // Como a velocidade de um Rigidbody2D é medida
        // em dois eixos: X (laterais) e y (cima/baixo),
        // precisamos utilizar um Vector2, que tem x e y
        rb.velocity = new Vector2(
            h,
            rb.velocity.y
        );
    }
}
