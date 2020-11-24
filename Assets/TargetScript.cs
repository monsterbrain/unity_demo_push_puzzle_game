using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {
    private float scaleTimer = 0;
    private bool isScaling = false;

    [SerializeField]
    private int colorID = 0;

    [SerializeField]
    private TextMesh countText;

    private int numBoxCollected = 0;

    // Use this for initialization
    void Start () {
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("sphere"))
        {
            Debug.Log("Sphere Collided");
            int ballColorID = other.gameObject.GetComponent<BallScript>().colorID;

            if(ballColorID == colorID)
            {
                StartScaling();
                Destroy(other.gameObject);
                numBoxCollected += 1;
                countText.text = "[" + numBoxCollected + "]";
            }
            else
            {
                //Destroy(other.gameObject);
                other.gameObject.GetComponent<BallScript>().AddBackForce();
            }
        }
    }

    private void StartScaling()
    {
        isScaling = true;
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        scaleTimer = 0;
    }

    // Update is called once per frame
    void Update () {
        if (isScaling)
        {
            scaleTimer += 1.5f*Time.deltaTime;
            float scale = 0.5f + 0.5f * Mathf.Sin(scaleTimer * 3.14f);
            gameObject.transform.localScale = new Vector3(scale, scale, scale);
            if (scaleTimer > 1)
            {
                isScaling = false;
            }
        }
	}
}
