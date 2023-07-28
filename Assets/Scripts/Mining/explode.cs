using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    [SerializeField] private float _triggerForce = 0.5f;
    [SerializeField] private float _explosionRadius = 2;
    [SerializeField] private float _explosionForce = 5;
    [SerializeField] private GameObject _particles;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hoa");
        Debug.Log(other.name);
        var s = other.gameObject.GetComponent<Rigidbody>();
        Debug.Log(s.useGravity);
        s.useGravity = true;
        s.isKinematic = false;
        Debug.Log(s.useGravity);
        s.AddExplosionForce(_explosionForce, other.gameObject.transform.position, _explosionRadius);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.relativeVelocity.magnitude >= _triggerForce)
        {
            var surroundingObjects = Physics.OverlapSphere(transform.position, _explosionRadius);
            foreach (var obj in surroundingObjects)
            {
                var rb = obj.GetComponent<Rigidbody>();
                // gameObject.AddComponent<Rigidbody>();

                if (rb == null) continue;
                rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);

                // Instantiate(_particles, transform.position, Quaternion.identity);

            }
        }
    }
}
