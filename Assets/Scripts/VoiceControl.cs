using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class VoiceControl : MonoBehaviour
{
    private GameObject player;
    private Player playerScript;
    private Rigidbody2D rb;
    private GameObject elevatorNow;
    private bool isFacingRight = true;

    private string[] keywords = { "jump", "run", "stop", "fire", "start","up","back","down" };
    private KeywordRecognizer keywordRecognizer;

    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public bool isGrounded = true;
    private bool isRunning = false;
    

    private void OnEnable()
    {
        DontDestroyOnLoad(this);

        keywordRecognizer = new KeywordRecognizer(keywords);
        keywordRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void OnDisable()
    {
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            keywordRecognizer.Stop();
        }
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        switch (args.text)
        {
            case "start":
                StartGame();
                break;
            case "jump":
                Jump();
                break;
            case "run":
                Run();
                break;
            case "stop":
                Stop();
                break;
            case "back":
                Back();
                break;
            
            case "up":
                UpofVoice();
                break;
            case "down":
                DownofVoice();
                break;
        }
    }

    private void StartGame()
    {
        if (SceneManager.GetActiveScene().name == "0")
        {
            SceneManager.LoadScene("1");
        }
    }

    private void FindPlayer()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                rb = player.GetComponent<Rigidbody2D>();
                playerScript = player.GetComponent<Player>();
            }
        }
    }


    private void Jump()
    {
        FindPlayer();
        if (player != null && isGrounded)
        {
            Debug.Log("Jumping!");
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void Run()
    {
        FindPlayer();
        if (player != null)
        {
            Debug.Log("Running!");
            isRunning = true;
        }
    }

    private void Stop()
    {
        FindPlayer();
        if (player != null)
        {
            Debug.Log("Stopping!");
            isRunning = false;
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }


    private void Back()
    {
        FindPlayer();
        if (player != null)
        {
            // **翻转角色朝向**
            isFacingRight = !isFacingRight;
            player.transform.Rotate(0, 180, 0);

            // **获取 Rigidbody2D**
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // **更新刚体速度方向**
                float speed = Mathf.Abs(rb.velocity.x);  // 保持速度大小
                rb.velocity = new Vector2(isFacingRight ? speed : -speed, rb.velocity.y);
            }

            Debug.Log("Player turned back!");
        }
    }





    private void UpofVoice()
    {
        FindPlayer();
        if (player != null&&playerScript.currentElevator !=null)
        {
            playerScript.currentElevator.Up();
            
        }
    }


    private void DownofVoice()
    {
        FindPlayer();
        if (player != null && playerScript.currentElevator != null)
        {
            playerScript.currentElevator.Down();
            
        }

    }

    private void FixedUpdate()
    {
        if (isRunning && rb != null)
        {
            rb.velocity = new Vector2(isFacingRight ? moveSpeed : -moveSpeed, rb.velocity.y);
        }
    }


    
}
