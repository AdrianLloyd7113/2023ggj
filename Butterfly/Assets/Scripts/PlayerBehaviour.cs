using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Sprite player;
    public int speed;
    public int health;
    public int strength;
    int xD;
    int yD;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey("A")){
            xD = -speed;
        } else if (Input.GetKey("D")){
            xD = speed;
        }

        if (Input.GetKey("SPACE")){
            
        }

        transform.position += new Vector3(xD, yD, 0) * Time.deltaTime;
    }
}
