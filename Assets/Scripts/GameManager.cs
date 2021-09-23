using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform spawnPositionManager;
    public Material[] tankColours;
    public Material[] tracksColours;

    List<Transform> spawnPoints = new List<Transform>();
    int index = 0;
    //
    [SerializeField]
    List<int> killNumber = new List<int>();

    private void OnDestroy()
    {
        instance = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Timer.instance.finishCountDown = GameResult;
        //for (int i = 0; i < spawnPositionManager.transform.childCount; i++)
        //{
        //    spawnPoints.Add(spawnPositionManager.transform.GetChild(i));
        //}

        foreach (Transform trans in spawnPositionManager)
        {
            spawnPoints.Add(trans);
        }
    }

    void GameResult()
    {
        int masMuertes = 0;
        int indexDelGanador = 0;

        for (int i = 0; i < killNumber.Count; i++)
        {
            int x = i;
            if (killNumber[x] > masMuertes)
            {
                masMuertes = killNumber[x];
                indexDelGanador = x;
            }
        }

        Debug.Log($"El ganador es {indexDelGanador}");
    }

    public void UpdateKills(int killerIndex) 
    {
        killNumber[killerIndex]++;
    }

    public void OnSpawnPlayer(PlayerInput input)
    {
        //
        killNumber.Add(0);
        int randomIndex = Random.Range(0, spawnPoints.Count);

        var tankSc = input.GetComponent<Tank>();
        tankSc.SetInitialPos(spawnPoints[randomIndex].position, spawnPoints[randomIndex].rotation);
        tankSc.SetIndex(index);

        Material[] mats = new Material[4];

        //Que pasa aca?
        mats[0] = tankColours[index];
        mats[1] = tracksColours[index];
        mats[2] = tracksColours[index];
        mats[3] = tankColours[index];

        index++;

        input.GetComponent<TankColour>().tankCoulours = mats;

        spawnPoints.RemoveAt(randomIndex);
    }
}
