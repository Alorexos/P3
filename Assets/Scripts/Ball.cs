using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject goCamera;
    public float fForce = 0.0f;
    
    private Rigidbody rbBall;
    private float fCameraAngle;

    // Start is called before the first frame update
    void Start()
    {
        rbBall = GetComponent<Rigidbody>();
        fCameraAngle = goCamera.transform.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(fCameraAngle.ToString());
            rbBall.AddForce(Quaternion.Euler(-fCameraAngle,0,0) * goCamera.transform.forward * fForce, ForceMode.Impulse);
        }

    }
}
