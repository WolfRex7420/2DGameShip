using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollowScript : MonoBehaviour
{
    Vector3 mousePosition;
    Vector2 position = new Vector2(0f, 0f);
    WorldNewtonianMovement speed;

    void Start()
    {
        
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        Camera.main.WorldToScreenPoint(transform.position);
        position = Vector2.Lerp(transform.position, mousePosition, speed);
    }
}
