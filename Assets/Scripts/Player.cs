using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public elevator currentElevator; // 当前接触的电梯
    private float fallTime = 0f; // 记录下落时间
    private bool isFalling = false; // 是否在自由落体
    public float fallThreshold = 2f;
    private VoiceControl v;// 下落多少秒后销毁
    public Jiemian dead;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        v = GameObject.Find("V").GetComponent<VoiceControl>();
    }

    private void Update()
    {
        if (IsFalling())
        {
            fallTime += Time.deltaTime;
        }
        else
        {
            fallTime = 0f; // 如果没有下落，重置时间
        }
    }

    private bool IsFalling()
    {
        // 检测是否正在快速下落
        return rb.velocity.y < -0.1f && !IsGrounded();
    }

    private bool IsGrounded()
    {
        // 射线检测地面
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Elevator"))
        {
            currentElevator = other.GetComponent<elevator>();
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Elevator") && currentElevator == other.GetComponent<elevator>())
        {
            currentElevator = null;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && fallTime >= fallThreshold)
        {
            // 如果下落时间超过阈值并且接触地面，销毁物体
            Destroy(gameObject);
            dead.gameObject.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
           v.isGrounded = true;
        }
    }
}
