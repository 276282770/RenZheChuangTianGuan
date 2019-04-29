using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Pads : MonoBehaviour
{
    public GameObject[] goodPads;  //好台阶预制体
    public GameObject[] badPads;  //坏台阶预制体
    public GameObject[] prop;  //道具
    public float startX = -6f;  //开始的X值
    public float startY = -2f;  //开始的Y值
    public float space = 2.5f;  //台阶上下间距
    public float maxHorSpace = 0.5f; //最大左右偏移距离
    public Vector2 bound;
    public float prob = 0.7f;  //生成好台阶的概率
    public float probDaoJu = 0.3f;  //生成道具的概率

    string[] indexes = new string[15];
    string[] matrixes = new string[15];
    int preMode=0;
    int layer = 0;
    Transform camTran;

    // Start is called before the first frame update
    void Start()
    {
        camTran = Camera.main.transform;
        FillIndexes();
        FillMatrixes();

        CreatePads();
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)(Time.time) % 5 == 0)
        {
            CheckCreate();
        }
    }
    void CheckCreate()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (camTran.position.y - child.position.y > 10)
            {
                Destroy(child.gameObject);
            }
        }
        if (transform.childCount < 50)
        {
            CreatePads();
        }
    }
    public void CreatePads()
    {

        int _maxLayer = layer + 20;
        for (int i = layer; i < _maxLayer; i++)
        {

            



            string[] mode = indexes[preMode].Split(',');
            int idx = Random.Range(0, mode.Length);
            preMode = int.Parse(mode[idx]);
            string ss = matrixes[preMode];
            for (int j = 0; j < ss.Length; j++)
            {
                GameObject[] padStyle= SelPad(i);

                if (ss[j] == '0')
                {
                    continue;
                }
                float horSpace = Random.Range(-maxHorSpace, maxHorSpace);

                float x = startX + j * 4 + horSpace;
                float y = space * i + startY;
                Vector3 pos = new Vector3(x, y, 0);
                GameObject item = Instantiate(padStyle[0], pos, Quaternion.identity, transform);
                //生成道具
                if (padStyle[1] != null)
                {
                    Instantiate(padStyle[1], pos + new Vector3(0, 0.6f, 0), Quaternion.identity, transform);
                }
                //Thread.Sleep(20);
            }
            //Thread.Sleep(20);

        }
        layer = _maxLayer;
    }
    /// <summary>
    /// 选择台阶和道具
    /// </summary>
    /// <param name="layer">层</param>
    /// <returns>0台阶，1道具 null为无</returns>
    GameObject[] SelPad(int layer)
    {
        GameObject[] result = new GameObject[2];
        GameObject _pad = goodPads[0];//台阶
        GameObject _daoJu = prop[0];
        bool isGoodBad = Random.Range(0, 1f) < prob;
        if (layer <= 5)
        {
            //_pad = goodPads[0];
        }
        else if (layer <= 15)
        {


            if (isGoodBad)
            {
                _pad = goodPads[0];
            }
            else
                _pad = badPads[0];
        }
        else if (layer <= 35)
        {


            if (isGoodBad)
            {
                _pad = goodPads[1];
            }
            else
                _pad = badPads[1];
        }
        else if (layer <= 65)
        {


            if (isGoodBad)
            {
                _pad = goodPads[2];
            }
            else
                _pad = badPads[2];
        }
        else if (layer <= 100)
        {


            if (isGoodBad)
            {
                _pad = goodPads[3];
            }
            else
                _pad = badPads[3];
        }
        else
        {
            int _idx = Random.Range(0,goodPads.Length);
            if (isGoodBad)
                _pad = goodPads[_idx];
            else
                _pad = badPads[_idx];
        }
        result[0] = _pad;
        

        //生成道具
        float rdmDaoJu = Random.Range(0, 1f);
        if (isGoodBad && rdmDaoJu < probDaoJu)
        {
            //Instantiate(_daoJu, pos + new Vector3(0, 0.6f, 0), Quaternion.identity, transform);
            result[1] = _daoJu;
        }
        return result;
    }

    void FillIndexes()
    {
        indexes[0] = "1,2,3,4,5,6,7,8,9,10,11,12,13,14";
        indexes[1] = "0,2,3,4,5,6,7,8,9,11,12";
        indexes[2] = "0,1,3,4,5,6,8,9,10,12";
        indexes[3] = "0,1,2,4,6,8,9,13";
        indexes[4] = "0,1,2,3,6,7,8,9,10,13,14";
        indexes[5] = "0,1,2,3,4,6,8,9,10,12,13";
        indexes[6] = "0,1,2,3,4,7,8,9";
        indexes[7] = "0,1,2,3,4,6,8,9";
        indexes[8] = "0,1,2,3,4,6,7,9";
        indexes[9] = "0,1,2,3,4,6,8";
        indexes[10] = "0,1,2,3,4,5,6,8,9,12,13";
        indexes[11] = "0,1,2,3,4,5,6,7,8,9,12";
        indexes[12] = "0,1,2,3,4,5,6,8,9";
        indexes[13] = "0,1,2,3,4,6,8,9,10";
        indexes[14] = "0,1,2,3,4,6,7,8,9,10,13";
    }
    void FillMatrixes()
    {
        matrixes[0] = "1111";
        matrixes[1] = "1110";
        matrixes[2] = "1101";
        matrixes[3] = "1011";
        matrixes[4] = "0111";
        matrixes[5] = "0011";
        matrixes[6] = "0101";
        matrixes[7] = "1001";
        matrixes[8] = "0110";
        matrixes[9] = "1010";
        matrixes[10] = "1100";
        matrixes[11] = "0001";
        matrixes[12] = "0010";
        matrixes[13] = "0100";
        matrixes[14] = "1000";
    }
}
