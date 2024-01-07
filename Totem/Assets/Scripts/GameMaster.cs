using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// base class (inherit from this to access the GameMaster)
// creates or gets the singleton 'GM' instance
// singleton instance name = project name as it's the highest level of control
// this derives from Monobehaviour so anything inheriting from this class also does
public class Totem : MonoBehaviour
{
    public GameMaster GM { get { return GameObject.FindObjectOfType<GameMaster>(); } }
}

// singleton class
public class GameMaster : MonoBehaviour
{
    // game managers
    //public MainMenu mainMenu;
    public GameManager gameManager;
    //public CostumeManager costumeManager;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}