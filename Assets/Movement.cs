using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float movementSpeed;

    void Update()
    {
        movementFunction();
    }
    void movementFunction()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
}
