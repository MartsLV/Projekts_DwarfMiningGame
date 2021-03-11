using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public int resource_Wood = 0;
    public int resource_Stone = 0;
    public int resource_Metal = 0;
    Rigidbody rbcomponent;
    private Camera mainCamera;
    [SerializeField] public int tool;

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
            if(hit.collider.tag == "Wood"&&Input.GetMouseButtonDown(0)&&tool==1)
            {
                resource_Wood += 1;
                Debug.Log(resource_Wood);
            }
            if (hit.collider.tag == "Stone" && Input.GetMouseButtonDown(0) && tool == 2)
            {
                resource_Stone += 1;
                Debug.Log(resource_Stone);
            }
            if (hit.collider.tag == "Metal" && Input.GetMouseButtonDown(0) && tool == 3)
            {
                resource_Metal += 1;
                Debug.Log(resource_Metal);
            }



        }
            
                
    }
}
