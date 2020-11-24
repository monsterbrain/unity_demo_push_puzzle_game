using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushGameManager : MonoBehaviour {
    [SerializeField]
    private PusherScript[] leftPushers;

    [SerializeField]
    private PusherScript[] centerPushers;

    [SerializeField]
    private PusherScript[] rightPushers;

    [SerializeField]
    private PushPullButtonScript[] leftButtons;

    [SerializeField]
    private PushPullButtonScript[] rightButtons;

    [SerializeField]
    private PushPullButtonScript[] centerButtons;

    void Start ()
    {
        for (int i = 0; i < leftButtons.Length; i++)
        {
            leftButtons[i].SetGameManager(this);
            rightButtons[i].SetGameManager(this);
            centerButtons[i].SetGameManager(this);
        }
	}
	
	void Update ()
    {
		
	}

    internal void OnCancelPushBlock(int pushButtonID, int fromPosition)
    {
        if (fromPosition == 0)//left buttons
        {
            leftPushers[pushButtonID].StopPushing();
        }
        else if (fromPosition == 1)//center buttons
        {
            centerPushers[pushButtonID].StopPushing();
        }
        else if (fromPosition == 2)//Right Buttons
        {
            rightPushers[pushButtonID].StopPushing();
        }
    }

    /// <summary>
    /// Start Pushing the block
    /// </summary>
    /// <param name="pushButtonID">which push button</param>
    /// <param name="fromPosition">left, center or right</param>
    public void OnPushBlock(int pushButtonID, int fromPosition)
    {
        if (fromPosition == 0)//left buttons
        {
            leftPushers[pushButtonID].StartPushing();
        }
        else if (fromPosition == 1)//center buttons
        {
            centerPushers[pushButtonID].StartPushing();
        }
        else if (fromPosition == 2)//Right Buttons
        {
            rightPushers[pushButtonID].StartPushing();
        }
    }
}
