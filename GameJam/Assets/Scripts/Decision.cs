using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision : MonoBehaviour
{
    /// <summary>
    /// 成功判定
    /// </summary>
    public bool good = false;
    /// <summary>
    /// 失敗判定
    /// </summary>
    public bool bad = false;
    /// <summary>
    /// コンボ数
    /// </summary>
    public int combo = 0;
    /// <summary>
    /// 倍率変更のカウント
    /// </summary>
    public int cnt = 0;
    /// <summary>
    /// スコア倍率
    /// </summary>
    public float magni = 1.0f;

    /// <summary>
    /// 0:普通 1:妥協 2:ゴージャス
    /// </summary>
    public int grade = 0;

    public float score = 0;


    // Start is called before the first frame update
    void Start()
    {
        good = false;
        bad = false;

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        God();
    }

    void God() {

        //龍に目を付けるのに成功したとき
        if (good && bad == false) {
            Debug.Log("成功");
            switch (grade) {
                case 0:
                score += 200 * magni;
                break;

                case 1:
                score += 100 * magni;
                break;

                case 2:
                score += 300 * magni;
                break;
            }
            combo++;
            cnt++;
            if (cnt == 10) {
                magni = magni + 0.2f;
                cnt = 0;
            }
            good = false;
        }

        //失敗したとき
        if (good == false && bad) {
            Debug.Log("失敗");

            score -= 200;
            if(score < 0) {
                score = 0;
            }

            combo = 0;
            cnt = 0;
            magni = 1.0f;

            bad = false;
        }

    }
}
