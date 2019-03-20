using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMove : MonoBehaviour
{
    public float dir;         //移動方向
    public float speed;       //移動スピード
    public int comboCount;    //コンボ数(外部取得)
    public float comboMag;  //コンボ時のスピード倍率


    // Start is called before the first frame update
    void Start() {
        //初期化
        dir = 1.0f;
        comboMag = 0.0f;
        speed = 3.5f;
        comboCount = FindObjectOfType<Decision>().cnt;
    }

    // Update is called once per frame
    void Update() {

        comboCount = FindObjectOfType<Decision>().cnt;
        speed = SpeedMag();

        //左方向に移動
        transform.position -= new Vector3(dir *speed * Time.deltaTime , 0 , 0);

        //一定時間後に削除
        Destroy(this.gameObject , 15.0f);

    }

    float SpeedMag()
    {
        //5コンボずつ移動速度が上がる
        if (comboCount > 0 && comboCount >= 5)
        {
            return 6.5f;

        }
        else if (comboCount > 0 && comboCount >= 10)
        {
            return 7.0f;
        }
        else
        {
            return 4.0f;
        }

    }//SpeedMag終了

}
