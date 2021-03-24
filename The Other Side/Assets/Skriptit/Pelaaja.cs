using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Pelaaja : MonoBehaviour
{

    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;

    CharacterController characterController;
    [HideInInspector]
    public Vector3 moveDirection = Vector3.zero;
    [HideInInspector]
    public bool canMove = true;

    Animator animator;
    public ParticleSystem magic;

    Vector3 startPos;
    Vector3 deathPos;
 
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        startPos = transform.position;

    }

    void Update()
    {

        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (right * curSpeedY);

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
            animator.SetTrigger("jump");
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);
        animator.SetBool("walking", curSpeedY >= 0.01 || -curSpeedY >= 0.01);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (characterController.isGrounded && curSpeedY <= 0f && -curSpeedY <= 0f)
            {
                animator.SetTrigger("portal");
            }
            StartCoroutine(HeavenAndHell());

        }
    }
    IEnumerator HeavenAndHell()
    {
        yield return new WaitForSeconds(0.3f);
        magic.Play();
        PelaajaManageri.instance.kamera.GetComponent<Kamera>().Portal();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DeathFloor"))
        {
            deathPos = transform.position;
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
 
        Gamemanager.Instance.DisablePlayer();
        transform.position = Vector3.Lerp(deathPos, startPos, 1f);

    }
}
