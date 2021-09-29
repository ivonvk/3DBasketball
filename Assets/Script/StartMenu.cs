using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour {
    Animator anim;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartGame()
    {
        SceneManager.LoadScene("Demo");
    }
    public void btnQuit()
    {
        Application.Quit();
    }
    public void animStart()
    {
        anim.Play("TitleAnim_Start");
    }
}
