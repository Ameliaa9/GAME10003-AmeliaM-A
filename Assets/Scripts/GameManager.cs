using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Rigidbody2D ball;
    public Text scoreLeftText;
    public Text scoreRightText;
    public GameObject countdownWrapper;
    public Text countdownText;

    private int _scoreLeft;
    private int _scoreRight;
    private bool gameOver = false; 

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;

        _scoreLeft = 0;
        _scoreRight = 0;

        InitializeBall();
        StartCoroutine(_CountingDown());
    }

    public void InitializeBall() //random ball movement
    {
        float angle = Random.Range(0f, 30f);
        float r = Random.Range(0f, 1f);
        if (r < 0.25f)
            angle = 180f - angle;
        else if (r < 0.5f)
            angle += 180f;
        else if (r < 0.75f)
            angle = 360f - angle;
        angle *= Mathf.Deg2Rad;

        Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        ball.velocity = dir.normalized * 10f;

        ball.transform.position = Vector3.zero;
    }

    public void IncreaseScore(bool left)
    {
        if (gameOver) // If game over return
            return;

        if (left)
        {
            _scoreLeft++;
            scoreLeftText.text = _scoreLeft.ToString();
        }
        else
        {
            _scoreRight++;
            scoreRightText.text = _scoreRight.ToString();
        }

        if (_scoreLeft >= 10 || _scoreRight >= 10)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0; // Freeze the game
    }

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Space)) // Restart the game if user presses spacebar pressed
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        // Reset scores and game over flag
        _scoreLeft = 0;
        _scoreRight = 0;
        scoreLeftText.text = "0";
        scoreRightText.text = "0";
        gameOver = false;
        Time.timeScale = 1; // Unfreeze the game
        InitializeBall();
        StartCoroutine(_CountingDown());
    }

    private IEnumerator _CountingDown()
    {
        // freeze everything
        Time.timeScale = 0;

        //count down
        for (int c = 3; c > 0; c--)
        {
            countdownText.text = c.ToString();
            yield return new WaitForSecondsRealtime(1);
        }

        countdownWrapper.SetActive(false);

        // reset the time scale 
        Time.timeScale = 1;
    }
}