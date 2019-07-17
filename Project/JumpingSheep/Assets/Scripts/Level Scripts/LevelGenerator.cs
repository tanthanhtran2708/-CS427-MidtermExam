﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject startPlatform, endPlatform, platformPrefab;
    private float blockWidth = 0.5f, blockHeight = 0.2f;
    private int amountToSpawn = 10;
    [SerializeField]
    private int beginAmount = 0;
    private Vector3 lastPos;
    private List<GameObject> spawnedPlatforms = new List<GameObject>();
    [SerializeField]
    private GameObject playerPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        InstantiateLevel();
    }

    // Update is called once per frame
    void InstantiateLevel()
    {
        for (int i=beginAmount; i< amountToSpawn*GameplayController.instance.GetLevel(); i++)
        {
            GameObject newPlatform;
            if (i == 0)
            {
                newPlatform = Instantiate(startPlatform);

            }
            else if(i== amountToSpawn * GameplayController.instance.GetLevel() - 1) {
                newPlatform = Instantiate(endPlatform);
                newPlatform.tag = "EndPlatform";
            } else
            {
                newPlatform = Instantiate(platformPrefab);
            }
            newPlatform.transform.parent = transform;
            spawnedPlatforms.Add(newPlatform);
            if( i==0)
            {
                lastPos = newPlatform.transform.position;
                Vector3 temp = lastPos;
                temp.y += 0.1f;
                Instantiate(playerPrefab, temp, Quaternion.identity);
                continue;
            }
            int left = Random.Range(0, 2);
            if(left == 0)
            {
                newPlatform.transform.position = new Vector3(lastPos.x - blockWidth, lastPos.y + blockHeight, lastPos.z);
            }
            else
            {
                newPlatform.transform.position = new Vector3(lastPos.x, lastPos.y + blockHeight, lastPos.z + blockWidth);
            }
            lastPos = newPlatform.transform.position;
            if (i < 25)
            {
                float endPos = newPlatform.transform.position.y;
                newPlatform.transform.position =
                    new Vector3(newPlatform.transform.position.x,
                    newPlatform.transform.position.y - blockHeight * 3f,
                    newPlatform.transform.position.z);
                newPlatform.transform.DOLocalMoveY(endPos, 0.3f).SetDelay(i * 0.1f);
            }
        }
    }
}
