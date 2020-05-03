using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGateway : MonoBehaviour
{
    // Hidden varaibles
    private GameObject PlayerBall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject NextEntrance;
        int NextLevel; 
        Ball BallScript;

        if(other.gameObject.tag != "Player") return; 

        BallScript = other.gameObject.GetComponent<Ball>();

        //Find Next Level
        NextLevel = BallScript.GetLevel() + 1;
        Debug.Log(BallScript.GetLevel());
        NextEntrance = GameObject.Find("LevelEntrance_" + NextLevel.ToString());
        if (!NextEntrance) return;

        //Relocate Player Ball
        other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f,0.0f,0.0f);
        other.gameObject.transform.position = NextEntrance.transform.position;


        //Increase Level
        BallScript.IncreaseLevel();

    }
}
