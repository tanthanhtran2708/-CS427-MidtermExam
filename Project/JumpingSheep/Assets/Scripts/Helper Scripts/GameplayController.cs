using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    private static int gameLev = 1;
    private static int prefScore=0;
    [SerializeField]
    private Text scoreText;
    private static int score;
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private Text levelDisplay;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            levelDisplay.text = "Level: " + gameLev;
            slider.maxValue =(10*gameLev*0.75f) *100;
            slider.value = (10 * gameLev*0.75f) * 100;
            slider.minValue = 0;
            instance = this;
        }
    }
    public void IncrementScore()
    {
        score++;
        scoreText.text = "x" + score;
    }
    public void RestartGame()
    {
        Destroy(slider);
        Invoke("ReloadGame", 3f);
    }
    void ReloadGame()
    {
        gameLev = 1;
        score = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
    public void NextLevel()
    {
        gameLev++;
        levelDisplay.text = "Level: " + gameLev;
        score = prefScore;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
    public int GetLevel()
    {
        return gameLev;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value--;
        if(slider.value ==0)
        {
            RestartGame();
        }
    }
}
