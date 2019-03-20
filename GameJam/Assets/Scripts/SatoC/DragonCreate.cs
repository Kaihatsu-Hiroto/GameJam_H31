using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonCreate : MonoBehaviour
{
    public GameObject[] dragon;  //竜のオブジェクト配列(5種類)
    public int frameCount;       //フレームカウント
    public int createCount;      //生成された竜の数

    // Start is called before the first frame update
    void Start() {

    }


    // Update is called once per frame
    void Update() {
        frameCount++;

        //一定時間ごとに竜を生成
        if (frameCount % 250 == 0) {
            Instantiate(dragon[RandCreate()] , new Vector3(12.0f , 0.0f , 0.0f) , Quaternion.identity);
            //生成数の加算
            createCount++;
        }



    }

    int RandCreate() {
        int num = 0;            //竜の抽選番号
        bool goldflag = false;

        if (createCount == 29 || createCount == 59) goldflag = true;

        num = Random.Range(0 , 4);

        if (goldflag == true) num = 4;

        return num;
    }
}
