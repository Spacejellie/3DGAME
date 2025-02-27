using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.2f;
    public GameObject enemy;
    public float moveTime = 2.0f;
    public float resetTime = 2.0f;
    public bool changeDir = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveTime -= Time.deltaTime;
        if(moveTime >= 0)
        {
            enemy.transform.position += Vector3.right * speed;
        }
        if (moveTime <= 0 && changeDir == false)
        {
            enemy.transform.position += Vector3.left * speed;
        }
        if(moveTime <= -resetTime)
        {
            moveTime = resetTime;
            enemy.transform.position += Vector3.right * speed;
            changeDir = true;
        }
        if (moveTime <= 0)
        {
            changeDir = false;
        }
    }
}
