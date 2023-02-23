using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationStates : MonoBehaviour
{
    private SpriteRenderer enemySpriteRenderer;
    private EnemyMain enemyMain;

    [SerializeField]
    private Animator enemyAnimator;

    [SerializeField]
    private Transform frontalCannonPos;

    [SerializeField]
    private Sprite[] lifeStates1, lifeStates2;

    private void Awake()
    {
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        enemyMain = GetComponent<EnemyMain>();
    }

    private void Update()
    {
        ChangeStates();
    }

    private void ChangeStates()
    {
        if (enemyMain.enemyType == "Chaser")
        {
            if (enemyMain.health < (enemyMain.maxHealth / 5) * 3 && enemyMain.health > (enemyMain.maxHealth / 5) * 2)
                enemySpriteRenderer.sprite = lifeStates1[0];

            else if (enemyMain.health < (enemyMain.maxHealth / 5) * 2 && enemyMain.health > (enemyMain.maxHealth / 5))
                enemySpriteRenderer.sprite = lifeStates1[1];
        }
        else if (enemyMain.enemyType == "Shooter")
        {
            if (enemyMain.health < (enemyMain.maxHealth / 5) * 3 && enemyMain.health > (enemyMain.maxHealth / 5) * 2)
                enemySpriteRenderer.sprite = lifeStates2[0];

            else if (enemyMain.health < (enemyMain.maxHealth / 5) * 2 && enemyMain.health > (enemyMain.maxHealth / 5))
                enemySpriteRenderer.sprite = lifeStates2[1];
        }
    }

    public IEnumerator OnDeath()
    {
        enemyAnimator.gameObject.transform.position = enemyMain.transform.position;
        enemyAnimator.gameObject.transform.localScale = new Vector3(1.4f, 1.4f, 1f);
        enemyAnimator.SetBool("Dead", true);
        yield return new WaitForSeconds(0.5f);
        enemyAnimator.SetBool("Dead", false);
        enemySpriteRenderer.color = new Color(0, 0, 0, 0);
        UIManager.uiManagerInstance.GameOver();
    }

    public IEnumerator OnExplosionFrontal()
    {
        enemyAnimator.gameObject.transform.position = frontalCannonPos.position;
        enemyAnimator.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
        enemyAnimator.SetBool("Fire", true);
        yield return new WaitForSeconds(0.5f);
        enemyAnimator.SetBool("Fire", false);
    }
}

