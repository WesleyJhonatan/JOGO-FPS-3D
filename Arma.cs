using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Arma : MonoBehaviour
{

    public GameObject Bala;

    public GameObject CorpoHumano;

    public GameObject PontoSaida;

    public float velocidade;

    public Animator arma;

    public int municao = 50;

    private GerenciadorJogo GJ;

    public float Delay = 50;

    public float tempo = 0;

    public GameObject FogoArma;
    public float tempo2 = 0;

    //private Animator Animacao;



    // Start is called before the first frame update
    void Start()
    {
        //Animacao = GetComponent<Animator>();
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)

        {
            if (Input.GetButton("Fire1") && municao > 0)
            {
                tempo += Time.deltaTime;
                if (tempo >= 0.2)
                {
                    //Debug.Log("foi");
                    tempo = 0;

                    municao--;

                    GameObject Tiro = Instantiate(Bala, PontoSaida.transform.position, CorpoHumano.transform.rotation);

                    //pegar o corpo da bala 
                    Rigidbody CorpoBala = Tiro.GetComponent<Rigidbody>();

                    //Dar velocidade para bala -> na direção de onde meu corpo aponta
                    CorpoBala.AddForce(CorpoHumano.transform.forward * velocidade);
                 
                    //destroi bala
                    Destroy(Tiro, 0.8f);

                    tempo2 += Time.deltaTime;
                    if (tempo2 >= 0.09f)
                    {
                        tempo2 = 0;
                        FogoArma.SetActive(true);
                    }
                        
                }


                

            }

            if (Input.GetButtonUp("Fire1"))
            {
                FogoArma.SetActive(false);
            }



        }

        
    }

   
}
