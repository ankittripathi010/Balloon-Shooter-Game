using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip blast;
    public AudioSource source;

 
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "terrain")
        {
          //  print("terrain collided");
          //  source.PlayOneShot(bounce);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            source.Play();
            Destroy(gameObject);
            
        }
    }
}
