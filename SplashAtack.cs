using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashAtack : MonoBehaviour
{
    [SerializeField] private Transform[] atackSpawnPoints;
    [SerializeField] float _timeForAtack;
    public GameObject Materia;
    private bool isAllSpawnPointsAtack = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StraightSplashAtack(int atackCount)
    {
        if (isAllSpawnPointsAtack)
        {
            for (int i = 1; i <= atackCount; i++)
            {
                Invoke("AllSpawnPointsAtack", _timeForAtack + i);
            }          
            isAllSpawnPointsAtack = false;
        }
    }
    void AllSpawnPointsAtack()
    {
        InstantMateria(atackSpawnPoints.Length);
    }
    void InstantMateria(int countAtackSpawnPoint )
    {
        for (int i = 0; i < countAtackSpawnPoint; i++)
        {
            Instantiate(Materia, atackSpawnPoints[i].transform.position,Quaternion.Euler(0,0,90));
        }
    }
}
