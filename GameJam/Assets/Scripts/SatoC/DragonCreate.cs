using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonCreate : MonoBehaviour
{
    public GameObject[] dragon;  //竜のオブジェクト配列(5種類)
    public int frameCount;       //フレームカウント
    public float createSpeed;    //出現間隔
    public float createCount;    //生成された竜の数
    public int comboCount;       //コンボ数(外部取得)
    public float comboMag;       //コンボ倍率
    public bool flg;



    // Start is called before the first frame update
    void Start()
    {
        frameCount = 0;
        createCount = 0;
        comboCount = FindObjectOfType<Decision>().cnt;
        comboMag = 0.0f;
        createSpeed = 250.0f*(1.0f-comboMag);
    }


    // Update is called once per frame
    void Update()
    {

        comboCount = FindObjectOfType<Decision>().cnt;
        frameCount++;

        if(frameCount>250)flg = FindObjectOfType<SlideMove>().deathflg;

        createSpeed = SpeedMag();

        //一定時間ごとに竜を生成
        if (frameCount % createSpeed == 0  || frameCount>250 && flg==true)
        {
            Instantiate(dragon[RandCreate()], new Vector3(12.0f, 0.0f, 0.0f), Quaternion.identity);
            frameCount = 0;
            //生成数の加算
            createCount++;
        }

    }

    int RandCreate()
    {

        int num = 0;            //竜の抽選番号
        bool goldflag = false;

        if (createCount>0 && createCount%10==0) goldflag = true;

        num = Random.Range(0, 4);

        if (goldflag == true) num = 4;

        return num;
    }//RandCreate終了


    float SpeedMag()
    {
        //5コンボずつ出現速度が上がる
        if (comboCount > 0 && comboCount >= 5)
        {
            return 250.0f * 0.35f;

        }
        else if (comboCount > 0 && comboCount >= 10)
        {

            return 250.0f * 0.25f;

        }
        else
        {
            return 250.0f * 0.8f;
        }
    }//SpeedMag終了
}
