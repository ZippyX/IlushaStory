using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSummon : MonoBehaviour
{
    [SerializeField] private GameObject _trap;
    [SerializeField] private Transform _pointForTrap;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(_trap, _pointForTrap.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
