using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alvo : MonoBehaviour
{

    public GameObject Sangue;
    private GerenciadorJogo GJ;

    // Start is called before the first frame update
    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<GerenciadorJogo>();
    }

    void Update()
    {

    }
        void OnCollisionEnter(Collision colisao)
    {
        if (colisao.gameObject.tag == "Bala")
        {
            GameObject Dano = Instantiate(Sangue, transform.position, Quaternion.identity);
            Destroy(Dano, 1f);
            Destroy(colisao.gameObject);
            Destroy(this.gameObject, 1f);

        }

        if (colisao.gameObject.tag == "Player")
        {
            colisao.gameObject.GetComponent<mover2>().hp++;
        }
    }

}
