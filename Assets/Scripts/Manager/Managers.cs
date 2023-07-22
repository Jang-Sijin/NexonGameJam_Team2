using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    public static Managers instance;
    [Header("#Game Control")]
    public PlayerController _player;
    public PoolManager Pool;
    public int speed;
    public bool isLive;

    [Header("#Player Info")]
    public float health;
    public float maxHealth = 100;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 30, 60, 100, 150, 210, 180, 360, 450, 600, 700, 800, 1000, 1200 };
    
    [Header("#Game Object")]
    public float _gameTime;
    public float _maxGameTime = 30 * 60f;
    // public LevelUp uiLevelUp;
    // public ReStart uiResult;
    public GameObject enemyCleaner;

    void Awake()
    {
        instance = this;
    }
    public void GameStart()
    {
        health = maxHealth;
        // uiLevelUp.Select(0);
        Resume();
    }

    public void GameReStart()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        StartCoroutine(GameObverRoutine());
    }

    IEnumerator GameObverRoutine()
    {
        isLive = false;
        yield return new WaitForSeconds(1f);
        // uiResult.gameObject.SetActive(true);
        // uiResult.Lose();
        Stop();
    }


    public void GameWin()
    {
        StartCoroutine(GameWinRoutine());
    }

    IEnumerator GameWinRoutine()
    {
        isLive = false;
        enemyCleaner.SetActive(true);

        yield return new WaitForSeconds(1f);
        // uiResult.gameObject.SetActive(true);
        // uiResult.Win();
        Stop();
    }


    void Update()
    {
        if (!isLive) return;

        _gameTime += Time.deltaTime;
        if (_gameTime > _maxGameTime)
        {
            _gameTime = _maxGameTime;
            // GameWin();
        }
    }

    public void GetExp(int value)
    {
        if (!isLive) return;
        exp += value;
        if (exp >= nextExp[Mathf.Min(level, nextExp.Length - 1)])
        {
            level++;
            exp = 0;
            // uiLevelUp.show();
        }
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }

}