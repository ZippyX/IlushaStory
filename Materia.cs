using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Materia : MonoBehaviour
{
    public float Speed;
    
    public abstract void Atack();
    public void MateriaCleaner(bool conditionForDestroy)
    {
        if (conditionForDestroy)
        {
            Destroy(this.gameObject);
            AtackManager.objectsForAtack.Remove(this.gameObject);
        }
        if (AtackManager.objectsForAtack.Count == 0)
        {
            EventBus.onAtackEnd?.Invoke();
            Debug.Log("атака закончилась");
        }
    }
}
