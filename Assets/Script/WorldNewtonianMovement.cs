using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class WorldNewtonianMovement : MonoBehaviour
{
    public float speed, acceleration;
    public Vector2 screenSize, shipSize;
    public TextMeshProUGUI infoText;

    private void Start()
    {
        
        InitializeSizes();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            speed += acceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            speed -= acceleration * Time.deltaTime;
        }

        //teleportation :
        //right
        if (transform.position.x >= screenSize.x / 2 + shipSize.x / 2)
        {
            transform.position = new Vector3(-screenSize.x / 2 - shipSize.x / 2, transform.position.y);
        }
        
        //left
        if (transform.position.x < -screenSize.x / 2 - shipSize.x / 2)
        {
            transform.position = new Vector3(screenSize.x / 2 + shipSize.x / 2, transform.position.y);
        }
        
        //up
        if (transform.position.y >= screenSize.y / 2 + shipSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x ,-screenSize.y / 2 - shipSize.y / 2);
        }

        //down
        if (transform.position.y < -screenSize.y / 2 - shipSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, screenSize.y / 2 + shipSize.y / 2);
        }

        transform.position += transform.right * speed * Time.deltaTime;

        //infoText.text = "Acceleration : " + acceleration + " ; Speed : " + speed + " :)";
        infoText.text = string.Format("{0:00}:{1:00}", Time.timeSinceLevelLoad / 60, Time.timeSinceLevelLoad % 60);
        infoText.text += $"\nAcceleration :  {acceleration}   ; Speed :  {(int)speed}";
        //infoText.text = string.Format("Acceleration :  + {0} +  ; Speed :  + {1} +  :)", acceleration, speed);
    }

    void InitializeSizes()
    {
        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
        shipSize = GetComponent<SpriteRenderer>().bounds.size;
    }
}