using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseMateria : Materia
{
    private void Update()
    {
        Atack();
        MateriaCleaner(transform.position.x > 15);
    }

    public override void Atack()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + Vector3.right, Speed * Time.deltaTime);
    }
    
}
