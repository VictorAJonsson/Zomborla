using Unity.VisualScripting;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    public GameObject Projetil;
    public GameObject CanoDaArma;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Projetil, CanoDaArma.transform.position, CanoDaArma.transform.rotation);
        }
    }
}
