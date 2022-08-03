using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecargaGranada : MonoBehaviour
{
    public bool ativa = true;
    public float tempo = 0;

    private GerenciadorJogo GJ;

    private Animator Animacao;

    // Start is called before the first frame update
    void Start()
    {
        Animacao = GetComponent<Animator>();
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)

        {
            if (ativa == false)
            {
                Reativar();
            }
        }
    }

    void Reativar()
    {

        tempo += Time.deltaTime;

        if (tempo >= 5)
        {
            ativa = true;
            tempo = 0;
            GetComponent<SkinnedMeshRenderer>().enabled = true;

        }
    }

    public void Desativar()
    {
        GetComponent<SkinnedMeshRenderer>().enabled = (false);
        ativa = false;
    }


}