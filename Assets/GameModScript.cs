using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameModScript : MonoBehaviour {

    [SerializeField]
    private PusherScript[] pushers;

    [SerializeField]
    private Slider pushValueSlider;

    [SerializeField]
    private GameObject spherePrefab;

    [SerializeField]
    private Color[] materialColors;

    [SerializeField]
    private bool ballTimerGenerateActive=false;

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetPushSpeed()
    {
        for (int i = 0; i < pushers.Length; i++)
        {
            pushers[i].SetPushSpeed(pushValueSlider.value);
        }
    }

    public void GenerateRandomBall()
    {
        Vector3 newPos = new Vector3(-3.3f + Random.RandomRange(0, 3.0f), 3.47f, 1.34f - Random.RandomRange(0, 3.0f));
        GameObject sphere = (GameObject) Instantiate(spherePrefab, newPos, Quaternion.identity);

        int rand = Random.Range((int)0, (int)4);

        sphere.GetComponent<MeshRenderer>().material.color = materialColors[rand];
        sphere.GetComponent<BallScript>().colorID = rand;
    }

	// Use this for initialization
	void Start () {
        if (ballTimerGenerateActive)
        {
            InvokeRepeating("GenerateRandomBall", 4.0f, 5.0f);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
