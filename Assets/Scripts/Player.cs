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
    }

    private void FixedUpdate()
    {
        rbcomponent.velocity = new Vector3(X_axis, rbcomponent.velocity.y, Z_axis);
        transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));

    }
    
}
