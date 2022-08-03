using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorJogo : MonoBehaviour
{
    // verifica se o jogo esta ligado ou não

    public bool GameLigado = false;

    // Chama tela de game oveer
    public GameObject TelaGameOver;

    //  tela menu
    public GameObject TelaMenu;


    // tela ganhador
    public GameObject TelaGanhador;

    // tela Pause
    public GameObject TelaPause;

    public int pontos;

    public int granadas = 10;

    public AudioSource SomFase;

    public AudioSource SomAndarpara;

    private GerenciadorJogo GJ;

    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
        //Pausa o Script

        GameLigado = false;

        //  Pausa fisica do Jogo

        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        

            {
                if (Input.GetKey(KeyCode.Escape))
                {
                
                    Cursor.visible = true;
                    GameLigado = false;
                    Time.timeScale = 0;
                    TelaPause.SetActive(true);
                    TelaMenu.SetActive(false);
                }
            }

    }

    public bool EstadoDoJogo()
    {

        return GameLigado;

    }

    public void LigarJogo()

    {
        Cursor.visible = false;
        GameLigado = true;
        Time.timeScale = 1;

    }

    public void PersonagemMorreu()

    {
        //Tela de Game Over
        Cursor.visible = true;
        TelaGameOver.SetActive(true);
        GameLigado = false;
        Time.timeScale = 0;

    }

    public void BTGameOver()
    {
        TelaMenu.SetActive(true);
        TelaGameOver.SetActive(false);
        GameLigado = false;
        Time.timeScale = 0;
        SceneManager.LoadScene(0);
    }

    public void BTVencedor()
    {
        TelaMenu.SetActive(true);
        TelaGanhador.SetActive(false);
        GameLigado = false;
        Time.timeScale = 0;
        SceneManager.LoadScene(0);
    }


    public void RecebePontos(int ponto)
    {
        pontos = pontos + ponto;

        if (pontos >= 1000)
        {
            PersonagemGanhou();
        }
    }

    public void RecebeGranada(int granada)
    {
        granadas = granadas + granada;
    }
    public int RetornaPontos()
    {
        return pontos;
    }

    public int RetornaGranadas()
    {
            return granadas;
        
    }

    public void BTSair()
    {
        Application.Quit();

    }

    public void TiraPausaJogo()

    {
        Cursor.visible = false;
        GameLigado = true;
        Time.timeScale = 1;
        TelaPause.SetActive(false);

    }


    public void BTVoltarMenu()
    {
        GameLigado = false;
        Time.timeScale = 0;
        TelaMenu.SetActive(true);

        SceneManager.LoadScene(0);
        Time.timeScale = 0;
    }


    public void PersonagemGanhou()
    {
        SomAndarpara.volume = 0;
        SomFase.volume = 0;
        TelaGanhador.SetActive(true);
        GameLigado = false;
        Time.timeScale = 0;

    }

   

}