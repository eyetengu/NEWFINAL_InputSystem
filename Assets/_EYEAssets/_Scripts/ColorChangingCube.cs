using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangingCube : MonoBehaviour
{
    public GameObject cube;
    public MeshRenderer cubeMesh;
    private ColorChangingCubeInputs _colorCube;
    public bool isCubeDriving;
           
    void Start()
    {
        cubeMesh = GameObject.Find("Cube").GetComponent<MeshRenderer>();

        _colorCube= new ColorChangingCubeInputs();
        _colorCube.Enable();
        _colorCube.Cube.ChangeColor.performed += ChangeColor_performed; 
        
        _colorCube.Cube.RotateCube.performed += RotateCube_performed;

        _colorCube.DrivableCube.Disable();
        _colorCube.DrivableCube.Driving.performed += Driving_performed;
    }

    private void Driving_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        //Debug.Log("Driving context " + context);
        var speed = context.ReadValue<Vector2>();
        
        if (speed.y > 0)
        {
            Debug.Log("faster");
        }
        else if(speed.y < 0)
        {
            Debug.Log("slower");
        }
        
        if(speed.x < 0) 
        {
            Debug.Log("left");
        }
        
        if(speed.x > 0) 
        { 
            Debug.Log("right");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            isCubeDriving = !isCubeDriving;
            if (isCubeDriving == true)
            { _colorCube.DrivableCube.Enable();
                Debug.Log("Enabled");
            }
            if(isCubeDriving == false)
            {  _colorCube.DrivableCube.Disable();
                Debug.Log("Disabled");
            }
        }
    }

    private void RotateCube_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        //Debug.Log("Context " + context);
        var rotationDirection = context.ReadValue<float>();
        if (rotationDirection < 0)
        {
        cube.transform.Rotate(0, -90, 0);


        if(rotationDirection > 0) { cube.transform.Rotate(0, 90, 0); }
        }

    }

    void ChangeColor_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        //Debug.Log("Whoa fella");

        cubeMesh.material.color = Random.ColorHSV();
    }
}
