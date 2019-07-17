using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    private AudioSource gameStart, gameEnd, coinSound, jumpSound;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void GameStartSound()
    {
        gameStart.Play();
    }
    public void GameEndSound()
    {
        gameEnd.Play();
    }
    public void PickUpCoin()
    {
        coinSound.Play();
    }
    public void JumpSound()
    {
        jumpSound.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
