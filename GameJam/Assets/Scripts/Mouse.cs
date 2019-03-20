using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    /// <summary>
    /// 通常成功判定
    /// </summary>
    public bool trg = false;
    /// <summary>
    /// スコアを変動させる判定
    /// </summary>
    public bool onActive = false;

    Vector3 pos;

    public float StartX;
    public float StartY;

    /// <summary>
    /// 0:赤 1:青 2:緑 3:黄色 4:黒
    /// </summary>
    public int color = 0;

    // Start is called before the first frame update
    void Start() {
        pos = transform.position;
        StartX = pos.x;
        StartY = pos.y;
    }

    // Update is called once per frame
    void Update() {
        Decision();
    }

    /// <summary>
    /// ドラゴンに触れてるときの判定
    /// </summary>
    void Decision() {
        if (trg) {
            if (Input.GetMouseButtonUp(0)) {

                pos.x = StartX;
                pos.y = StartY;
                transform.position = pos;

                if (onActive) {
                    FindObjectOfType<Decision>().good = true;
                    
                }

                onActive = false;
                trg = false;
            }
        }
        else {
            if (Input.GetMouseButtonUp(0)) {

                pos.x = StartX;
                pos.y = StartY;
                transform.position = pos;

                if (onActive) {
                    FindObjectOfType<Decision>().bad = true;
                }

                onActive = false;
                trg = false;
            }
        }        
    }

    void OnMouseDown() {
        onActive = true;
        // このオブジェクトの位置(transform.position)をスクリーン座標に変換。
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        // ワールド座標上の、マウスカーソルと、対象の位置の差分。
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , Input.mousePosition.y , screenPoint.z));
    }

    void OnMouseDrag() {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x , Input.mousePosition.y , screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //ドラゴンの顔との当たり判定
        if (other.gameObject.tag == "RedD") {
            //緑
            if (color == 2) {
                trg = true;
                FindObjectOfType<Decision>().grade = 0;
            }

            //黒
            else if (color == 4) {
                trg = true;
                FindObjectOfType<Decision>().grade = 1;
            }
        }

        if (other.gameObject.tag == "BlueD") {
            //黄
            if (color == 3) {
                trg = true;
                FindObjectOfType<Decision>().grade = 0;
            }

            //黒
            else if (color == 4) {
                trg = true;
                FindObjectOfType<Decision>().grade = 1;
            }
        }

        if (other.gameObject.tag == "GreenD") {
            //赤
            if (color == 0) {
                trg = true;
                FindObjectOfType<Decision>().grade = 0;
            }

            //黒
            else if (color == 4) {
                trg = true;
                FindObjectOfType<Decision>().grade = 1;             
            }
        }

        if (other.gameObject.tag == "YellowD") {
            //青
            if (color == 1) {
                trg = true;
                FindObjectOfType<Decision>().grade = 0;
            }

            //黒
            else if (color == 4) {
                trg = true;
                FindObjectOfType<Decision>().grade = 1;
            }
        }

        if (other.gameObject.tag == "GoldD") {
            //黒
            if (color == 4) {
                trg = true;
                FindObjectOfType<Decision>().grade = 2;
            }

            //黒以外の色
            else {
                trg = true;
                FindObjectOfType<Decision>().grade = 1;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        //ドラゴンの顔以外の判定
        if (other.gameObject.tag == "RedD") {
            trg = false;
        }

        if (other.gameObject.tag == "BlueD") {
            trg = false;
        }

        if (other.gameObject.tag == "GreenD") {
            trg = false;
        }

        if (other.gameObject.tag == "YellowD") {
            trg = false;
        }

        if (other.gameObject.tag == "GoldD") {
            trg = false;
        }
    }

}
