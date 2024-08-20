using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjShotPewPew : MonoBehaviour
{
    private float speed = 50f;
    private float lifeSpan = 5f;

    private void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    Destroy(gameObject);
        //}

    }
}
