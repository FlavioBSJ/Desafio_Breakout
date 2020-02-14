using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocidadeBola;
    public GameObject vidas;
    public int livecount;
    private bool bolaAtiva = false;
    public GameObject player;

    public GameObject Score;
    private int scorenum;
    public int numBlocks;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(bolaAtiva == false)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            transform.position = player.transform.GetChild(0).position;
        }
        if (Input.GetButtonDown ("Jump") == true) 
        {
      
         if (bolaAtiva == false)
            {
              GetComponent<Rigidbody2D>().velocity = Vector2.down * velocidadeBola;
              bolaAtiva = true;
            }
        }
    }

    public float hitAngulation(Vector2 Posbola, Vector2 Posplat, float Tamanhoplat)
    {
        return(Posbola.x - Posplat.x) / Tamanhoplat;
    }

    void OnCollisionEnter2D(Collision2D colisao) 
    {
        if(colisao.gameObject.name == "Plataforma")
        {
            float ps = hitAngulation(transform.position, colisao.transform.position,colisao.collider.bounds.size.x);

            Vector2 newpos = new Vector2(ps, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = newpos * velocidadeBola;
        }
        if(colisao.gameObject.name == "Morte")
        {
            livecount--;
            bolaAtiva = false;
            if(livecount >= 0)
            {
                vidas.GetComponent<UnityEngine.UI.Text>().text = livecount.ToString();
            }
            else
            {
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            }
            

        }
        if(colisao.gameObject.tag == "Bloco")
        {
            numBlocks--;
            scorenum++;
            Score.GetComponent<UnityEngine.UI.Text>().text = "Score: " +  scorenum.ToString();
            if(numBlocks <= 0)
            {
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
                
            }
        }
    }
}
