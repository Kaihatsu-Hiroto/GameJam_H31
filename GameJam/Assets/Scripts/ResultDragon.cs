using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultDragon : MonoBehaviour
{

    //移動ベクトル
    Vector3 velocity;

    //Rigidbody2D コンポーネント
    Rigidbody2D rigidbody2d;

    //SpriteRendererコンポーネント
    SpriteRenderer spRenderer;

    //ジャンプするようになるトリガー  true = ジャンプする  false = ジャンプしない
    public bool isJump = false;

    //着地できるレイヤー
    public LayerMask groundLayer;

    //反転スイッチ
    bool Run_switch = true;

    public bool trg = false;

    public int time = 15;

    //地面についているか
    bool isGround;

    //メインカメラのタグ
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";

    //カメラに写ってるかの判定
    private bool isRendered = false;

    // Use this for initialization
    void Start() {

        rigidbody2d = GetComponent<Rigidbody2D>();
        spRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update() {

        Reverse();

        //地面に接しているか
        isGround = Physics2D.Linecast(
            transform.position + transform.up * 1 , transform.position - transform.up * 1.1f , groundLayer);

    }

    void OnCollisionEnter2D(Collision2D col) {
        string layerName = LayerMask.LayerToName(col.gameObject.layer);

        if (layerName == "Ground" && isJump == true) {
            isGround = true;
            Jump();
        }
    }

    /*エネミーがジャンプする関数*/
    void Jump() {
        isGround = false;
        //上方向に力を加える
        rigidbody2d.AddForce(Vector2.up * 800);
    }

    void Reverse() {

        time--;

        if(time < 0) {

            if (trg) {
                trg = false;
            } else {
                trg = true;
            }

            time = 15;
        }


        if (trg) {
            spRenderer.flipX = true;
        } else {
            spRenderer.flipX = false;
        }

    }

    public Vector3 GetDirection() {
        //ベクトルの向きだけが欲しいから正規化する
        return velocity.normalized;
    }

    public bool IsGround() {
        return isGround;
    }
}
