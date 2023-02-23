using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed = 8f;

    [HideInInspector]
    public float bulletDamage;

    private void Start()
    {
        StartCoroutine(DestroyBullet());
    }
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMain>().TakeDamage(bulletDamage);
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