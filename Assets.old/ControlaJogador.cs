using System.Runtime.CompilerServices;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    public float Velocidade = 10;

    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(eixoX, 0, eixoZ);

        transform.Translate(direcao * Velocidade * Time.deltaTime);
    }
}
