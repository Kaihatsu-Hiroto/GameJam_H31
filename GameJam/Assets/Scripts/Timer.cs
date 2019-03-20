using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //カウントダウンの開始値
    public int MAX_TIME = 60;
    public float timeCounter = 60;
    /// <summary>
    /// カウントを開始するトリガー
    /// </summary>
    public bool trg = false;

    // Use this for initialization
    void Start() {
        trg = false;
        GetComponent<Text>().text = MAX_TIME.ToString();
    }


    // Update is called once per frame
    void Update() {
        if (trg) {
            timeCounter -= Time.deltaTime;
            if (timeCounter <= 0) {
                FindObjectOfType<Ready>().trg = true;
            }
            //マイナス値にならないようにする
            timeCounter = Mathf.Max(timeCounter , 0.0f);
            GetComponent<UnityEngine.UI.Text>().text = ((int)timeCounter).ToString();
        }
    }

   

    

}
