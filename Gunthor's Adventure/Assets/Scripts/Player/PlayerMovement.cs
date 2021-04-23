using System.Collections;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 move;
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator.SetFloat("moveX", 0);
        myAnimator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        move = Vector3.zero;
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk)
        {
            MoveAndAnimate();
        }
    }

    private IEnumerator AttackCo()
    {
        myAnimator.SetBool("isAttacking", true);
        currentState = PlayerState.attack;
        yield return null;
        myAnimator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(0.3f);
        currentState = PlayerState.walk;
    }

    private void MoveAndAnimate()
    {
        if (move != Vector3.zero)
        {
            myAnimator.SetBool("isWalking", true);
            myAnimator.SetFloat("moveX", move.x);
            myAnimator.SetFloat("moveY", move.y);
            MoveCharacter();
        }
        else
        {
            myAnimator.SetBool("isWalking", false);
        }
    }

    void MoveCharacter()
    {
        move.Normalize();
        myRigidbody.MovePosition(transform.position + move * speed * Time.deltaTime);
    }
}