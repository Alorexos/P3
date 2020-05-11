using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereLevelManager : MonoBehaviour
{
    private GameStats Stats;
    private GameObject Spawn;
    private GameObject LevelParent;

    // Start is called before the first frame update
    private void Start()
    {
        Stats = GameStats.Instance;

        // Starting Level Setup
        LevelParent = GameObject.Find("Level_" + Stats.GetLevel());
        FindSpawn(LevelParent);
        if (Spawn != null)
        {
            GetComponent<SphereMovement>().ResetSphere();
            transform.position = Spawn.transform.position;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LevelEnd"))
        {
            Stats.SetLevel();
            LevelParent = GameObject.Find("Level_" + Stats.GetLevel());
            FindSpawn(LevelParent);
            if (Spawn != null)
            {
                GetComponent<SphereMovement>().ResetSphere();
                transform.position = Spawn.transform.position;
            }
        }

    }

    private void FindSpawn(GameObject Parent)
    {
        foreach (Transform SubParent in Parent.transform)
        {
            if (SubParent.name == "Gameplay")
            {
                foreach (Transform child in SubParent)
                {
                    if (child.CompareTag("LevelSpawn"))
                    {
                        Spawn = child.gameObject;
                        return;
                    }
                }
            }
        }
    }
}
