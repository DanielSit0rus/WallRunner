using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = new Vector2(-9.8f, 0); // change object's gravity to the left
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
