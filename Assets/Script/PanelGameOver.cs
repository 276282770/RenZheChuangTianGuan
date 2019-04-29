using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PanelGameOver : MonoBehaviour
{
    public Text txtScore;
    Animator anim;

    public static PanelGameOver Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.gamming&& Input.GetKeyDown(KeyCode.W))
        {
            if (GameManager.Instance.gameOverTime > 0&&Time.time-GameManager.Instance.gameOverTime>5)
            OnBack();
        }
    }
    public void SetScore(int num)
    {
        txtScore.text = "得分："+num.ToString();
    }
    public void OnShow()
    {
        anim.Play("Panel_down");
    }

    public void OnRetry()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnBack()
    {
        SceneManager.LoadScene("Start");
    }

}
