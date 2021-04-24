using System.Collections;
using UnityEngine;

public enum PlayerState
{
    idle,
    walk,
    attack,
    interact,
    stagger
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 move;
    private Animator myAnimator;
    public FloatValue currentHealth;
    public SignalSender playerHealthSignal;

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

        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack
            && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
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

    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {            
            StartCoroutine(KnockCo(knockTime));
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}