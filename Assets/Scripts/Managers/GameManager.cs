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

    bool theresAWinner;
    bool timesOff;

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
        if (Timer.instance)
        {
            Timer.instance.finishCountDown = GameResult;
        }

        foreach (Transform trans in spawnPositionManager)
        {
            spawnPoints.Add(trans);
        }

        //Este une al primer jugador
        PlayerInputManager.instance.JoinPlayer(
            playerIndex: 0,
            controlScheme: "Keyboard&Mouse",
            pairWithDevice: Keyboard.current);


        //Este une al segundo jugador
        var input = PlayerInputManager.instance.JoinPlayer(playerIndex: 1);
        //Debido a que Unity new input system no nos permite de manera nativa
        //controlar dos elementos con el mismo control tenbemos que forzar la interacción
        PlayerInput.all[input.playerIndex].SwitchCurrentControlScheme(
            controlScheme: "Keyboard2",
            Keyboard.current);
    }

    void GameResult()
    {
        Debug.Log("Time's up");
        int masMuertes = 0;
        int indexDelGanador = 0;
        timesOff = true;

        for (int i = 0; i < killNumber.Count; i++)
        {
            int x = i;
            if (killNumber[x] > masMuertes)
            {
                masMuertes = killNumber[x];
                indexDelGanador = x;
                theresAWinner = true;
            }
            else if(killNumber[x] == masMuertes)
            {
                theresAWinner = false;
            }
        }

        if (!theresAWinner) 
        {
            Debug.Log("There's no winner");
            return;
        };
        Debug.Log($"El ganador es {indexDelGanador}");
    }

    public void UpdateKills(int killerIndex) 
    {
        killNumber[killerIndex]++;
        if(timesOff)
        {
            theresAWinner = true;
            Debug.Log($"El ganador es {killerIndex}");   
        }
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
