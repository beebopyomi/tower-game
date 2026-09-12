using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class WaveData
{
    public float duration = 10f;
    public int RedBalloons = 5;
    public int BlueBalloons = 2;
    public int GreenBalloons = 1;
    public int YellowBalloons = 0;
    public int PinkBalloons = 0;
    public int BlackBalloons = 0;
    public int WhiteBalloons = 0;
    public int ZebraBalloons = 0;
    public int LeadBalloons = 0;
    public int RainbowBalloons = 0;
    public int CeramicBalloons = 0;
}
public class WaveManager : MonoBehaviour
{
    public WaveData[] waves; 
    public Button startWaveButton;
    public GameObject RedBaloonPrefab;
    public GameObject BlueBaloonPrefab;
    public GameObject GreenBaloonPrefab;
    public GameObject YellowBaloonPrefab;
    public GameObject PinkBaloonPrefab;
    public GameObject BlackBaloonPrefab;
    public GameObject WhiteBaloonPrefab;
    public GameObject ZebraBaloonPrefab;
    public GameObject LeadBaloonPrefab;
    public GameObject RainbowBaloonPrefab;
    public GameObject CeramicBaloonPrefab; 
    
    public Transform[] wayPoints;
    private int currentWaveIndex = 0;
    private bool waveRunning = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startWaveButton.onClick.AddListener(startWave);
    }
    public void startWave()
    {
        if (waveRunning) return;
        if (currentWaveIndex >= waves.Length) return;
        StartCoroutine(RunWave());
    }
    IEnumerator RunWave()
    {
        waveRunning = true;
        startWaveButton.interactable = false;
        WaveData wave = waves[currentWaveIndex];
        for (int i = 0; i < wave.RedBalloons; i++)
        {
            SpawnEnemy(RedBaloonPrefab);
            yield return new WaitForSeconds((wave.duration /3) / wave.RedBalloons);
        }
        for (int i = 0; i < wave.BlueBalloons; i++)
        {
            SpawnEnemy(BlueBaloonPrefab);
            yield return new WaitForSeconds((wave.duration /3) / wave.BlueBalloons);
        }
        for (int i = 0; i < wave.GreenBalloons; i++)
        {
            SpawnEnemy(GreenBaloonPrefab);
            yield return new WaitForSeconds((wave.duration /3) / wave.GreenBalloons);
        }
        for (int i = 0; i < wave.YellowBalloons; i++)
        {
            SpawnEnemy(YellowBaloonPrefab);
            yield return new WaitForSeconds((wave.duration /3) / wave.YellowBalloons);
        }
        for (int i = 0; i < wave.PinkBalloons; i++)
        {
            SpawnEnemy(PinkBaloonPrefab);
            yield return new WaitForSeconds((wave.duration /3) / wave.PinkBalloons);
        }
        for (int i = 0; i < wave.BlackBalloons; i++)
        {
            SpawnEnemy(BlackBaloonPrefab);
            yield return new WaitForSeconds((wave.duration /3) / wave.BlackBalloons);
        }
        for (int i = 0; i < wave.WhiteBalloons; i++)
        {
            SpawnEnemy(WhiteBaloonPrefab);
            yield return new WaitForSeconds((wave.duration /3) / wave.WhiteBalloons);
        }
        for (int i = 0; i < wave.ZebraBalloons; i++)
        {
            SpawnEnemy(ZebraBaloonPrefab);
            yield return new WaitForSeconds((wave.duration /3) / wave.ZebraBalloons);
        }
        for (int i = 0; i < wave.LeadBalloons; i++)
        {
            SpawnEnemy(LeadBaloonPrefab);
            yield return new WaitForSeconds((wave.duration /3) / wave.LeadBalloons);
        }
        for (int i = 0; i < wave.RainbowBalloons; i++)
        {
            SpawnEnemy(RainbowBaloonPrefab);
            yield return new WaitForSeconds((wave.duration /3) / wave.RainbowBalloons);
        }
        for (int i = 0; i < wave.CeramicBalloons; i++)
        {
            SpawnEnemy(CeramicBaloonPrefab);
            yield return new WaitForSeconds((wave.duration /3) / wave.CeramicBalloons);
        }
        yield return new WaitForSeconds(wave.duration / 3);
        waveRunning = false;
        startWaveButton.interactable = true;
        currentWaveIndex++;
    }
    void SpawnEnemy(GameObject prefab)
    {
        GameObject e = Instantiate(prefab, wayPoints[0].position, Quaternion.identity);
        Enemy enemy = e.GetComponent<Enemy>();
        enemy.waypoints = wayPoints;
    }
}
