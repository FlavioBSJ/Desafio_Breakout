using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BlockBehaviour : MonoBehaviour
{

    public AudioClip[] audioSources;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
      GetComponent<AudioSource>().clip = audioSources[Random.Range(0, audioSources.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D colisao) 
    {
        if(colisao.gameObject.name == "Bola")
        {
           AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, new Vector3(0, 0, 0));
           cam.GetComponent<Animator>().SetTrigger("Shake");
           Destroy(this.gameObject);
           
        }
    }
}
