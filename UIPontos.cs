using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIPontos : MonoBehaviour
{
    private Text meuTexto;
    private GerenciadorJogo GC;

   
    // Start is called before the first frame update
    void Start()
    {
        meuTexto = GetComponent<Text>();
        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GC.EstadoDoJogo() == true)
        {
            meuTexto.text = "Pontos:" + GC.RetornaPontos().ToString() + "/1000";
        }
    }

 
}
