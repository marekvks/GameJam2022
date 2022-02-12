using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{

    private float degree = 0f;
    public static float monsterSpeed = 0f;
    private Vector2 playerPosition;
    public Transform player;
    public static bool isInReactor = false;
    public static float time;
    private Rigidbody2D monsterRB;


    private void Start()
    {
        monsterRB = gameObject.GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        playerPosition = new Vector2(player.position.x, player.position.y);

        MonsterDisappear();

    }

    private void FixedUpdate()
    {
        MonsterMove();
        Rotate();
    }

    private void Rotate()
    {
        Vector2 direction = monsterRB.position - playerPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - degree;
        monsterRB.rotation = angle;
    }

    private void MonsterMove()
    {
        monsterRB.transform.position += monsterSpeed * Time.fixedDeltaTime * (-monsterRB.transform.right);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "East")
        {
            Camera.main.gameObject.SetActive(false);
            EventSystem.current.gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    private void MonsterDisappear()
    {
        if (monsterSpeed > 0f)
        {
            time += Time.deltaTime;
            if (time >= 20)
            {
                Destroy(gameObject);
            }
        }
    }
}

