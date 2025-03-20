using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtackManager : MonoBehaviour
{
    private AtackManager _atackManager;
    private int[] Attacks;
    private int counter;
    //private Queue<int >
    void Start()
    {
        _atackManager = GetComponent<AtackManager>();
        Attacks = new int[] {1,1,1,4};
     
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
