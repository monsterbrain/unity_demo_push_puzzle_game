using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPullButtonScript : MonoBehaviour {
    private PushGameManager manager;

    [SerializeField]
    private int pushButtonID = 0;

    [SerializeField]
    private int screenPos = 0;

    public void SetGameManager(PushGameManager manager)
    {
        this.manager = manager;
    }

	void Start () {
		
	}

    public void OnButtonPushDown()
    {
        manager.OnPushBlock(pushButtonID, screenPos);
    }

    public void OnButtonUp()
    {
        manager.OnCancelPushBlock(pushButtonID, screenPos);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
