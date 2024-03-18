using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 7f;
    float movementHorizontal;

    public float maxWidth = 7f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        if((movementHorizontal > 0 && transform.position.x < maxWidth) || (movementHorizontal < 0 && transform.position.x > -maxWidth))
        {
            transform.position += Vector3.right * movementHorizontal * speed * Time.deltaTime;
        }
    }
}
