using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    public LayerMask solidObjectLayer;
    public LayerMask grassLayer;
    
    private bool isMoving;
    private Vector2 input;

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(isWalkable(targetPos)) StartCoroutine(Move(targetPos));
            }

        }

        animator.SetBool("isMoving", isMoving);

    }

    private void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.2f, grassLayer) != null)
        {
            if(Random.Range(1, 101) <= 10)
            {
                Debug.Log("Encounter a wild pokemon.");
            }
        }
    }
    private bool isWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectLayer) != null)
        {
            return false;
        }
        return true;
    }

        /*
         To move player toward a position by comparing the square root magnitude of target position minus by player's position  
         with Mathf.Epsilon which is a float number that will be greater than zero but smaller than 1. (Multiple decimal places, only for comparison)
         If the result of square root magnitude is greater than Mathf.Epsilon, move the player position towards the target position with
         a movement speed multiply by Time.deltaTime (time in seconds from the last to the current frame).

         When this statement no longer valid set player position to the target position. (Basically means the player has reaches the position with the
         while loop)
         */
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        //The main reason to use sqrMagnitude rather than just sqrt is because it is computational cheaper.
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;

        CheckForEncounters();
    }
    
}
