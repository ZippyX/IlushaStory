using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSummon : MonoBehaviour
{
    [SerializeField] GameObject trap;
    [SerializeField] Transform pointForTrap;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(trap, pointForTrap.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
