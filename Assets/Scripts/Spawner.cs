using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	public GameObject enemyToSpawn;

	
	public float spawnDelayMin = 5.0f;
	public float spawnDelayMax = 8.0f;
	
	public bool isLeft = false;
	public float baseEnemySpeed = 3.5f;
	
	private float _nextSpawnTime = 0.0f;
	private GameObject _spawnedEnemy = null;
	private Transform _t = null;

	// Use this for initialization
	void Start () 
	{
		//Caching the transform
		_t = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.time > _nextSpawnTime)
		{
			//Setting the time for the next spawn
			_nextSpawnTime = Time.time + Random.Range(spawnDelayMin, spawnDelayMax);
			
			//Spawning the enemy
			_spawnedEnemy = Instantiate(enemyToSpawn, _t.position, Quaternion.identity) as GameObject;
            EnemyScript es = _spawnedEnemy.GetComponent<EnemyScript>();
            es.SetSpeed(baseEnemySpeed);
		}
	}

}
