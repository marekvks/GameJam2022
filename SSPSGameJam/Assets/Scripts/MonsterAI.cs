using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterAI : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    public float degree = 0f;
    private float speed = 4.8f;
    private Vector2 playerPosition;
    public Transform player;
    public Rigidbody2D monsterRB;
    private float tempPlayerSpeed;
    private float tempMonsterSpeed;

>>>>>>> parent of 4b5a6fd (MonsterAI)

    private void Update()
    {
        playerPosition = new Vector2(player.position.x, player.position.y);
<<<<<<< HEAD
        MonsterDisappear();
=======
>>>>>>> parent of 4b5a6fd (MonsterAI)
    }

    private void FixedUpdate()
    {
        MonsterMove();
        Rotate();
    }

    IEnumerator MonsterAppearance()
    {
        tempPlayerSpeed = PlayerMovement.moveSpeed;
        tempMonsterSpeed = speed;
        speed = 0f;
        PlayerMovement.moveSpeed = 0f;
        yield return new WaitForSeconds(3);
        PlayerMovement.moveSpeed = tempPlayerSpeed;
        speed = tempMonsterSpeed;

        monsterRB.gameObject.SetActive(true);
        yield return new WaitForSeconds(15);
        speed /= 2;
        yield return new WaitForSeconds(5);
        monsterRB.gameObject.SetActive(false);
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

<<<<<<< HEAD
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "East")
        {
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
                gameObject.SetActive(false);
            }
        }
    }
=======

>>>>>>> parent of 4b5a6fd (MonsterAI)
}

