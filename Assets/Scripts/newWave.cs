using UnityEngine;
using System.Collections;

public class newWave : MonoBehaviour
{
    public GameObject[] SpawnPoints;

    public GameObject EnemyPrefab;
    private Object BossPrefab;
    public int enemiesAmount;
    public int bossAmount;
    private int bossInterval = 7;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float baseEnemySpeed = 3.5f;
    public static int waves;
    private GameObject pos;

    void Start()
    {
        BossPrefab = Resources.Load("BossEnemy");
        StartCoroutine(SpawnWaves());
        SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        waves = 1;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            CreateWave();
            for (int i = 0; i < enemiesAmount; i++)
            {
                pos = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
                if ((i % bossInterval) == 0 && i != 0)
                    Instantiate(BossPrefab, pos.transform.position, Quaternion.identity);
                else
                    Instantiate(EnemyPrefab, pos.transform.position, Quaternion.identity);


                EnemyScript es = EnemyPrefab.GetComponent<EnemyScript>();
                es.SetSpeed(baseEnemySpeed);
                yield return new WaitForSeconds(spawnWait);
            }
            Instantiate(BossPrefab, pos.transform.position, pos.transform.rotation);
            yield return new WaitForSeconds(waveWait);
            newWave.waves++;
        }
    }

    private void CreateWave()
    {
        enemiesAmount = waves * 5;
        bossAmount = (int)Mathf.Floor(enemiesAmount / bossInterval);
    }

    void Update()
    {
        PlayerPrefs.SetInt("Waves", waves);
        PlayerPrefs.Save();
    }
    void OnGUI()
    {
        GUI.Label(new Rect(0, 50, 100, 25), "Waves: " + waves);
    }
}

