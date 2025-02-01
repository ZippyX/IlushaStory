using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMateria : Materia
{
    private GameObject _player;
    private Vector3 _target;
    private float _offset = -0.5f;

    void Start()
    {
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        Atack(Aim,_offset);
        //MateriaCleaner(transform.position.y<-4 && AtackManager.objectsForAtack.Count>0); legacy xD
        MateriaCleaner((transform.position.y < 0) && AtackManager.objectsForAtack.Count > 0);
    }
    public void Aim(float offset)
    {
        _target.y = _offset;
        transform.position = Vector3.MoveTowards(this.transform.position,_target, Speed * Time.deltaTime);
    }
    public void FindPlayer()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _target = _player.transform.position;
        _player = null;
    }
    
}

/* (A && B) || (D&&B) => (A||D) && B*/
