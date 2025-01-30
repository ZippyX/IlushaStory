using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtackManager : MonoBehaviour
{
    private SplashAtack _atackManager;
    private int[] Attacks;
    private int counter;
    //private Queue<int >
    void Start()
    {
        _atackManager = GetComponent<SplashAtack>();
        Attacks = new int[] {0,0,1,0};
     
    }

    // Update is called once per frame
    void Update()
    {
        if (!_atackManager.AtackInProcess && counter<Attacks.Length)
        {
            _atackManager.Atack(Attacks[counter]);
            Debug.Log(counter++);
        }

    }
}
