﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{

    public float Velocidade = 10;
    Vector3 direcao;

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
  }

  void FixedUpdate()
  {
    GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao * Velocidade * Time.deltaTime));

  }

}
