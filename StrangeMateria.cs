using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangeMateria : MonoBehaviour
{
    [SerializeField] float _speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + Vector3.left, _speed * Time.deltaTime);
        if (transform.position.x < -1)
            Destroy(gameObject);
    }
}
