using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackManager : MonoBehaviour
{
    [SerializeField] private Transform[] _atackSpawnPoints;
    [SerializeField] private Transform[] _airAtackSpawnPoints;
    [SerializeField] private Transform[] _inversiveAtackPoints;
    [SerializeField] float _timeForAtack;

    public GameObject InverseMateria;
    public GameObject Materia;
    public GameObject AimMateria;
    
    public static List<GameObject> objectsForAtack;
    public bool AtackInProcess;
    void Start()
    {
        EventBus.onAtackEnd -= AtackEndHandler;
        objectsForAtack = new List<GameObject>();
    }

    void Update()
    {
        
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
                InstantMateria(_airAtackSpawnPoints, AimMateria);
            }
            if (id == 2)
            {
                InstantMateria(_inversiveAtackPoints, InverseMateria);
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

}
