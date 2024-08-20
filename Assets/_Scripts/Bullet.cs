using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float lifeSpan = 5f;


    [SerializeField] private float bulletScaleAmount = 1f;

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
        //Debug.Log(collision.gameObject);

        if  (collision.gameObject.transform.parent.TryGetComponent(out IScalable scalable))
        {
            Vector3 scale = scalable.GetScale();

            scalable.SetScale(FunctionApplier.ApplyFunctionOnVecComponents(FunctionApplier.Function.Add, scale, -bulletScaleAmount, true, true, true));

            Destroy(gameObject);
        }
    }
}
