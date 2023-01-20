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

    // Para que uma variável fique exposta para a Unity, precisamos da
    // palavra "public", antes da declaração da variável
    // (Valor da variável é opcional)
    // TIPO_VARIAVEL NOME_VARIAVEL = VALOR;
    // Tipos numéricos mais comuns: int (números inteiros) e
    // float (números decimais)
    // Lembrando que, no caso de variáveis públicas, o valor informado
    // é apenas o valor inicial. Depois que a Unity carregar, precisamos
    // alterar o valor pela Unity para que tenha efeito.
    public float speed = 2;

    // Definimos uma força inicial para o pulo
    // Podemos configurar essa força direto pela Unity, por conta
    // do "public"
    public float jumpForce = 150;

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
            h * speed,
            rb.velocity.y
        );

        // Precisamos detectar quando o jogador pretende pular
        // Para isso, vamos aguardar a tecla "Barra de espaço"
        // ser pressionada
        // No lugar de checar se apenas uma tecla foi pressionada,
        // podemos checar se um botão da Unity, foi pressionado
        // O botão "Jump", por exemplo, detecta, além da barra de
        // espaço, o botão A dos joysticks
        if (Input.GetButtonDown("Jump"))
        {
            // Adicionamos uma força no Rigidbody2D
            // Essa força será o resultado de Vector2.up * jumpForce
            // Vector2.up é equivalente a new Vector2(0, 1), ou seja,
            // 0 no X e 1 no Y
            // Multiplicando o Vector2 por um float, temos um novo
            // Vector2, com o valor aplicado.
            // Portanto, o novo Vector2 será equivalente a:
            // new Vector2(0 * jumpForce, 1 * jumpForce)
            // Simplificando, temos:
            // new Vector2(0, jumpForce);
            // Com o Vector2 calculado, passamos ao AddForce
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
