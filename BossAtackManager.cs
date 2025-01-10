using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtackManager : MonoBehaviour
{
    private SplashAtack _atackManager; 
    void Start()
    {
        _atackManager = GetComponent<SplashAtack>();   
    }

    // Update is called once per frame
    void Update()
    {
        _atackManager.StraightSplashAtack(4);
    }
}
