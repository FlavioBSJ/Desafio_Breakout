using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ball;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D colisao) 
    {
        if(colisao.gameObject.name == "Plataforma")
        {
            Instantiate(Ball);
            Destroy(this.gameObject);
        }
        
       
    }
}
