using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    float maxHheight = 16;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y>maxHheight)
        {
            transform.position=new Vector3(transform.position.x,maxHheight,transform.position.z);
        }
    }
}
