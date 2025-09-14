using System;
using TMPro;
using Unity.Mathematics;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 0.5f; //put f after float
    private Animator animator;
    bool isWalk = false;
    bool goLeft = true;
    bool goRight = true;
    bool goUp = true;
    bool goDown = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 currentPos = transform.position;
        Vector3 target = new Vector3(currentPos.x, currentPos.y, -6);
        Camera.main.transform.position = target;

        if (Input.GetKey(KeyCode.W) && goUp)
        {
            currentPos.y += speed * Time.deltaTime;
            animator.SetBool("walk", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S) && goDown)
        {
            currentPos.y -= speed * Time.deltaTime;
            animator.SetBool("walk", true);
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (Input.GetKey(KeyCode.A) && goLeft)
        {
            currentPos.x -= speed * Time.deltaTime;
            animator.SetBool("walk", true);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.D) && goRight)
        {
            currentPos.x += speed * Time.deltaTime;
            animator.SetBool("walk", true);
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        if (!Input.anyKey)
        {
            animator.SetBool("walk", false);
        }

        transform.position = currentPos;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("left"))
        {
            goLeft = false;
        }
        if (collision.CompareTag("right"))
        {
            Debug.Log("hit");
            goRight = false;
        }
        if (collision.CompareTag("top"))
        {
            Debug.Log("hit");
            goUp = false;
        }
        if (collision.CompareTag("bottom"))
        {
            goDown = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("left"))
        {
            goLeft = true;
        }
        if (collision.CompareTag("right"))
        {
            goRight = true;
        }
        if (collision.CompareTag("top"))
        {
            goUp = true;
        }
        if (collision.CompareTag("bottom"))
        {
            goDown = true;
        }
    }
}