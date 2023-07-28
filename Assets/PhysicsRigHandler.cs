using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRigHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerHead;
    public CapsuleCollider bodyCollider;

    public float bodyHeightMin = 0.5f;
    public float bodyHeightMax = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bodyCollider.height = Mathf.Clamp(playerHead.localPosition.y, bodyHeightMin, bodyHeightMax);
        bodyCollider.center = new Vector3(playerHead.localPosition.x, bodyCollider.height / 2, playerHead.localPosition.z);


    }
}
