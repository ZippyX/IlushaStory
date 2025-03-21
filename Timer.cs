using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Hero _player;
    private float _timer;
    private float _timeToDeath = 2;
    void Start()
    {   
    }
    void Update()
    {
        if (_player.PlayerInCell)
        {
            NovichkomInTea();
        }
    }
    void NovichkomInTea()
    {
        _timer += Time.deltaTime;
        if (_timer >= _timeToDeath && _player.PlayerInCell)
        {
            _player.Death();
            EventBus.onKrakenCatchEnd?.Invoke();
        }
        if (_timer >= _timeToDeath && !_player.PlayerInCell)
        {
            EventBus.onKrakenCatchEnd?.Invoke();
        }
    }
}
