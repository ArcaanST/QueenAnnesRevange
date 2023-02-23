using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;
    float damage;
    PlayerMain player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMain>();
    }

    private void Start()
    {
        speed = player.bulletSpeed;
        damage = player.bulletDamage;
        StartCoroutine(DestroyBullet());
    }
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyMain>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Wall") || collision.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(6f);
        Destroy(this);
    }
}