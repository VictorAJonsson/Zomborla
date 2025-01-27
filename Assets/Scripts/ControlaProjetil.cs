using UnityEngine;

public class ControlaProjetil : MonoBehaviour
{
    public float Velocidade = 20;
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (transform.forward * Velocidade * Time.deltaTime));
    }
}
