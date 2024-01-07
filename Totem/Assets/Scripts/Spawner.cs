using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Spawner : Totem
{
    public GameObject totemSpawner;
    public GameObject totemPrefab;
    public GameObject totemsParent;

    public float totemOffsetY, totemTime;

    public bool allowSpawn;

    private void Start() {
        allowSpawn = true;
    }

    // spawn new totem
    public GameObject SpawnNewTotem()
    {
        StartCoroutine(timedSpawnLock());
        GameObject newTotem = Instantiate(totemPrefab, totemSpawner.transform.position, Quaternion.identity);
        newTotem.transform.parent = totemsParent.transform;
        newTotem.transform.GetChild(0).GetComponent<TextMeshPro>().text = ChooseType();
        MoveTotemsUp();
        GM.gameManager.activeTotem = newTotem;
        return newTotem;
    }

    // moves all totems up
    public void MoveTotemsUp()
    {
        totemsParent.transform.DOMoveY(totemsParent.transform.position.y + totemOffsetY, totemTime);
    }

    public string ChooseType()
    {
        string[] types = { "bear", "wolf" };
        string type = types[Random.Range(0, types.Length)];
        GM.gameManager.activeTotemType = type;
        return type;
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
