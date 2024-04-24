using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField] DevilController devilController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (devilController.hasTalked) // talked to the Devil at first
        {
            gameObject.SetActive(false);
        }
    }
}
