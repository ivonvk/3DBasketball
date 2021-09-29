using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class BallController : MonoBehaviour
{
    public int mScore = 0;
    public float power = 0.0f;
    public float powerSpeed = 10.0f;
    public Text scoreText;
    public Text timeText;
    public float fTime;
    bool checkIfThrow;
    bool stop;
    public Animator animSetting;
    public GameObject GameOver;
    bool holding;
    public Text txtTotalScore;
    public bool stopGaming;
    public AudioSource sHit;
    public AudioSource sStop;
    public AudioSource sThrow;
    public AudioSource sGameOver;
    public GameObject btnBack;
    public Slider powerBar;
    private Rigidbody rb;
    Vector3 pos ;
    public bool changing;
    void Start()

    {
        fTime = 60f;

        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 0);
        rb.isKinematic = true;
        
        scoreText.text = "Score: 0";
        timeText.text = "Time: 0";
        pos = rb.position;
        rb.position = pos;
        animSetting.Play("GameUIAnim_Reset");
    }
    void Update()
    {
      
        /*if (power >= 10.0f || power <= 0.0f)
        {
            powerSpeed = -powerSpeed;
        }*/
        timeText.text = "Time: " + fTime.ToString("F0");
        powerBar.value = power;

        if (fTime > 0)
        {
            fTime -= 1f * Time.deltaTime;
        }else if (fTime < 0)
        {
       
                sGameOver.Play();
            
            
            txtTotalScore.text = mScore.ToString();
            GameOver.SetActive(true);
            
            fTime = 0f;
            stopGaming = true;
            btnBack.SetActive(false);
        }
        
        
        
        
        if (!stopGaming &&!changing )
        {
            if (Input.GetButtonDown("Fire1"))
            {
                holding = true;

            }else if (Input.GetButtonUp("Fire1"))
            {
                holding = false;
            }
            if (holding)
            {
                power += powerSpeed * Time.deltaTime;
                if (power > 10f || power < 0f)
                {
                    powerSpeed = -powerSpeed;
                }
            }
            if (Input.GetButtonUp("Fire1") && !checkIfThrow)
            {
                sThrow.Play();
                checkIfThrow = true;
                //holding = false;
                rb.isKinematic = false;
                rb.AddForce(Vector3.up * (power * 52));
                rb.AddForce(Vector3.forward * 150);
                rb.AddForce(Vector3.right * 1);
            }
            
            if (rb.position.y <= 0.5)
            {
                power = 0;
                
                stop = false;
                rb.velocity = new Vector3(0, 0, 0);
                rb.isKinematic = true;
                rb.position = pos;
                animSetting.Play("GameUIAnim_Reset");
                checkIfThrow = false;
            }
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "PointEvent" && checkIfThrow && !stop && !stopGaming)
        {
            power = 0;
            sHit.Play();
            rb.velocity = new Vector3(rb.velocity.x, 0.5f, 0f);
            stop = true;
            mScore += 1;
            scoreText.text = "Score: " + mScore;
        }
    }
}