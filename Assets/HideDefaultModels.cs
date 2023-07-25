using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDefaultModels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("[Left Controller] Model Parent").SetActive(false);
        GameObject.Find("[Right Controller] Model Parent").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
