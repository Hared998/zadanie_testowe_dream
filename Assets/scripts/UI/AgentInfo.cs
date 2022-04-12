using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentInfo : MonoBehaviour
{
    public Text healthValue;
    public Text nameAgent;
    public GameObject uiInfo;
    // Start is called before the first frame update
    private string currentAgent;
    void Start()
    {
        uiInfo.SetActive(false);
    }

    public void UpdateInfo(int health, string name)
    {
        if (name == currentAgent && name != "NoAgent")
        {
            healthValue.text = health.ToString();
            nameAgent.text = name;
        }
    }
    // Update is called once per frame

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Select stage    
                if (hit.transform.tag == "Agent")
                {
                    currentAgent = hit.transform.name;
                    UpdateInfo(hit.transform.gameObject.GetComponent<AgentController>().GetHealth(), hit.transform.name);
                    uiInfo.SetActive(true);
                }
                else
                {
                    uiInfo.SetActive(false);
                    currentAgent = "NoAgent";
                }
            }
        }
    }
}
