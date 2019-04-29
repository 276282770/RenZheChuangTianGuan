using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int health = 100;  //生命值
    public int score = 0;  //分数
    public bool gamming = false;
    public float gameOverTime = -1;  //游戏结束时间
    public float dieLine = 6;


    Player player;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        player = GameObject.FindObjectOfType<Player>();

        iniGame();
    }
    /// <summary>
    /// 初始化游戏
    /// </summary>
    void iniGame()
    {
        score = 0;
        health = 100;
        PanelGame.Instance.SetScore(score);
        PanelGame.Instance.SetHealth(health);
        if(SoundManager.Instance!=null)
        SoundManager.Instance.PlayCountDown();
        
        Invoke("GameStart", 5);
    }
    public void GameStart()
    {
        if(SoundManager.Instance!=null)
        SoundManager.Instance.PlayBGM();
        gamming = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (gamming)
        {
            player.Run();
            SetScore();
            CheckPlayerPos();
        }
    }
    public void GameOver()
    {
        gamming = false;
        gameOverTime = Time.time;
        player.Die();
        PanelGameOver.Instance.SetScore(score);
        PanelGameOver.Instance.Invoke("OnShow",2);
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayGameOver();
            SoundManager.Instance.StopBGM();
        }
    }
    void CheckPlayerPos()
    {
        if (transform.position.y - player.transform.position.y > dieLine)
        {
            GameOver();
        }
    }
    /// <summary>
    /// 扣血
    /// </summary>
    /// <param name="num">减血数量</param>
    public void LoseHealth(int num)
    {
        if (player.invincible)
            return;
        health -= num;
        if (health <= 0)
        {
            
            GameOver();
        }
        else
        {
            player.SetInvincible(true);
        }
        PanelGame.Instance.SetHealth(health);
    }
    /// <summary>
    /// 加血
    /// </summary>
    /// <param name="num">加血数量</param>
    public void AddHealth(int num)
    {
        health += num;
        if (health > 100)
            health = 100;
        PanelGame.Instance.SetHealth(health);
    }
    public void SetScore()
    {
        int posY=(int)player.transform.position.y;
        if (posY> score)
        {
            score = posY;
            PanelGame.Instance.SetScore(score);
        }
    }
}
