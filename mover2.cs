using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;





public class mover2 : MonoBehaviour
{

    public float velF;
    public float velL;

    private float velocidadeAnima = 0;

    private Animator Animacao;

    private Rigidbody Corpo;

    public AudioSource Andar;

    public GameObject Recarga2;

    public Arma Arma;

    public int hp = 0;

    private float tempo2 = 0;

    private float tempo3 = 0;

    //vida do personagem

    public int vida = 10;

    public int chances = 3;

    public List<GameObject> Chancesvidas;

    private float meutempoDano = 0;

    private bool podeDano = true;

    //Barra de HP

    private Image BarraHp;

    private int vidabarra;

    private GerenciadorJogo GJ;

    public List<GameObject> Coracoes;

   

    void Start()
    {
        Animacao = GetComponent<Animator>();
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
        BarraHp = GameObject.FindGameObjectWithTag("hpbarra").GetComponent<Image>();
        Corpo = GetComponent<Rigidbody>();
      


    }


    void Update()
    {
        if (GJ.EstadoDoJogo() == true)

        {
            float velocidade = Input.GetAxis("Vertical");
            velF = velocidade * 5;


            float velocidadelateral = Input.GetAxis("Horizontal");
            velL = velocidadelateral * 5;

            if (velF == 0)
            {
                
                Animacao.SetBool("Run", false);

                tempo2 += Time.deltaTime;
                if (tempo2 >= 10)
                {
                    Recarga2.SetActive(false);
                    //Animacao.SetBool("Granada", false);
                   


                }
            }

            if (velL == 0)
            {
              
                Animacao.SetBool("Run", false);

                tempo2 += Time.deltaTime;
                if (tempo2 >= 10)
                {
                    Recarga2.SetActive(false);
                    //Animacao.SetBool("Granada", false);
                    

                }
            }

            if (Input.GetKey(KeyCode.W))
            {
                
                Animacao.SetBool("Run", true);

                tempo2 += Time.deltaTime;
                if (tempo2 >= 10)
                {
                    Recarga2.SetActive(false);
                   // Animacao.SetBool("Granada", false);
                    Animacao.SetBool("Recarga", false);
                    tempo2 = 0;

                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                
                Animacao.SetBool("Run", true);

                tempo2 += Time.deltaTime;
                if (tempo2 >= 10)
                {
                    Recarga2.SetActive(false);
                   // Animacao.SetBool("Granada", false);
                    Animacao.SetBool("Recarga", false);
                    tempo2 = 0;

                }
            }

            if (Input.GetKey(KeyCode.A))
            {
               
                Animacao.SetBool("Run", true);

                tempo2 += Time.deltaTime;
                if (tempo2 >= 10)
                {
                    Recarga2.SetActive(false);
                   // Animacao.SetBool("Granada", false);
                    Animacao.SetBool("Recarga", false);
                    tempo2 = 0;

                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                
                Animacao.SetBool("Run", true);

                tempo2 += Time.deltaTime;
                if (tempo2 >= 10)
                {
                    Recarga2.SetActive(false);
                  //  Animacao.SetBool("Granada", false);
                    Animacao.SetBool("Recarga", false);
                    tempo2 = 0;

                }
            }

            if (Input.GetButton("Fire2"))
            {
                Animacao.SetBool("Run", false);
               // Animacao.SetBool("Granada", false);
                Animacao.SetBool("Recarga", false);
                Animacao.SetBool("Aim", true);

                if (tempo2 >= 10)
                {
                    Recarga2.SetActive(false);

                }
            }

            if (Input.GetButtonUp("Fire2"))
            {
                Animacao.SetBool("Run", false);
               // Animacao.SetBool("Granada", false);
                Animacao.SetBool("Recarga", false);
                Animacao.SetBool("Aim", false);

                if (tempo2 >= 10)
                {
                    Recarga2.SetActive(false);

                }
            }

            if (Input.GetButton("Fire1"))
            {
                Animacao.SetBool("Aim", true);
                Animacao.SetBool("Run", false);

                tempo2 += Time.deltaTime;
                if (tempo2 >= 10)
                {
                    Recarga2.SetActive(false);
                    Animacao.SetBool("Recarga", false);
                    //Animacao.SetBool("Granada", false);
                    tempo2 = 0;

                }
            }

            if (Input.GetButtonUp("Fire1"))
            {
                Animacao.SetBool("Aim", false);
               // Animacao.SetBool("Granada", false);
                Animacao.SetBool("Run", false);

                if (tempo2 >= 10)
                {
                    Recarga2.SetActive(false);

                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Animacao.SetBool("Recarga", false);
                Animacao.SetBool("Granada", true);
                
            }

            if (Input.GetKeyUp(KeyCode.Q))
            {
                tempo2 += Time.deltaTime;
                if (tempo2 >= 1)
                {
                    Animacao.SetBool("Granada", false);
                }
                

            }

            Corpo.velocity = transform.forward * (velF) + transform.right * velL;
            float volsom = velocidade;

            if (volsom < 0)
            {

                volsom = volsom * -1;

            }
            Andar.volume = volsom;

            //condição de tirar dano
            if (hp > 0)
            {
                LimpaDano();
            }

            Dano();
        }

    }

    private void OnTriggerEnter(Collider colisao)
    {
        if (colisao.gameObject.tag == "Municao")
        {
          
            if (colisao.gameObject.GetComponent<Recarga>().ativa == true)
            {
                Recarga2.SetActive(true);
                Animacao.SetBool("Granada", false);
                Animacao.SetBool("Aim", false);
                Animacao.SetBool("Run", false);
                Animacao.SetBool("Recarga", true);
                

                Arma.municao = 50;
                colisao.gameObject.GetComponent<Recarga>().Desativar();

            }


        }

        if (colisao.gameObject.tag == "RecargaGranada")
        {

            if (colisao.gameObject.GetComponent<RecargaGranada>().ativa == true)
            {
                //Arma.municao = 50;
                colisao.gameObject.GetComponent<RecargaGranada>().Desativar();

            }


        }



    }



    void LimpaDano()
    {
        tempo3 += Time.deltaTime;
        if (tempo2 >= 10)
        {
            hp = 0;
            tempo3 = 0;

        }
    }

    void Dano()
    {
        if (podeDano == false)
        {
            temporizadorDano();
        }
    }

    //Dano
    void OnCollisionStay(Collision colisaoo)
    {
        if (colisaoo.gameObject.tag == "Zombie")
        {
            if (podeDano == true)
            {
                if(vida <= 0)
                {
                    chances--;

                    if(chances == 2)
                    {

                        vida = 10;
                    }

                    if (chances == 1)
                    {

                        vida = 10;
                    }

                    switch (chances)
                    {

                        case 0:
                            Chancesvidas[0].SetActive(false);
                            Chancesvidas[1].SetActive(false);
                            Chancesvidas[2].SetActive(false);
                            break;
                        case 1:
                            Chancesvidas[0].SetActive(true);
                            Chancesvidas[1].SetActive(false);
                            Chancesvidas[2].SetActive(false);
                            break;

                        case 2:
                            Chancesvidas[0].SetActive(false);
                            Chancesvidas[1].SetActive(true);
                            Chancesvidas[2].SetActive(false);
                            break;

                        case 3:
                            Chancesvidas[0].SetActive(false);
                            Chancesvidas[1].SetActive(false);
                            Chancesvidas[2].SetActive(true);
                            break;
                    }

                    if (chances <= 0)
                    {

                        GJ.PersonagemMorreu();
                    }

                   

                }
                vida--;
                podeDano = false;
                PerderHP();
                MostrarCoracao();
            }
           
            

        }
    }

    void temporizadorDano()

        {
            meutempoDano += Time.deltaTime;
            if (meutempoDano > 1f)
            {
               
                podeDano = true;
                meutempoDano = 0;
                
            }
        }

   void PerderHP()
    {
        float vida_parabarra = vida * 10;
        BarraHp.rectTransform.sizeDelta = new Vector2(vida_parabarra, 30);
    }

     void MostrarCoracao()
    {
       
        switch (vida)
        {
            
            case 0:
                Coracoes[0].SetActive(false);
                Coracoes[1].SetActive(false);
                Coracoes[2].SetActive(false);
                Coracoes[3].SetActive(false);
                Coracoes[4].SetActive(false);
                Coracoes[5].SetActive(false);
                Coracoes[6].SetActive(false);
                Coracoes[7].SetActive(false);
                Coracoes[8].SetActive(false);
                Coracoes[9].SetActive(false);

                break;

                

            case 1:
                Coracoes[0].SetActive(true);
                Coracoes[1].SetActive(false);
                Coracoes[2].SetActive(false);
                Coracoes[3].SetActive(false);
                Coracoes[4].SetActive(false);
                Coracoes[5].SetActive(false);
                Coracoes[6].SetActive(false);
                Coracoes[7].SetActive(false);
                Coracoes[8].SetActive(false);
                Coracoes[9].SetActive(false);

                break;
            case 2:
                Coracoes[0].SetActive(true);
                Coracoes[1].SetActive(true);
                Coracoes[2].SetActive(false);
                Coracoes[3].SetActive(false);
                Coracoes[4].SetActive(false);
                Coracoes[5].SetActive(false);
                Coracoes[6].SetActive(false);
                Coracoes[7].SetActive(false);
                Coracoes[8].SetActive(false);
                Coracoes[9].SetActive(false);

                break;

            case 3:
                Coracoes[0].SetActive(true);
                Coracoes[1].SetActive(true);
                Coracoes[2].SetActive(true);
                Coracoes[3].SetActive(false);
                Coracoes[4].SetActive(false);
                Coracoes[5].SetActive(false);
                Coracoes[6].SetActive(false);
                Coracoes[7].SetActive(false);
                Coracoes[8].SetActive(false);
                Coracoes[9].SetActive(false);

                break;

            case 4:
                Coracoes[0].SetActive(true);
                Coracoes[1].SetActive(true);
                Coracoes[2].SetActive(true);
                Coracoes[3].SetActive(true);
                Coracoes[4].SetActive(false);
                Coracoes[5].SetActive(false);
                Coracoes[6].SetActive(false);
                Coracoes[7].SetActive(false);
                Coracoes[8].SetActive(false);
                Coracoes[9].SetActive(false);

                break;
            case 5:
                Coracoes[0].SetActive(true);
                Coracoes[1].SetActive(true);
                Coracoes[2].SetActive(true);
                Coracoes[3].SetActive(true);
                Coracoes[4].SetActive(true);
                Coracoes[5].SetActive(false);
                Coracoes[6].SetActive(false);
                Coracoes[7].SetActive(false);
                Coracoes[8].SetActive(false);
                Coracoes[9].SetActive(false);


                break;
            case 6:
                Coracoes[0].SetActive(true);
                Coracoes[1].SetActive(true);
                Coracoes[2].SetActive(true);
                Coracoes[3].SetActive(true);
                Coracoes[4].SetActive(true);
                Coracoes[5].SetActive(true);
                Coracoes[6].SetActive(false);
                Coracoes[7].SetActive(false);
                Coracoes[8].SetActive(false);
                Coracoes[9].SetActive(false);


                break;
            case 7:
                Coracoes[0].SetActive(true);
                Coracoes[1].SetActive(true);
                Coracoes[2].SetActive(true);
                Coracoes[3].SetActive(true);
                Coracoes[4].SetActive(true);
                Coracoes[5].SetActive(true);
                Coracoes[6].SetActive(true);
                Coracoes[7].SetActive(false);
                Coracoes[8].SetActive(false);
                Coracoes[9].SetActive(false);
                

                break;
            case 8:
                Coracoes[0].SetActive(true);
                Coracoes[1].SetActive(true);
                Coracoes[2].SetActive(true);
                Coracoes[3].SetActive(true);
                Coracoes[4].SetActive(true);
                Coracoes[5].SetActive(true);
                Coracoes[6].SetActive(true);
                Coracoes[7].SetActive(true);
                Coracoes[8].SetActive(false);
                Coracoes[9].SetActive(false);
               

                break;
            case 9:
                Coracoes[0].SetActive(true);
                Coracoes[1].SetActive(true);
                Coracoes[2].SetActive(true);
                Coracoes[3].SetActive(true);
                Coracoes[4].SetActive(true);
                Coracoes[5].SetActive(true);
                Coracoes[6].SetActive(true);
                Coracoes[7].SetActive(true);
                Coracoes[8].SetActive(true);
                Coracoes[9].SetActive(false);
               

                break;
            case 10:
                Coracoes[0].SetActive(true);
                Coracoes[1].SetActive(true);
                Coracoes[2].SetActive(true);
                Coracoes[3].SetActive(true);
                Coracoes[4].SetActive(true);
                Coracoes[5].SetActive(true);
                Coracoes[6].SetActive(true);
                Coracoes[7].SetActive(true);
                Coracoes[8].SetActive(true);
                Coracoes[9].SetActive(true);
               

                break;


        }

    }

   
}
