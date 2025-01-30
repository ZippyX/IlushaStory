using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangeMateria : Materia
{
    void Update()
    {
        Atack();
        MateriaCleaner(transform.position.x <-7);//-13 левая граница  
    }

    public override void Atack()
    {
       transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + Vector3.left, Speed * Time.deltaTime);
    }
}
