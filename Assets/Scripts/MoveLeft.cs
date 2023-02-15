using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Variables
    private float speed = 20;
    private GameManager gameManagerScript;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        // Varaiable conataing PlayerController Script.
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the Obstacle and Background to the left.
        if(gameManagerScript.active == true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        // Destroys the Obstacle.
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
