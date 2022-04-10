using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAgents : MonoBehaviour
{

    //Zmienne potrzebne do generowania agentów

    public int minTimeForSpawn;
    public int maxTimerForSpawn;

    public int maxAgents;

    [SerializeField]
    private GameObject agent;

    private MapManager mapManager;
    // Start is called before the first frame update
    void Start()
    {
        mapManager = gameObject.GetComponent<MapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
