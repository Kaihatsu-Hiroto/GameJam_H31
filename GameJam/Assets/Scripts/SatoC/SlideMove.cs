using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMove : MonoBehaviour
{
    public float dir = 1.0f;         //移動方向
    public float speed = 3.0f;       //移動スピード
    public float comboSpeed = 1.0f;  //コンボ時のスピード倍率
    public int count;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        count++;

        //左方向に移動
        transform.position -= new Vector3(dir * speed * comboSpeed * Time.deltaTime , 0 , 0);

        Destroy(this.gameObject , 15.0f);

    }
}
