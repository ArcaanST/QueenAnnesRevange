using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatonStates : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;
    private PlayerMain playerMain;
    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private Sprite[] lifeStates;

    private void Awake()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerMain = GetComponent<PlayerMain>();
    }

    private void Update()
    {
        ChangeStates();
    }

    private void ChangeStates()
    {
        if (playerMain.health < (playerMain.maxHealth/5)*3  && playerMain.health > (playerMain.maxHealth/5)*2)
            playerSpriteRenderer.sprite = lifeStates[0];

        else if (playerMain.health < (playerMain.maxHealth/5)*2 && playerMain.health > (playerMain.maxHealth/5))
            playerSpriteRenderer.sprite = lifeStates[1];
    }

    public IEnumerator OnDeath()
    {
        playerAnimator.gameObject.transform.position = playerMain.transform.position;
        playerAnimator.gameObject.transform.localScale = new Vector3(1.4f, 1.4f, 1f);
        playerAnimator.SetBool("Dead", true);
        yield return new WaitForSeconds(0.5f);
        playerAnimator.SetBool("Dead", false);
        playerSpriteRenderer.color = new Color(0, 0, 0, 0);
        UIManager.uiManagerInstance.GameOver();
    }

    public IEnumerator OnExplosionRight()
    {
        playerAnimator.gameObject.transform.position = playerMain.bulletSpawnLateralRight[1].transform.position;
        playerAnimator.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
        playerAnimator.SetBool("Fire", true);
        yield return new WaitForSeconds(0.5f);
        playerAnimator.SetBool("Fire", false);
    }

    public IEnumerator OnExplosionLeft()
    {
        playerAnimator.gameObject.transform.position = playerMain.bulletSpawnLateralLeft[1].transform.position;
        playerAnimator.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
        playerAnimator.SetBool("Fire", true);
        yield return new WaitForSeconds(0.5f);
        playerAnimator.SetBool("Fire", false);

    }

    public IEnumerator OnExplosionFrontal()
    {
        playerAnimator.gameObject.transform.position = playerMain.bulletSpawnFrontal.transform.position;
        playerAnimator.gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
        playerAnimator.SetBool("Fire", true);
        yield return new WaitForSeconds(0.5f);
        playerAnimator.SetBool("Fire", false);
    }
}
