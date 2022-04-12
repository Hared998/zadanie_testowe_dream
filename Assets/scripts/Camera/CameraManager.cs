using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AgentInfo agentInfo;

    private Quaternion defaultRotate;
    public Transform currentTarget;
    void Awake()
    {
        defaultRotate = transform.rotation;
        agentInfo.cameraManager = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentTarget != null)
        {
            if (agentInfo.GetCurrentAgent() != "NoAgent" || agentInfo.GetCurrentAgent() != "")
            {
                transform.LookAt(currentTarget);
            }
        }
        else
        {
            transform.rotation = defaultRotate;
        }
        
    }
}
