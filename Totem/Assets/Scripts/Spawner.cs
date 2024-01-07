using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Spawner : Totem
{
    public GameObject totemSpawner;
    public GameObject currentTotemType;
    public GameObject totemsParent;

    // totems
    public GameObject bearTotem, wolfTotem, eagleTotem;

    public float totemOffsetY, totemTime;

    public bool allowSpawn;

    private void Start() {
        allowSpawn = true;
    }

    // spawn new totem
    public GameObject SpawnNewTotem()
    {
        StartCoroutine(timedSpawnLock());
        currentTotemType = ChooseType();
        GameObject newTotem = Instantiate(currentTotemType, totemSpawner.transform.position, Quaternion.identity);
        newTotem.transform.parent = totemsParent.transform;
        //newTotem.transform.GetChild(0).GetComponent<TextMeshPro>().text = ChooseType();
        MoveTotemsUp();
        GM.gameManager.activeTotem = newTotem;
        return newTotem;
    }

    // moves all totems up
    public void MoveTotemsUp()
    {
        totemsParent.transform.DOMoveY(totemsParent.transform.position.y + totemOffsetY, totemTime);
    }

    public GameObject ChooseType()
    {
        int roll = Random.Range(1, 4);
        GameObject totem = null;
        if (roll == 1) totem = bearTotem;
        if (roll == 2) totem = wolfTotem;
        if (roll == 3) totem = eagleTotem;
        return totem;
    }

    // -- //

    // locks spawning of new totems until movements have completed
    public IEnumerator timedSpawnLock() 
    {
        allowSpawn = false;
        yield return new WaitForSeconds(totemTime);
        allowSpawn = true;
    }
}
