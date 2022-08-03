using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float velocidadeHorizontal = 2.0F;

    public float velocidadeVertical = 2.0F;

    private float h = 0;

    private float v = 0;

    private GerenciadorJogo GJ;
    void Start()
    {

        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();

    }



    void Update()
    {

        if (GJ.EstadoDoJogo() == true)

        {
            h += velocidadeHorizontal * Input.GetAxis("Mouse X");

            v -= velocidadeVertical * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(0, h, 0);

        }


    }

}

