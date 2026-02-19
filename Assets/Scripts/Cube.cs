using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Physics.Raycast(transform.position, transform.up))
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;

        }
    }

}
