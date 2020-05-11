using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    // Visible varaible
    [SerializeField]
    private GameObject PlayerCamera;
    [SerializeField]
    private float Speed;
    [SerializeField]
    [Range(1.0f, 10.0f)]
    private float StopPeriod;
    [SerializeField]
    private int MaxCollisions; 



    // Hidden varaibles
    private Rigidbody BallBody;
    private int CollisionCount;
    private float SpeedPerSec; 
    private float StopTimer;
    private Vector3 CurrentVelocity;


    // Start is called before the first frame update
    private void Awake()
    {
        BallBody = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        SpeedPerSec = Speed / StopPeriod;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentVelocity = BallBody.velocity;

        if(BallBody.velocity == Vector3.zero)
        {
            CollisionCount = 0;
        }

        if (CollisionCount >= MaxCollisions)
        {
            StopTimer = Mathf.Max(0.0f,StopTimer - Time.deltaTime);
            BallBody.velocity = CurrentVelocity.normalized * SpeedPerSec * StopTimer;
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        Bounce(other.contacts[0].normal);

        CollisionCount++;
        Debug.Log(CollisionCount);
        if(CollisionCount == MaxCollisions)
        {
            StopTimer = StopPeriod;
        }
    }

    private void Bounce(Vector3 collisionNormal)
    {
        float CurrentSpeed = CurrentVelocity.magnitude;
        Vector3 Direction = Vector3.Reflect(CurrentVelocity.normalized, collisionNormal);
        BallBody.velocity = Direction * CurrentSpeed;
    }

    public void ResetSphere()
    {
        CollisionCount = 0;
        StopTimer = 0.0f;
        BallBody.velocity = Vector3.zero;
    }

    public void SetVelocity(Vector3 Direction)
    {
        if (BallBody.velocity == Vector3.zero)
        {
            BallBody.velocity = Direction * Speed;
        }
    }
    public Vector3 GetVelocity()
    {
        return BallBody.velocity;
    }

}
