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

<<<<<<< HEAD
    private Decision decison;
=======
    private AudioSource se01;
    private AudioSource se02;
    private AudioSource bgm01;
>>>>>>> Kaihatsu

    // Start is called before the first frame update
    void Start() {
        AudioSource[] audioSources = GetComponents<AudioSource>();

        se01 = audioSources[0];
        bgm01 = audioSources[1];
        se02 = audioSources[2];

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
        se01.PlayOneShot(se01.clip);
        bgm01.Play();
        yield return new WaitForSeconds(1.0f);

        ready.text = "";
        //ready.gameObject.SetActive(false);
        FindObjectOfType<Timer>().trg = true;
    }

    IEnumerator FinishCoroutine() {
        ready.gameObject.SetActive(true);

        ready.text = "FINISH";
        bgm01.Stop();
        se02.PlayOneShot(se02.clip);

        yield return new WaitForSeconds(2.0f);

        end = true;
    }

    public void FadeScene() {
        FadeManager.Instance.LoadScene("Result" , 1.0f);
    }
}
