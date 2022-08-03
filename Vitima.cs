using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitima : MonoBehaviour
{
    public GameObject Samgue;
    public int hp = 5;
    public int recompensa = 0;
    private Animator Animacao;
   

    void Start()
    {
      
        Animacao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision colisor)
    {
        if (colisor.gameObject.tag == "Bala")
        {


            Destroy(colisor.gameObject, 0.1f);
            GameObject Mancha = Instantiate(Samgue, transform.position, Quaternion.identity);
            Destroy(Mancha, 0.5f);
            hp--;
            if (hp == 0)
            {
               
                    
                    GerenciadorJogo GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
                    GC.RecebePontos(recompensa);
                    Destroy(this.gameObject, 1f);
              
            }

        }
    }

   
    
}
