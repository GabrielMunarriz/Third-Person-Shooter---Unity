using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{

    [SerializeField] private float mouseY = 0.0f;
    [SerializeField] private float mouseSensitivity = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        mouseY = Input.GetAxis("Mouse Y");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x -= mouseY * mouseSensitivity;
        transform.localEulerAngles = newRotation;

    }
}
