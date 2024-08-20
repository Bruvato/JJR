using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float lifeSpan = 5f;


    [SerializeField] private float bulletScaleAmount = 1f;
    private FunctionApplier.Function bulletFunc;

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
        if  (collision.gameObject.transform.parent.TryGetComponent(out IScalable scalable))
        {
            Vector3 scale = scalable.GetScale();

            //int randomFunc = UnityEngine.Random.Range(0, 100);

            //if (randomFunc <= 80)
            //{
            //    bulletFunc = FunctionApplier.Function.Add;
            //    bulletScaleAmount = -1;

            //}
            //else if (randomFunc <= 95)
            //{
            //    bulletFunc = FunctionApplier.Function.Multiply;
            //    bulletScaleAmount = UnityEngine.Random.Range(0.1f, 1f); ;
            //}
            //else
            //{
            //    bulletFunc = FunctionApplier.Function.Power;
            //    bulletScaleAmount = 0;
            //}

            scalable.SetScale(FunctionApplier.ApplyFunctionOnVecComponents(FunctionApplier.Function.Add, scale, -1, true, true, true));

            SoundManager.Instance.Play("Hurt");

            Destroy(gameObject);
        }
    }
}
