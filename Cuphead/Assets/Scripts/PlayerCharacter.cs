﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    public GameObject bulletRight;
    public GameObject bulletLeft;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;
    bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Fires when Fire1 button is pressed or held down
     if((Input.GetButtonDown("Fire1") || Input.GetKey(KeyCode.LeftControl)) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
        }  
     if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) { //uses last movement command
            if (Input.GetKeyDown(KeyCode.A))
            {
                facingRight = false;
            } else
            {
                facingRight = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Desroys Bullet on collision with player
        //Debug.Log("collision name = " + col.gameObject.name);
        //if (col.gameObject.name == "BulletLeft(Clone)" || col.gameObject.name == "BulletRight(Clone)")
        //{
        //    Destroy(col.gameObject);
        //}
    }

    void fire()
    {
        if(facingRight){
            bulletPos = transform.position;
            bulletPos += new Vector2(+3f, 0);
            Instantiate(bulletRight, bulletPos, Quaternion.Euler(0, 0, -90));
        } else {
            bulletPos = transform.position;
            bulletPos += new Vector2(-3f, 0);
            Instantiate(bulletLeft, bulletPos, Quaternion.Euler(0, 0, 90));
     
        }
    }
}
