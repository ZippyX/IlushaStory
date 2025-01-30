using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangeMateria : MonoBehaviour
{
    [SerializeField] float _speed;


    // Update is called once per frame
    void Update()
    {
        StraightAtack();
        MateriaCleaner();       
    }

    public void StraightAtack()
    {
       transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + Vector3.left, _speed * Time.deltaTime);
    }
    void MateriaCleaner()
    {
        if (transform.position.x < -1)
        {
            SplashAtack.objectsForAtack.Remove(this.gameObject);
            Destroy(gameObject);
        }
        if (SplashAtack.objectsForAtack.Count == 0)
        {
            EventBus.onAtackEnd?.Invoke();
            Debug.Log("атака закончилась");
        }
    }
}
