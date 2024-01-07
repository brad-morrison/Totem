using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : Totem
{
    public Spawner spawner;
    public PlayerInput playerInput;

    // actives
    public GameObject activeTotem;
    public string activeTotemType;
    public string activeSpiritLeft;
    public string activeSpiritRight;

    private void Start() {
        activeSpiritLeft = "bear";
        activeSpiritRight = "wolf";
    }

    public void HandlePlayerInput(string input)
    {
        // if correct
        if (input == "left" && activeSpiritLeft == activeTotemType)
        {
            GM.gameManager.activeTotem.GetComponent<TotemObj>().RotateTotem("left");
            GM.gameManager.spawner.SpawnNewTotem();
        }

        // if correct
        if (input == "right" && activeSpiritRight == activeTotemType)
        {
            GM.gameManager.activeTotem.GetComponent<TotemObj>().RotateTotem("right");
            GM.gameManager.spawner.SpawnNewTotem();
        }

        //GM.gameManager.spawner.SpawnNewTotem();
    }
}
