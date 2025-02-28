using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.2f;
    public GameObject enemy;
    public float resetTime = 2.0f;
    public float moveTime = 2.0f;
    private float timer;
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        timer = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer > 0)
        {
            transform.position += (movingRight ? Vector3.right : Vector3.left) * speed;
        }
        else
        {
            movingRight = !movingRight;
            timer = moveTime;
        }
    }
}
