using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fly : MonoBehaviour {
    Vector3 jump = new Vector3(0, 300, 0);
    public Rigidbody rb; // rb = RigidBody of Playerr
    bool isGO = false;  // isGameOver
    bool isStart; // Start
	public static int score = 0;
	public GameObject Canvas;
    private float holdTime = 0.8f;
    private float accumTime = 0;


    private void Awake()
    {
        score = 0;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
  // Update is called once per frame
    void Update () {
		if(Input.GetMouseButton(0) && !isGO)
        {
            if (!isStart)
            {
                isStart = true;
            }
            Flying();
        }

        if(Input.touchCount > 0)
        {
            accumTime += Input.GetTouch(0).deltaTime;

            if (accumTime >= holdTime)
            {
                SceneManager.LoadScene("Main");
            }

            if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                accumTime = 0;
            }
        }
	}

    void Flying()
    {
        rb.velocity = new Vector3(0, 0, 4);
        rb.AddForce(jump);
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ScoreArea")
        {
			score+= 1;
			Destroy (other.gameObject);
        }

    }

    void OnCollisionEnter(Collision other) 
    {
		if (other.collider.tag == "DeathAreaPipes"|| other.collider.tag == "DeathAreaGround")
        {
           isGO = true;
           Canvas.SetActive(true);
        }
    }


}
