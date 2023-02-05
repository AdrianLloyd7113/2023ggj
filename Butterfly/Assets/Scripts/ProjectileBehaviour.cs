using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {

        float x;

        if (gameObject.tag == "leftproj"){
            x = -10f;
        }else{
            x = 10f;
        }

        transform.position += new Vector3(x, 0, 0) * Time.deltaTime;
    }
}
