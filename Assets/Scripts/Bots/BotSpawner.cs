using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BotSpawner : MonoBehaviour
{


    [SerializeField]
    private TeamColor _teamColor;
    private GameObject _prefabBot;


    [SerializeField]
    private List<GameObject> _bots;

    private UnitCharacteristics _characteristics;

    [SerializeField] private Slider _sliderHealth;
    [SerializeField] private Slider _sliderSpeed;
    [SerializeField] private Slider _sliderStrongAttack;
    [SerializeField] private Slider _sliderFastAttack;
    [SerializeField] private Slider _sliderChanceCrite;
    [SerializeField] private Slider _sliderChanceMiss;
    [SerializeField] private Slider _sliderFastAttackChance;
    [SerializeField] private TextMeshProUGUI _textHealth;
    [SerializeField] private TextMeshProUGUI _textSpeed;
    [SerializeField] private TextMeshProUGUI _textStrong;
    [SerializeField] private TextMeshProUGUI _textFast;
    [SerializeField] private TextMeshProUGUI _textChanceCrite;
    [SerializeField] private TextMeshProUGUI _textChanceMiss;
    [SerializeField] private TextMeshProUGUI _textFastAttackChance;
    

    private void Start()
    {
        _characteristics = GetComponent<UnitCharacteristics>();
        ColorDeterminat(_teamColor);
        _bots = new();

    }
    private void FixedUpdate()
    {
        SliderSettings();   
    }
    private void ColorDeterminat(TeamColor teamColor)
    {
        switch (teamColor)
        {
            case TeamColor.BlueTeam:
                _prefabBot = Resources.Load("Prefabs/BotBlueTeam") as GameObject;
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
        _bots.Add(Instantiate(_prefabBot, transform.position, transform.rotation));
    }

    public void SliderSettings()
    { 
        if(_prefabBot != null)
        {
            _prefabBot.GetComponent<UnitCharacteristics>().SetUnitHealth((int) _sliderHealth.value);
            _textHealth.text = _sliderHealth.value.ToString("0");
            _prefabBot.GetComponent<UnitCharacteristics>().SetUnitSpeed((int) _sliderSpeed.value);
            _textSpeed.text = _sliderSpeed.value.ToString("0");
            _prefabBot.GetComponent<UnitCharacteristics>().SetDamageStrongAttack((int)_sliderStrongAttack.value);
            _textStrong.text = _sliderStrongAttack.value.ToString("0");
            _prefabBot.GetComponent<UnitCharacteristics>().SetDamageFastAttack((int)_sliderFastAttack.value);
            _textFast.text = _sliderFastAttack.value.ToString("0");
            _prefabBot.GetComponent<UnitCharacteristics>().SetCanceOfCrite((int)_sliderChanceCrite.value);
            _textChanceCrite.text = _sliderChanceCrite.value.ToString("0") + "%";
            _prefabBot.GetComponent<UnitCharacteristics>().SetChanceOfMiss((int)_sliderChanceMiss.value);
            _textChanceMiss.text = _sliderChanceMiss.value.ToString("0") + "%";
            _prefabBot.GetComponent<UnitCharacteristics>().SetFastAttackChance((int)_sliderFastAttackChance.value);
            _textFastAttackChance.text = _sliderFastAttackChance.value.ToString("0")+ "%";
        }
        
    }

}
