using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class AsteroidMouvScript : MonoBehaviour
{
    public float speed;
    public Vector2 screenSize, asterSize;
    // Start is called before the first frame update
    void Start()
    {
        InitializeSizes();
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
    }

    // Update is called once per frame
    void Update()
    {
        //teleportation :
        //right
        if (transform.position.x >= screenSize.x / 2 + asterSize.x / 2)
        {
            transform.position = new Vector3(-screenSize.x / 2 - asterSize.x / 2, transform.position.y);
        }

        //left
        if (transform.position.x < -screenSize.x / 2 - asterSize.x / 2)
        {
            transform.position = new Vector3(screenSize.x / 2 + asterSize.x / 2, transform.position.y);
        }

        //up
        if (transform.position.y >= screenSize.y / 2 + asterSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, -screenSize.y / 2 - asterSize.y / 2);
        }

        //down
        if (transform.position.y < -screenSize.y / 2 - asterSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, screenSize.y / 2 + asterSize.y / 2);
        }

        transform.position += transform.right * speed * Time.deltaTime;
        
        /*
        //random rotation madness :
        //right
        if (transform.position.x >= screenSize.x / 2 + asterSize.x / 2)
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
        }

        //left
        if (transform.position.x < -screenSize.x / 2 - asterSize.x / 2)
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
        }

        //up
        if (transform.position.y >= screenSize.y / 2 + asterSize.y / 2)
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
        }

        //down
        if (transform.position.y < -screenSize.y / 2 - asterSize.y / 2)
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
        }
        */
    }
    void InitializeSizes()
    {
        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
        asterSize = GetComponent<SpriteRenderer>().bounds.size;
    }
}
