using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMateria : MonoBehaviour
{
    [SerializeField] float _speed;
    private GameObject player;
    private Vector3 target;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform.position;
        player = null;

    }

    // Update is called once per frame
    void Update()
    {
        StraightAtack();
        MateriaCleaner();
    }
    public void StraightAtack()
    {
        target.y = -0.5f;
        transform.position = Vector3.MoveTowards(this.transform.position,target, _speed * Time.deltaTime);
    }
    void MateriaCleaner()
    {
        if (transform.position.y < 0)
        {
            Destroy(this.gameObject);
            SplashAtack.objectsForAtack.Remove(this.gameObject);// добавить проверку на наличие этого объекта, чтобы ошибок не было
        }
        if (SplashAtack.objectsForAtack.Count == 0)
        {
            EventBus.onAtackEnd?.Invoke();
            Debug.Log("атака закончилась");
        }
    }
    
    
}
