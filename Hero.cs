using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private int _health = 10;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private Transform _rayPoint;
    [SerializeField] private float _rayLenght = 1 / 3;
    [SerializeField] public int score;
    [SerializeField] TextMeshProUGUI textMesh;

    private Vector3 direction;
    public bool IsGrounded;
    private Rigidbody2D _player;
    private SpriteRenderer _sprite;
    public bool IsDeath;
    public bool isBoomDeath;
    public bool PlayerInCell = false;
    private int pressCounter = 0;

    private void Awake()
    {
        _player = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        LoadSave();
        UpdateScore();
        IsDeath = false;
    }

    void GroundCheck()
    {
        //IsGrounded = Physics2D.Raycast(_rayPoint.position, Vector2.down) ? false : true;
        var a = Physics2D.Raycast(_rayPoint.position, Vector2.down).point;
        if (Physics2D.Raycast(_rayPoint.position, Vector2.down, _rayLenght))
        {
            IsGrounded = true;
        }
        else
            IsGrounded = false;
        Debug.DrawLine(_rayPoint.position, a);
    }

    private void Run()
    { 
        direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + direction, _speed * Time.deltaTime);
        _sprite.flipX = direction.x < 0f;
        /*
         * BAD PRACTICS эксперт с stackoverflow говорит, что изменение transform.position||rotation подходит для изменение позиции объекта, но не для перемещения
         */
    }
    private void Jump()
    {
        _player.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
        SpaceCounter();
        GroundCheck();
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            Jump();
        }
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
        if (this.transform.position.y < -6 && _health != 0)
        {
            Death();
        }
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Escape();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coitn))
        {
            score++;
            UpdateScore();
            Destroy(collision.gameObject);
        }
        if (collision.TryGetComponent(out Spikes spie))
        {
            IsDeath = true;
            Invoke("Death", 0.25f);
        }
        if (collision.TryGetComponent(out Boom bomb))
        {
            isBoomDeath = true;
            Invoke("Death", 0.25f);
        }

    }
    public void Death()
    {
        _health--;
        SaveGame();
        RestartGame();
        if (_health <= 0)
        {
            SceneManager.LoadScene(0);
            PlayerPrefs.DeleteAll();
        }
    }
    void SaveGame()
    {
        PlayerPrefs.SetInt("Live", _health);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }
    void LoadSave()
    {
        if (PlayerPrefs.HasKey("Live"))
        {
            _health = PlayerPrefs.GetInt("Live");
            score = PlayerPrefs.GetInt("Score");
        }
    }
    void UpdateScore()
    {
        textMesh.text = "Очки: " + score.ToString();
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Escape()
    {      
        if (PlayerInCell && pressCounter == 2)
        {
            Debug.Log("player escape: TRUE");
            pressCounter = 0;
            EventBus.onKrakenCatchStart -= SpaceCounter;
            EventBus.onKrakenCatchEnd?.Invoke();
            PlayerInCell = false;
        }
    }
    public void SpaceCounter()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            pressCounter++;
    }
    public void EscapeStart()
    {
        PlayerInCell = true;
    }
    public void DestroyCell(GameObject cell)
    {
        Destroy(cell);
    }
    public void ResetSpaceCounter()
    {
        pressCounter = 0;
    }

    
}
