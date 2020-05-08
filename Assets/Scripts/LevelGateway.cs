using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGateway : MonoBehaviour
{
    // Visisble varaibles
    [SerializeField]
    private Vector3 Offset;

    // Hidden varaibles
    private GameObject PlayerSphere;
    private Ball SphereScript;
    private GameStats Stats;

    // Start is called before the first frame update
    void Awake()
    {
        Stats = GameStats.Instance;
        PlayerSphere = GameObject.Find("Ball");
        if (gameObject.name == gameObject.name.Substring(0, gameObject.name.Length - 1) + Stats.GetLevel())
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
        Entrance = GameObject.Find("LevelEntrance_" + Stats.GetLevel());

        if (!Entrance) return;

        //Relocate Player Ball
        PlayerSphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
        PlayerSphere.transform.position = Entrance.transform.position + Offset;

    }
}
