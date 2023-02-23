using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] endPanels;

    [SerializeField]
    private GameObject tutorialPanel;

    [SerializeField]
    TextMeshProUGUI timerText, scoreTextWin, scoreTextLose, currentScore;

    [SerializeField]
    private GameObject[] abilities;

    public static UIManager uiManagerInstance;

    private PlayerCannon playerCannon;
    private void Awake()
    {
        if (uiManagerInstance == null)
            uiManagerInstance = this;

        playerCannon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCannon>();

        if(GameManager.gameManagerInstance.tutorial == true)
        {
            Time.timeScale = 0;
            tutorialPanel.SetActive(true);
        }
    }

    private void Update()
    {
        currentScore.text = "Score: " + GameManager.gameManagerInstance.score.ToString();
        timerText.text = ((int)GameManager.gameManagerInstance.CurrentTime).ToString();

        UpdateAbility();
    }

    void UpdateAbility()
    {
        for(int i = 0; i < abilities.Length; i++)
        {
            if (i == playerCannon.ability - 1)
                abilities[i].transform.localScale = new Vector3(1.2f, 1.2f, 1f);

            else
                abilities[i].transform.localScale = new Vector3(1f, 1f, 1f);

        }
    }

    public void GameOver()
    {
        scoreTextLose.text = "Score: " + GameManager.gameManagerInstance.score.ToString();
        endPanels[1].SetActive(true);
        if (endPanels[1].activeSelf)
            Time.timeScale = 0;
    }

    public void YouWin()
    {
        scoreTextWin.text = "Score: " + GameManager.gameManagerInstance.score.ToString();
        endPanels[0].SetActive(true);
        if (endPanels[0].activeSelf)
            Time.timeScale = 0;
    }

    public void LoadScene(string sceneName)
    {
        for(int i = 0; i < endPanels.Length; i++)
        {
            endPanels[i].SetActive(false);
        }

        GameManager.gameManagerInstance.score = 0;
        GameManager.gameManagerInstance.CurrentTime = GameManager.gameManagerInstance.matchTime;
        SceneManager.LoadScene(sceneName);
    }
    
    public void ExitTutorial()
    {
        tutorialPanel.SetActive(false);
        GameManager.gameManagerInstance.tutorial = false;
        Time.timeScale = 1;
    }
}
