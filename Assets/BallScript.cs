using UnityEngine;

public class BallScript : MonoBehaviour {
    public int colorID=0;

    public float maxForce = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal void AddBackForce()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(maxForce/2*Random.Range(-1, 1.0f), 0, -maxForce));
    }
}
