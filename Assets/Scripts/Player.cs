using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public elevator currentElevator; // ��ǰ�Ӵ��ĵ���
    private float fallTime = 0f; // ��¼����ʱ��
    private bool isFalling = false; // �Ƿ�����������
    public float fallThreshold = 2f;
    private VoiceControl v;// ��������������
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
            fallTime = 0f; // ���û�����䣬����ʱ��
        }
    }

    private bool IsFalling()
    {
        // ����Ƿ����ڿ�������
        return rb.velocity.y < -0.1f && !IsGrounded();
    }

    private bool IsGrounded()
    {
        // ���߼�����
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
            // �������ʱ�䳬����ֵ���ҽӴ����棬��������
            Destroy(gameObject);
            dead.gameObject.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
           v.isGrounded = true;
        }
    }
}
