using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    
    public Rigidbody2D ball; 

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;

        InitializeBall();
    }
    public void InitializeBall() 
    { 
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        ball.velocity = dir.normalized * 10f;

        ball.transform.position = Vector3.zero;
    
    }


}
