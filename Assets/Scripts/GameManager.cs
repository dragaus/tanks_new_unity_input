using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public Transform spawnPositionManager;
    
    List<Transform> spawnPoints = new List<Transform>();
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < spawnPositionManager.transform.childCount; i++)
        //{
        //    spawnPoints.Add(spawnPositionManager.transform.GetChild(i));
        //}

        foreach (Transform trans in spawnPositionManager)
        {
            spawnPoints.Add(trans);
        }
    }

    public void OnSpawnPlayer(PlayerInput input)
    {
        int randomIndex = Random.Range(0, 
            spawnPoints.Count);

        input.GetComponent<Tank>()
            .SetInitialPos(
            spawnPoints[randomIndex].position);

        spawnPoints.RemoveAt(randomIndex);
    }
}
