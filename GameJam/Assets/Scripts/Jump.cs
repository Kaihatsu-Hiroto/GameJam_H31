using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    private SpriteRenderer sprRen;

    private Rigidbody2D rigidbody2d;

    public Sprite sprDefo;
    public Sprite sprRE;
    public Sprite sprBE;
    public Sprite sprGE;
    public Sprite sprYE;
    public Sprite sprBLE;

    /// <summary>
    /// オブジェクトの動く方向
    /// </summary>
    public float x, y, r;
    /// <summary>
    /// 目の色変更
    /// </summary>
    public int num;
    /// <summary>
    /// 消えるまでの時間
    /// </summary>
    private int time = 180;
    /// <summary>
    /// 色変えのトリガー
    /// </summary>
    public int trg = 0;
    /// <summary>
    /// 0:赤 1:青 2:緑 3:黄色 4:黒
    /// </summary>
    public int color = 0;
    /// <summary>
    /// 判定を取るトリガー
    /// </summary>
    public bool col = false;

    public bool good = false;
    public bool bad = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        sprRen = GetComponent<SpriteRenderer>();

        Ram();

        num = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        Decision();

        Change();
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "RE") {
            trg = 1;
            //緑
            if (color == 2) {
                col = true;
                good = true;
            } else if(color == 4) {
                col = true;
                good = true;
            } else {
                col = true;
                bad = true;
            }
        }

        if (other.gameObject.tag == "BE") {
            trg = 2;
            //黄
            if (color == 3) {
                col = true;
                good = true;
            }
            else if (color == 4) {
                col = true;
                good = true;
            } else {
                col = true;
                bad = true;
            }
        }

        if (other.gameObject.tag == "GE") {
            trg = 3;
            //赤
            if (color == 0) {
                col = true;
                good = true;
            }
            else if (color == 4) {
                col = true;
                good = true;
            } else {
                col = true;
                bad = true;
            }
        }

        if (other.gameObject.tag == "YE") {
            trg = 4;
            //青
            if (color == 1) {
                col = true;
                good = true;
            }
            else if (color == 4) {
                col = true;
                good = true;
            } else {
                col = true;
                bad = true;
            }
        }

        if (other.gameObject.tag == "BLE") {
            trg = 5;
            col = true;
            good = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "RE") {
            trg = 0;
            col = false;
            good = false;
            bad = false;
        }

        if (other.gameObject.tag == "BE") {
            trg = 0;
            col = false;
            good = false;
            bad = false;
        }

        if (other.gameObject.tag == "GE") {
            trg = 0;
            col = false;
            good = false;
            bad = false;
        }

        if (other.gameObject.tag == "YE") {
            trg = 0;
            col = false;
            good = false;
            bad = false;
        }

        if (other.gameObject.tag == "BLE") {
            trg = 0;
            col = false;
            good = false;
            bad = false;
        }
    }

    void Decision() {
        if (col) {
            if (Input.GetMouseButtonUp(0) && good) {
                Fly();

                switch (trg) {
                    case 1:
                    num = 1;
                    break;

                    case 2:
                    num = 2;
                    break;

                    case 3:
                    num = 3;
                    break;

                    case 4:
                    num = 4;
                    break;

                    case 5:
                    num = 5;
                    break;
                }

                col = false;
            }
            if(Input.GetMouseButtonUp(0) && bad) {
                Fall();

                switch (trg) {
                    case 1:
                    num = 1;
                    break;

                    case 2:
                    num = 2;
                    break;

                    case 3:
                    num = 3;
                    break;

                    case 4:
                    num = 4;
                    break;

                    case 5:
                    num = 5;
                    break;
                }

                col = false;
            }
        }
    }

    /// <summary>
    /// 入れた目の色によって龍のスプライトを変更
    /// </summary>
    void Change() {
        switch (num) {
            //デフォルト
            case 0:
            sprRen.sprite = sprDefo;
            break;
            //赤
            case 1:
            sprRen.sprite = sprRE;
            break;
            //青
            case 2:
            sprRen.sprite = sprBE;
            break;
            //緑
            case 3:
            sprRen.sprite = sprGE;
            break;
            //黄
            case 4:
            sprRen.sprite = sprYE;
            break;
            //黒
            case 5:
            sprRen.sprite = sprBLE;
            break;
        }
    }

    void Ram() {
        x = Random.Range(0 , -50);
        y = Random.Range(20 , 30);
        r = Random.Range(-10 , -30);
    }

    /// <summary>
    /// 飛んでく動き
    /// </summary>
    void Fly() {
        rigidbody2d.velocity = new Vector2(x , y);

        Dead();
    }
    /// <summary>
    /// 落下する動き
    /// </summary>
    void Fall() {

        rigidbody2d.gravityScale = 3.0f;     
        
        transform.rotation = Quaternion.Euler(0 , 0 , r);
    }

    void Dead() {
        time--;

        if (time < 0) {
            Destroy(this.gameObject);
        }
    }
}
