using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public float degree = 0f;
    private float speed = 4.8f;
    private Vector2 playerPosition;
    public Transform player;
    public Rigidbody2D monsterRB;
    private float tempPlayerSpeed;
    private float tempMonsterSpeed;


    private void Update()
    {
        playerPosition = new Vector2(player.position.x, player.position.y);
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
        monsterRB.transform.position += speed * Time.fixedDeltaTime * (-transform.up);
        Debug.Log(monsterRB.transform.position);
    }


}
