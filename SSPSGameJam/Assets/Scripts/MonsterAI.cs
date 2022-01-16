using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{

    [SerializeField]
    private float degree = 0f;
    public float speed = 4.8f;
    private Vector2 playerPosition;
    public Transform player;
    public Transform spawnPosition;
    public Rigidbody2D monsterRB;
    public float tempPlayerSpeed;
    public float tempMonsterSpeed;
    public static bool isInReactor = false;

    private float currentTime = 0;

    private void Update()
    {
        playerPosition = new Vector2(player.position.x, player.position.y);
        Debug.Log(isInReactor);
        if (isInReactor)
        {
            MonsterAppearance();
            Debug.Log(currentTime);
            currentTime += Time.deltaTime;
        }
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
        monsterRB.transform.position += speed * Time.fixedDeltaTime * (-transform.up);
        Debug.Log(monsterRB.transform.position);
    }

    private void MonsterAppearance()
    {
        switch(currentTime)
        {
            case 0:
                PlayerRotate.canRotate = false;
                monsterRB.position = spawnPosition.position;

                tempPlayerSpeed = PlayerMovement.moveSpeed;
                tempMonsterSpeed = speed;
                speed = 0f;
                PlayerMovement.moveSpeed = 0f;
                break;
            case 3:
                PlayerMovement.moveSpeed = tempPlayerSpeed;
                speed = tempMonsterSpeed;

                PlayerRotate.canRotate = true;

                monsterRB.gameObject.SetActive(true);
                break;
            case 15:
                speed /= 2;
                break;
            case 20:
                monsterRB.gameObject.SetActive(false);
                break;
        }
    }
}
