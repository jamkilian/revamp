using UnityEngine;
using System.Collections;

public class newWave : MonoBehaviour
{
    public GameObject[] SpawnPoints;

    public GameObject EnemyPrefab;
    public int enemiesAmount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float baseEnemySpeed = 3.5f;
    public static int waves;

    void Start ()
        
    {
        StartCoroutine (SpawnWaves ());
        SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        waves = 1;
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < enemiesAmount; i++)
            {
                GameObject pos = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(EnemyPrefab, pos.transform.position, pos.transform.rotation);
                EnemyScript es = EnemyPrefab.GetComponent<EnemyScript>();
                es.SetSpeed(baseEnemySpeed);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);
        }
    }
    /*void Update()
    {
        PlayerPrefs.SetInt("Waves", waves);
        PlayerPrefs.Save();
    }
    void OnGUI()
    {
        GUI.Label(new Rect(0, 50, 100, 25), "Kills: " + kills);
    }*/
}

