using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour
{
    public GameObject Personagem;
    private GerenciadorJogo GJ;
    private Animator Animacao;
    public AudioSource zumbi;
    public AudioSource Explosao;
    public int vida = 10;
    public int recompensa = 0;
    public GameObject Samgue;

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
            if (Vector3.Distance(transform.position, Personagem.transform.position) < 20)
            {
                zumbi.volume = 0.42f;
                Animacao.SetBool("Andar", true);
                //transform.position = Vector3.MoveTowards(transform.position, Personagem.transform.position, +0.07f);
                transform.LookAt(Personagem.transform.position);


            }

            if (Vector3.Distance(transform.position, Personagem.transform.position) > 20)
            {
                zumbi.volume = 0;
                Animacao.SetBool("Andar", false);
            }

            if (Vector3.Distance(transform.position, Personagem.transform.position) < 20)
            {
                Vector3 Destino = new Vector3(Personagem.transform.position.x, 70.256f, Personagem.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, Destino, 0.07f);
                Animacao.SetBool("Andar", true);

            }

           
        }

        


    }

    void OnCollisionStay(Collision colisaoo)
    {
        if (colisaoo.gameObject.tag == "Player")
        {
            Animacao.SetBool("Andar", false);
            Animacao.SetBool("Ataque", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Animacao.SetBool("Ataque", false);
        }
    }

    public void Desativar()
    {
        GetComponent<MeshRenderer>().enabled = (false);
    }

    private void OnCollisionEnter(Collision colisor)
    {
        if (colisor.gameObject.tag == "Bala")
        {
            vida--;
            GameObject Mancha = Instantiate(Samgue, transform.position, Quaternion.identity);
            Destroy(Mancha, 0.5f);

            if (vida == 0)
            {
                GerenciadorJogo GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
                GJ.RecebePontos(recompensa);
                Animacao.SetBool("Andar", false);
                Animacao.SetBool("Ataque", false);
                Animacao.SetBool("Morte", true);
                Destroy(this.gameObject, 1f);
            }
        }


    }

    private void OnTriggerEnter(Collider colisao)
    {
        if (colisao.gameObject.tag == "Particula")
        {
                vida = 0;
                if (vida == 0)
                {
                    Explosao.volume = 1;
                    GerenciadorJogo GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
                    GJ.RecebePontos(recompensa);
                    Animacao.SetBool("Morte", true);
                    Destroy(this.gameObject, 1f);
                   
                }
        }
    }
}
