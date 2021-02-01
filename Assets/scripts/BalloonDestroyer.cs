using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonDestroyer : MonoBehaviour
{
    public GameObject burstParticlePrefab;
    Transform trans;
    AudioSource sfxSource;
    public AudioClip sfxClip;
    GameObject instantiatedGb;
    private void Start()
    {
        trans = GetComponent<Transform>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("collision occur");
        if(collision.gameObject.tag == "Bullet")
        {
            
            Destroy(gameObject);
            instantiatedGb  =  Instantiate(burstParticlePrefab, trans.position, trans.rotation);
            sfxSource = instantiatedGb.GetComponent<AudioSource>();
            sfxSource.Play();
            
        }
    }
}
