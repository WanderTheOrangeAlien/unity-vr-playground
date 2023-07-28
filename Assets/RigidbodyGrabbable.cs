using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RigidbodyGrabbable : MonoBehaviour
{
    const int GRABBED_BY_HAND_LAYER = 9;
    private XRGrabInteractable grabbable;

    private bool isGrabbed, isCollidingWithHand;
    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<XRGrabInteractable>();

        grabbable.selectEntered.AddListener((SelectEnterEventArgs args) => {
            ChangeLayer(LayerMask.NameToLayer("Grabbed Object")); 
        });

        grabbable.selectExited.AddListener((SelectExitEventArgs args) => {
            Invoke("ChangeLayerToDefault",0.5f);
            
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLayer(int index)
    {
        gameObject.layer = index;
    }

    public void ChangeLayerToDefault()
    {
        gameObject.layer = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Right Hand Physics") ||
           collision.gameObject.layer == LayerMask.NameToLayer("Left Hand Physics"))
        {
            isCollidingWithHand = true; 
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Right Hand Physics") || 
            collision.gameObject.layer == LayerMask.NameToLayer("Left Hand Physics"))
        {
            isCollidingWithHand = false;

        }
    }

}
