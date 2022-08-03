using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImunicao : MonoBehaviour
{
    private Text meuTexto;
    public Arma Arma;
    private GerenciadorJogo GJ;

    // Start is called before the first frame update
    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
        meuTexto = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            meuTexto.text = "Munição:" + Arma.municao.ToString() + "/50";
        }
    }
}
