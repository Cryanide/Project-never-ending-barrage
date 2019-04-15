using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class PauseManager : MonoBehaviour {

    CanvasGroup cg;
    public Button btnPause;

    public AudioScript AudioSrc;
    public AudioSource PauseMenuMusic;

	// Use this for initialization
	void Start () {
        cg = GetComponent<CanvasGroup>();
        if (!cg)
            cg = gameObject.AddComponent<CanvasGroup>();

        cg.alpha = 0.0f;

        if (btnPause)
            btnPause.onClick.AddListener(PauseGame);

        AudioSrc = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioScript>();
	}
	
	
    // Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();
	}

    public void PauseGame()
    {
        if (cg.alpha == 0)
        {
            cg.alpha = 1.0f;
            Time.timeScale = 0.0f;
            AudioSrc.NoVocals.Pause();
            AudioSrc.Vocals.Pause();
            PauseMenuMusic.Play();
        }
        else
        {
            cg.alpha = 0.0f;
            Time.timeScale = 1.0f;
            AudioSrc.NoVocals.UnPause();
            AudioSrc.Vocals.UnPause();
            PauseMenuMusic.Pause();
        }
    }

    public void BackToTitle()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Screen_Menu");
    }
}
