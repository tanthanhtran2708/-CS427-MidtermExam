using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float movementForce = 0.5f, jumpForce = 0.15f;
    private float jumpTime = 0.15f;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }
    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Jump(true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Jump(false);
        }
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.x > Screen.width / 2)
                {
                    //move right
                    Jump(false);
                }
                if (touch.position.x < Screen.width / 2)
                {
                    //move left
                    Jump(true);
                }
            }
        }
    }
    void Jump(bool left)
    {
        SoundManager.instance.JumpSound();
        if (left)
        {
            transform.DORotate(new Vector3(0f, 90f, 0f),0f);
            rb.DOJump(new Vector3(transform.position.x - 0.5f, transform.position.y + 0.15f, transform.position.z), 0.5f, 1, jumpTime);
        }
        else
        {
            transform.DORotate(new Vector3(0f, -180, 0f), 0f);
            rb.DOJump(new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z + 0.5f), 0.5f, 1, jumpTime);

        }
    }
}
