using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerData" ,menuName = "Scriptables/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public List<PlayerInfo> playerData;
}

[System.Serializable]
public struct PlayerInfo
{
    public string schema;
    public InputDevice device;

    public PlayerInfo(string schema, InputDevice device)
    {
        this.schema = schema;
        this.device = device;
    }
}