using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIHP : MonoBehaviour
{
    public mover2 Corpo;
    public float dano;
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
            dano = Corpo.hp * 0.1f;
            GetComponent<Image>().color = new Vector4(1, 1, 1, dano);
        }
    }
}
