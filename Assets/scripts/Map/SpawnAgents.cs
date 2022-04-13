using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnAgents : MonoBehaviour
{
    enum SpawnState
    {
        CanSpawn,
        Spawning,
        MaxAgents
    };
    //Zmienne potrzebne do generowania agentów

    public int minTimeForSpawn = 2;
    public int maxTimerForSpawn = 10;

    public int maxAgents = 30;

    private int currentAgents = 0;

    public Vector3 offset = new Vector3(1f, 0f, 1f);
    public float offsetHeight =0.5f;

    [SerializeField]
    private GameObject agent;

    private MapManager mapManager;

    private SpawnState spawnState;
    // Start is called before the first frame update

    private void Awake()
    {
        spawnState = SpawnState.CanSpawn;
        mapManager = gameObject.GetComponent<MapManager>();
    }
    public void StartSpawning()
    {
        Vector3 boardWidth = mapManager.GetWidth() + offset;

        StartCoroutine(SpawnTimer(boardWidth));
    }
    public Vector3 ChooseCoordsToSpawn(Vector3 boardWidth)
    { 
        Vector3 coords = new Vector3(Random.Range(-boardWidth.x / 2, boardWidth.x / 2), offsetHeight, Random.Range(-boardWidth.z / 2, boardWidth.z / 2));
        return transform.position + coords;
    }
    public void DestroyAgent()
    {

        if (currentAgents >= 0)
        {
            Debug.Log(currentAgents + "odejmuje i jest: " +( currentAgents - 1));
            currentAgents--;
        }
    
    }
    public void SetAgentOnBoard(Vector3 SpawnPoint) 
    {
        GameObject _agent = Instantiate(agent, transform.position, Quaternion.identity);
        _agent.GetComponent<AgentController>().SetSpawnAgent(this);
        _agent.transform.position = SpawnPoint;
        _agent.name = "Agent " + Random.Range(1, 100000);
  
        currentAgents++;
        spawnState = SpawnState.CanSpawn;
    }
    IEnumerator SpawnTimer(Vector3 boardWidth)
    {
        int waitSeconds = Random.Range(minTimeForSpawn, maxTimerForSpawn);
       
        yield return new WaitForSeconds(waitSeconds);

        if (currentAgents >= maxAgents)
            spawnState = SpawnState.MaxAgents;
        else
            spawnState = SpawnState.CanSpawn;

        if (spawnState == SpawnState.CanSpawn)
        {
            spawnState = SpawnState.Spawning;
            SetAgentOnBoard(ChooseCoordsToSpawn(boardWidth));
        }
        StartCoroutine(SpawnTimer(boardWidth));
    }
}
