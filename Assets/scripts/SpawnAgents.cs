using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAgents : MonoBehaviour
{

    //Zmienne potrzebne do generowania agentów

    public int minTimeForSpawn;
    public int maxTimerForSpawn;

    public int maxAgents;

    public Vector3 offset = new Vector3(1f, 0f, 1f);
    public float offsetHeight =0.5f;

    [SerializeField]
    private GameObject agent;

    private MapManager mapManager;
    // Start is called before the first frame update

    private void Awake()
    {
        mapManager = gameObject.GetComponent<MapManager>();
    }
    void Start()
    {
        Vector3 boardWidth = mapManager.GetWidth() + offset;

        ChooseCoordsToSpawn(boardWidth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 ChooseCoordsToSpawn(Vector3 boardWidth)
    { 
        return new Vector3(Random.Range(-boardWidth.x / 2, boardWidth.x / 2), offsetHeight, Random.Range(-boardWidth.z / 2, boardWidth.z / 2)); 
    }
}
