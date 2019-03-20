using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour {

    //現在のシーンの名前
    string SceneName;

    //効果音
    //private AudioSource se01;
    //private AudioSource se02;

    // Use this for initialization
    void Start() {
        Init();
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Init() {
        AudioSource[] audioSources = GetComponents<AudioSource>();

        //se01 = audioSources[0];
        //se02 = audioSources[1];
    }

    void Move() {
        SceneName = SceneManager.GetActiveScene().name;
        if (Input.GetMouseButtonUp(0)) {
            switch (SceneName) {
                case "Title":
                //se01.PlayOneShot(se01.clip);
                FadeManager.Instance.LoadScene("Description" , 1.0f);
                break;
                case "Description":
                //se02.PlayOneShot(se02.clip);
                FadeManager.Instance.LoadScene("Main" , 1.0f);
                break;
                case "Result":
                //se01.PlayOneShot(se01.clip);
                FadeManager.Instance.LoadScene("Title" , 1.0f);
                break;
                default:
                break;
            }
        }
    }
}
