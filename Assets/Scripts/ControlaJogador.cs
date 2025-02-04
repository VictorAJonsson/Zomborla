using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{

    public float Velocidade = 10;
    Vector3 direcao;
    public LayerMask MascaraChao;
    public GameObject TextSeFudeu;
    public bool Vivo = true;

    private void Start()
    {
      Time.timeScale = 1;
    }

    void Update()
    {
		float eixoX = Input.GetAxis("Horizontal");
		float eixoZ = Input.GetAxis("Vertical");

		direcao = new Vector3(eixoX, 0, eixoZ);

    if(direcao != Vector3.zero)
    {
      GetComponent<Animator>().SetBool("Andando", true);
    }
    else
    {
      GetComponent<Animator>().SetBool("Andando", false);
    }

    if(Vivo == false)
    {
      if(Input.GetButton("Fire1"))
      {
        SceneManager.LoadScene("game");
        Time.timeScale = 1;
        Vivo = true;
        TextSeFudeu.SetActive(false);
      }
    }
  }

  void FixedUpdate()
  {
    GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao * Velocidade * Time.deltaTime));

    Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
    Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

    RaycastHit impacto;

    if(Physics.Raycast(raio, out impacto, 100, MascaraChao))
    {
      Vector3 posicaoMiraJogador = impacto.point - transform.position;

      posicaoMiraJogador.y = transform.position.y;

      Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

      GetComponent<Rigidbody>().MoveRotation(novaRotacao);
    }
  }

}
