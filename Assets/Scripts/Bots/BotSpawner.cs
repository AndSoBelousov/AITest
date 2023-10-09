using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    

    [SerializeField]
    private TeamColor _teamColor;
    private GameObject _prefabBot;


    [SerializeField]
    private List<GameObject> _bots;

   

    private void Start()
    {
        ColorDeterminat(_teamColor);
        _bots = new();

    }

    private void ColorDeterminat(TeamColor teamColor)
    {
        switch(teamColor)
        {
            case TeamColor.BlueTeam:
                _prefabBot =  Resources.Load("Prefabs/BotBlueTeam") as GameObject;
                break;
            case TeamColor.RedTeam:
                _prefabBot = Resources.Load("Prefabs/BotRedTeam") as GameObject;
                break;
            case TeamColor.GreenTeam:
                _prefabBot = Resources.Load("Prefabs/BotGreenTeam") as GameObject;
                break;
        }
    }

    public void SpawnBots()
    {
        _bots.Add(Instantiate(_prefabBot, transform.position,transform.rotation));
    }
}
