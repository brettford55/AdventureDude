using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] float reloadPause = 3f;
    [SerializeField] int score = 0;


    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;




    private void Awake()
    {

        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString() ;
    }


    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();

    }
    public void ProcessPlayerDeath()
    {

        

        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }

        
    }

    private void TakeLife()
    {
        playerLives -= 1;
        livesText.text = playerLives.ToString();


        var currentScene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(TimeBetweenReload(currentScene));

    }

    private void ResetGameSession()
    {
        int startScene = 1;
        StartCoroutine(TimeBetweenReload(startScene));
        StartCoroutine(DestroyGO());
    }

    IEnumerator TimeBetweenReload(int levelIndex)
    {
        yield return new WaitForSecondsRealtime(reloadPause);
        SceneManager.LoadScene(levelIndex);
    }
    IEnumerator DestroyGO()
    {
        yield return new WaitForSecondsRealtime(reloadPause);
        Destroy(gameObject);
    }
}

