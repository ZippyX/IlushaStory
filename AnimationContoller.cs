using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationContoller : MonoBehaviour
{
    [SerializeField] Hero player;
    [SerializeField] Animator anim;
    void Start()
    {
        player = GetComponent<Hero>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("moveX", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        if (player.IsGrounded)
            anim.SetBool("jump", false);
        else
            anim.SetBool("jump", true);
        if (player.IsDeath)
            anim.SetBool("death", true);
    }
}
