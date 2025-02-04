using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public float Velocidade = 5;
    private GameObject Jogador;
    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        Jogador = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // Garantindo que o número gerado não ultrapasse os filhos disponíveis
        int geraTipoZumbi = Random.Range(0, transform.childCount);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }

    void FixedUpdate()
    {   
        if (Jogador == null) return;

        Vector3 direcao = Jogador.transform.position - transform.position;
        float distancia = direcao.magnitude;

        // Rotaciona o inimigo na direção do jogador
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        rb.MoveRotation(novaRotacao);

        if (distancia > 2.5f)
        {
            rb.MovePosition(rb.position + direcao.normalized * Velocidade * Time.deltaTime);
            animator.SetBool("Atacando", false);
        }
        else
        {
            animator.SetBool("Atacando", true);
        }
    }

    void AtacaJogador()
    {
        if (Jogador == null) return;
        
        Time.timeScale = 0;
        var jogadorScript = Jogador.GetComponent<ControlaJogador>();
        jogadorScript.TextSeFudeu.SetActive(true);
        jogadorScript.Vivo = false;
    }
}
