using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherScript : MonoBehaviour {
    [SerializeField]
    private bool isHorizontal = false;

    [SerializeField]
    private bool isRightToLeft = false;

    private bool isPushing = false;

    private bool isPullingBack = false;

    [SerializeField]
    private float PushSpeed = 2;

    private Vector3 initPos;
    private float pullTimer=0;

    void Start () {
        initPos = transform.position;
    }

    public void SetPushSpeed(float pushSpeed)
    {
        PushSpeed = pushSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        if (isPullingBack)
        {
            pullTimer += Time.deltaTime;
            Vector3 pos = Vector3.Lerp(transform.position, initPos, pullTimer);
            transform.position = pos;
            if (pullTimer > 1)
            {
                transform.position = initPos;
                isPullingBack = false;
            }
        }
        else if (isPushing)
        {
            Vector3 pos = transform.position;
            if (isHorizontal)
            {
                if (isRightToLeft)
                {
                    pos.x -= PushSpeed * Time.deltaTime;
                }
                else
                {
                    pos.x += PushSpeed * Time.deltaTime;
                }
            }
            else
            {
                pos.z += PushSpeed * Time.deltaTime;
            }
                
            transform.position = pos;
        }
	}

    public void StartPushing()
    {
        isPushing = true;
        if (isPullingBack)
        {
            isPullingBack = false;
        }
    }

    public void StopPushing()
    {
        isPushing = false;

        isPullingBack = true;
        pullTimer = 0;
    }
}
