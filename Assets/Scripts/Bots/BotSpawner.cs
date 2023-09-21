using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    private Transform _entityContainer;
    private BotSpawnPoint _botSpawnPoint;

    [SerializeField]
    private TeamColor _teamColor;
    private GameObject _prefabBot;


    [SerializeField]
    private List<GameObject> _bots;

    private void Awake()
    {
        //_entityContainer = FindObjectOfType<EntityContainer>().transform;
        //_botSpawnPoint = FindObjectOfType<BotSpawnPoint>();
    }

    private void Start()
    {
        ColorDeterminat(_teamColor);
        _bots = new();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBots();
        }
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

    private void SpawnBots()
    {
        _bots.Add(Instantiate(_prefabBot));
    }
}
