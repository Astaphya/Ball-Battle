using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotateSpeed;
    public VariableJoystick variableJoystick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * horizontal * rotateSpeed *Time.deltaTime);

         #if UNITY_ANDROID
         variableJoystick.gameObject.SetActive(true);
         transform.Rotate(Vector3.up , variableJoystick.Horizontal * rotateSpeed * Time.deltaTime);

         #endif

    
    }
}
