using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2.0f;
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
        transform.position += (movingRight ? Vector3.right : Vector3.left) * speed * Time.deltaTime;
        
        if (timer <= 0)
        {
            movingRight = !movingRight;
            timer = moveTime;
        }

    }
}
