using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : Totem
{
    
    void Update()
    {
        if (Input.GetKeyDown("space")){

            if (GM.gameManager.spawner.allowSpawn)
                GM.gameManager.spawner.SpawnNewTotem();
        }

        if (Input.GetKeyDown("a")){

            GM.gameManager.HandlePlayerInput("left");
        }

        if (Input.GetKeyDown("d")){

            GM.gameManager.HandlePlayerInput("right");
        }
    }
}
