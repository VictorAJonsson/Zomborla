using UnityEngine;

public class GeradorZumbis : MonoBehaviour
{

    public GameObject Zomborla;
    float contadorTempo = 0;
    public float TempoGerarZomborla = 1;
    void Start()
    {
        
    }

    void Update()
    {
        contadorTempo += Time.deltaTime;
        if(contadorTempo >= TempoGerarZomborla)
        {
            Instantiate(Zomborla, transform.position, transform.rotation);
            contadorTempo = 0;         
        }
        
    }
}
