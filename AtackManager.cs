using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



//[RequireComponent(typeof(InverseMateria))]
public class AtackManager : MonoBehaviour
{
    [SerializeField] private Transform[] _atackSpawnPoints;
    [SerializeField] private Transform[] _airAtackSpawnPoints;
    [SerializeField] private Transform[] _inversiveAtackPoints;
    [SerializeField] private Transform SpikeFallSpawnPoint;

    public GameObject InversiveMateria;
    public GameObject Materia;
    public GameObject AirMateria;
    public GameObject SpikeFall;
    public GameObject Cell;
    public Hero Player;
    private GameObject _spawnedCell;

    public TextMeshProUGUI tip;
    
    public static List<GameObject> objectsForAtack;
    public bool AtackInProcess;

    void Start()
    {
        EventBus.onAtackEnd -= AtackEndHandler;
        objectsForAtack = new List<GameObject>();
    }

    void Update()
    {
        if (!Player.PlayerInCell && _spawnedCell)
        {
            DestroyCell();
        }
    }

    void AtackEndHandler()
    {
        EventBus.onAtackEnd -= AtackEndHandler;
        Debug.Log("атака произошла");
        AtackInProcess = false;
    }

    public void Atack(int id)
    {
        if (!AtackInProcess)
        {
            AtackInProcess = true;
            EventBus.onAtackEnd += AtackEndHandler;
            if (id == 0)
            {           
                InstantMateria(_atackSpawnPoints, Materia);
            }
            if (id == 1)
            {
                InstantMateria(_airAtackSpawnPoints, AirMateria);
            }
            if (id == 2)
            {
                InstantMateria(_inversiveAtackPoints, InversiveMateria);
            }
            if (id == 3)
            {
                InstantSpikeFall(SpikeFallSpawnPoint);
            }
            if (id == 4)
            {
                EventBus.onKrakenCatchStart += Player.EscapeStart;
                InstantKrakenCatch();
            }
        }
        
    }
    void InstantMateria(Transform[] positionForATack,GameObject Materia)
    {
        int countAtackSpawnPoint = positionForATack.Length;
           
        for (int i = 0; i < countAtackSpawnPoint; i++)
        {
            var materia = Instantiate(Materia, positionForATack[i].transform.position,Quaternion.Euler(0,0,90));
            objectsForAtack.Add(materia);
        }
    }
    void InstantSpikeFall(Transform positionForSpawn)
    {
        var trap = Instantiate(SpikeFall, positionForSpawn.transform.position, Quaternion.identity);
        objectsForAtack.Add(trap);
    }
    void InstantKrakenCatch()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); ;
        _spawnedCell = Instantiate(Cell, player.transform.position, Quaternion.identity);
        objectsForAtack.Add(_spawnedCell);
        tip.gameObject.SetActive(true);
        EventBus.onKrakenCatchStart?.Invoke();
        Player.ResetSpaceCounter();
    }
    void DestroyCell()
    {
        Destroy(_spawnedCell);
        objectsForAtack.Remove(_spawnedCell);
        tip.gameObject.SetActive(false);
    }

}
