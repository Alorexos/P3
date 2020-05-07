using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats Instance { get; private set; }


    [SerializeField]
    private int Level;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetLevel()
    {
        return Level;
    }

    public void SetLevel()
    {
        Level++;
    }

    public void SetLevel(int Val)
    {
        Level = Val;
    }
}
