using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGateway : MonoBehaviour
{
    // Visisble varaibles

    // Hidden varaibles
    private GameObject PlayerSphere;
    private GameStats Stats;

    // Start is called before the first frame update
    void Start()
    {
        Stats = GameStats.Instance;
        PlayerSphere = GameObject.Find("Ball");
        if (gameObject.name == "PF_LevelExit_" + Stats.GetLevel())
        {
            SetupLevel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player") return;

        Stats.SetLevel();
        SetupLevel();
    }
    private void SetupLevel()
    {
        GameObject Entrance;
        Entrance = GameObject.Find("PF_LevelEntrance_" + Stats.GetLevel());

        if (!Entrance) return;

        //Relocate Player Ball
        PlayerSphere.GetComponent<SphereMovement>().ResetSphere();
        PlayerSphere.transform.position = Entrance.transform.position;


    }
}
