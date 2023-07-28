using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnBulletOnActivate : MonoBehaviour
{
    public GameObject bulletObject;
    public Transform spawnPoint;
    public float shootingSpeed;
    public float despawnTime;

    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(SpawnBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBullet(ActivateEventArgs args)
    {
        GameObject bullet = Instantiate(bulletObject);
        bullet.transform.position = spawnPoint.position;
    }
}
