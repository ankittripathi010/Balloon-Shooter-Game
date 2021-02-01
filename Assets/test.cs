using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(this.transform.position , this.transform.forward * 200 , out hit))
        {
            print(hit.collider);
            Debug.DrawRay(this.transform.position, this.transform.forward * 200, Color.red);
        }
    }
}
