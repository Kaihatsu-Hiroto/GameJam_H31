using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ready : MonoBehaviour {

    [SerializeField]
    private Text ready;

    /// <summary>
    /// リザルト画面への遷移のトリガー
    /// </summary>
    public bool trg = false;
    private bool end = false;

    // Start is called before the first frame update
    void Start() {
        trg = false;
        end = false;
        ready.text = "";
        StartCoroutine(ReadyCoroutine());
    }

    void Update() {

        if (trg) {
            StartCoroutine(FinishCoroutine());
        }

        if (end) {
            FadeScene();
            end = false;
        }
    }

    IEnumerator ReadyCoroutine() {
        ready.gameObject.SetActive(true);

        ready.text = "READY";
        yield return new WaitForSeconds(2.0f);

        ready.text = "GO!!";
        yield return new WaitForSeconds(1.0f);

        ready.text = "";
        //ready.gameObject.SetActive(false);
        FindObjectOfType<Timer>().trg = true;
    }

    IEnumerator FinishCoroutine() {
        ready.gameObject.SetActive(true);

        ready.text = "FINISH";
        yield return new WaitForSeconds(2.0f);

        end = true;
    }

    public void FadeScene() {
        FadeManager.Instance.LoadScene("Result" , 1.0f);
    }
}
