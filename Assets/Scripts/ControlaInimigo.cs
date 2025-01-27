using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public float Velocidade = 5;
    
    public GameObject Jogador;
    void FixedUpdate()
    {
        Vector3 direcao = Jogador.transform.position - transform.position;

        float distancia = Vector3.Distance(Jogador.transform.position, transform.position);

        if (distancia > 2.5)
        {
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direcao.normalized * Velocidade * Time.deltaTime);

            Quaternion novaROtacao = Quaternion.LookRotation(direcao);
            GetComponent<Rigidbody>().MoveRotation(novaROtacao);
        }
    }
}
