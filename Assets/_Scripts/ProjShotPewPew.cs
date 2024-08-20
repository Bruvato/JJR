using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjShotPewPew : MonoBehaviour {
    private float speedster = 50f;  
    private float lifespanAge = 5f; 

    void Start() {
        Destroy(gameObject, lifespanAge);
    }

    void Update() {
        transform.Translate(Vector3.forward * speedster * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            


            Destroy(gameObject);
        }
    }
}
