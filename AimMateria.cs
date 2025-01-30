using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMateria : Materia
{
    private GameObject _player;
    private Vector3 _target;
    private const float OFFSET = -0.5f;

    void Start()
    {
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        Atack();
        MateriaCleaner(transform.position.y<0 && AtackManager.objectsForAtack.Count>0);
    }
    public override void Atack()
    {
        _target.y = OFFSET;
        transform.position = Vector3.MoveTowards(this.transform.position,_target, Speed * Time.deltaTime);
    }
    void FindPlayer()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _target = _player.transform.position;
        _player = null;
    }
    
}
