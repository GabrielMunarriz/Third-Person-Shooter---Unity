using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{

    [SerializeField] private float mouseX = 0.0f;
    [SerializeField] private float mouseSensitivity = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += mouseX * mouseSensitivity;
        transform.localEulerAngles = newRotation;
    }
}
