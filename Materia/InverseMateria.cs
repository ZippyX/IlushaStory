using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseMateria : Materia
{
    private void Update()
    {
        Atack(StraightRight);
        MateriaCleaner(transform.position.x > 15);
    }

    public void StraightRight()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + Vector3.right, Speed * Time.deltaTime);
    }
    
}
