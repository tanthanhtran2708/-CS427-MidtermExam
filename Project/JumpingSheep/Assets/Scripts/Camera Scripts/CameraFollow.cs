﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private float damping = 2f;
    private float height = 10f;
    private Vector3 startPos;
    private bool canFollow;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        startPos = transform.position;
        canFollow = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }
    void Follow()
    {
        if (canFollow)
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(player.position.x + 10f, player.position.y + height, player.transform.position.z - 10f), Time.deltaTime * damping);
        }
    }
    public bool CanFollow
    {
        get
        {
            return canFollow;
        }
        set
        {
            canFollow = value;
        }
    }
}
