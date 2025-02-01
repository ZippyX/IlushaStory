using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MateriaCleaner(transform.position.y < -2);
    }
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
