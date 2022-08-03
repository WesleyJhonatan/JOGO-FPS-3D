using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancarGranadas : MonoBehaviour
{

    public Granada _granada;
    public Transform localDeLancamento;
    public float forcaDeLancamento = 10;
    public float numeroDeGranadas = 9;
    public float tempoPorLancamento = 0.5f;
    //
    float cronometroGranada = 0;
    bool lancouGranada = false;

    public int tiragranada;

    private bool pode = true;
    public int cont = 10;

 

    private void Start()
    {
        
    }
    void Update()
    {
       

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (pode == true)
                {
                    GerenciadorJogo GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
                    GJ.RecebeGranada(tiragranada);
                    cont--;
                }

                if (cont == 0)
                {
                    pode = false;
                }

                if (localDeLancamento && numeroDeGranadas >= 0 && !lancouGranada)
                {
                    numeroDeGranadas--;
                    lancouGranada = true;
                    Granada objGranada = Instantiate(_granada, localDeLancamento.position, transform.rotation) as Granada;
                    Rigidbody rbGranada = objGranada.GetComponent<Rigidbody>();
                    rbGranada.AddForce(Camera.main.transform.forward * forcaDeLancamento, ForceMode.Impulse);
                }
            }
            if (lancouGranada)
            {
                cronometroGranada += Time.deltaTime;
            }
            if (cronometroGranada >= tempoPorLancamento)
            {
                lancouGranada = false;
                cronometroGranada = 0;
            }
        }

        private void OnTriggerEnter(Collider colisao)
        {
            if (colisao.gameObject.tag == "RecargaGranada")
            {
                GerenciadorJogo GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
                GJ.granadas = 10;
                pode = true;
                cont = 10;
                numeroDeGranadas = 9;

            }

        }

    
}
