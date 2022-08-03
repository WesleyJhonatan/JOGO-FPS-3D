using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    int zoom = 30;
    int normal = 60;
    float smooth = 5;
    private bool isZoomed = false;

    private GerenciadorJogo GJ;

    public GameObject FogoArma1;
    public GameObject FogoArma2;


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
            if (Input.GetButtonUp("Fire2"))
            {
                FogoArma1.SetActive(false);
                FogoArma2.SetActive(true);
                isZoomed = !isZoomed;
            }

            if (isZoomed)
            {
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
            }

            else
            {
                FogoArma1.SetActive(true);
                FogoArma2.SetActive(false);
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
            }
        }

    }
}
