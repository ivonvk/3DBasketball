using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanging : MonoBehaviour {
    Animator anim;
    BallController BC;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        BC = GameObject.FindGameObjectWithTag("Player").GetComponent<BallController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   
    public void animBack()
    {
        BC.changing = true;
        anim.Play("GameUIAnim_Back");
        
    }
    public void BackToTitle()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void animStopChanging()
    {
        BC.changing = false;
    }
}
