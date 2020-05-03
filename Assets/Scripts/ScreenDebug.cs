using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenDebug : MonoBehaviour
{

    private Rigidbody BallBody;
    [SerializeField]
    private Text DebugText; 
    // Start is called before the first frame update
    void Start()
    {
        BallBody = GameObject.Find("Ball").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DebugText.text = "Vel_X: " + Mathf.Round(BallBody.velocity.x * 1000) / 1000
                       + " Vel_Y: " + Mathf.Round(BallBody.velocity.y * 1000) / 1000
                       + " Vel_Z: " + Mathf.Round(BallBody.velocity.z * 1000) / 1000;
    }
}
