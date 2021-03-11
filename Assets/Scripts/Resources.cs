using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public float resource_Wood = 0;
    Rigidbody rbcomponent;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        rbcomponent = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {


        RaycastHit hit;

        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition),out hit))
        {
            if(hit.collider.tag == "Wood"&&Input.GetMouseButtonDown(0))
            {
                resource_Wood += 1;
                Debug.Log(resource_Wood);
            }
            


        }
            
                
    }
}
