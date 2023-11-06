using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Player : MonoBehaviour
{

    private bool attacking = false;
    public p1Hitbox hitbox;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            StopAttack();
        }
    }

    void Attack()
    {
        animator.Play("slash");
        animator.SetBool("isSlashing", true);
        attacking = true;
        hitbox.gameObject.SetActive(true);
        hitbox.StartAttack();
    }

    void StopAttack()
    {
        animator.SetBool("isSlashing", false);
        attacking = false;
    }
}
