using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        MoveAndAnimate();
    }

    private void MoveAndAnimate()
    {
        if (change != Vector3.zero)
        {
            myAnimator.SetBool("isWalking", true);
            myAnimator.SetFloat("moveX", change.x);
            myAnimator.SetFloat("moveY", change.y);
            MoveCharacter();
        }
        else
        {
            myAnimator.SetBool("isWalking", false);
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}