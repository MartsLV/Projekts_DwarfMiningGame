using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{



    public Vector3 pointToLook;

    private float X_axis;
    private float Z_axis;
    float Angle;
    Rigidbody rbcomponent;
    [SerializeField] Transform target;
    [SerializeField] public int tool = 0;
    
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

        X_axis = Input.GetAxis("Horizontal");
        Z_axis = Input.GetAxis("Vertical");

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            pointToLook = cameraRay.GetPoint(rayLength);
            
        }
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            tool = 1;
            Debug.Log("Tool 1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            tool = 2;
            Debug.Log("Tool 2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            tool = 3;
            Debug.Log("Tool 3");
        }
    }

    private void FixedUpdate()
    {
        rbcomponent.velocity = new Vector3(X_axis, rbcomponent.velocity.y, Z_axis);
        transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));

    }
    
}
