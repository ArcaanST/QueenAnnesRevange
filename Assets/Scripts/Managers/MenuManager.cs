using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] menus;

    [SerializeField]
    private string scene;

    [SerializeField]
    TMP_InputField timeToSpawnEnemies, timeToEndMatch;

    private void Awake()
    {
        Time.timeScale = 1;
        timeToSpawnEnemies.text = "3";
        timeToEndMatch.text = "3";
    }

    public void OpenOptions()
    {
        BindTimers();
        menus[0].SetActive(false);
        menus[1].SetActive(true);
    }

    public void CloseOptions()
    {
        BindTimers();
        menus[0].SetActive(true);
        menus[1].SetActive(false);
    }

    public void BindTimers()
    {
        //Enemies spawn
        string textSpawnInput = timeToSpawnEnemies.text.ToString();
        float spawnTime = float.Parse(textSpawnInput);
        GameManager.gameManagerInstance.spawnTime = spawnTime;

        //Match duration
        string textMatchInput = timeToEndMatch.text.ToString();
        float matchTime = float.Parse(textMatchInput);
        GameManager.gameManagerInstance.matchTime = matchTime * 60;
    }

    public void LoadScene()
    {
        GameManager.gameManagerInstance.SetTimer();
        SceneManager.LoadSceneAsync(scene);
    }
}
