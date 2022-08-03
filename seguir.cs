using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguir : MonoBehaviour
{
    public GameObject Alvo;

    private GerenciadorJogo GJ;

    // Start is called before the first frame update
    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Alvo.transform.position, 0.03f);
        }
          
    }
}
