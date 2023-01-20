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

    }
}
