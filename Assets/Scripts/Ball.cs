using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Visible varaible
    [SerializeField]
    private GameObject PlayerCamera;
    [SerializeField]
    private float Force;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float StopFriction;
    [SerializeField]
    private int MaxCollisions; 
    [SerializeField]
    private int Level;


    // Hidden varaibles
    private Rigidbody BallBody;
    private float CameraAngle;
    private int CollisionCount;
    private bool SphereStop;


    // Start is called before the first frame update
    void Start()
    {
        BallBody = GetComponent<Rigidbody>();
        CameraAngle = PlayerCamera.transform.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0) && BallBody.velocity.x < 0.01f && BallBody.velocity.y < 0.01f)
        {
            SphereStop = false;
            BallBody.velocity = Quaternion.Euler(-CameraAngle, 0, 0) * PlayerCamera.transform.forward * Force;
        }
        if(SphereStop)
        {
            BallBody.velocity = BallBody.velocity * StopFriction;
            //if (BallBody.velocity.x < 0.01f && BallBody.velocity.z < 0.01f)
            //{
            //    BallBody.velocity = Vector3.zero;
            //}
        }
        
    }

    public int GetLevel()
    {
        return Level;
    }

    public void IncreaseLevel()
    {
        Level++;
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionCount++;
        if(CollisionCount == MaxCollisions)
        {
            CollisionCount = 0;
            SphereStop = true;
        }
    }
}
