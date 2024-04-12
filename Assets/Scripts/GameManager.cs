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


}
