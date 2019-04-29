using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGame : MonoBehaviour
{
    public Text txtScore;
    public Image imgHealth;
    public Text txtHealth;

    public static PanelGame Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 设置分数
    /// </summary>
    /// <param name="num">分数</param>
    public void SetScore(int num)
    {
        txtScore.text = "分数："+num.ToString();
    }
    /// <summary>
    /// 设置生命值
    /// </summary>
    /// <param name="num">值</param>
    public void SetHealth(int num)
    {
        if (num < 0)
            num = 0;
        txtHealth.text = num.ToString();
        imgHealth.fillAmount = (float)num / 100;
    }
}
