using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoins : MonoBehaviour
{
    private float rotationspeed = 400;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationspeed * Time.deltaTime * Vector3.forward);
    }
}
