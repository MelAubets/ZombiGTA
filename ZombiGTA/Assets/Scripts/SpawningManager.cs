using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Cars;
    [SerializeField]
    private GameObject peasant;
    [SerializeField]
    private GameObject zombi;
    [SerializeField]
    private Transform spawnCar1, spawnCar2;
    [SerializeField]
    private Transform spawnWander;
    private Transform[] spawnsWander;
    [SerializeField]
    private Transform startSpawnZombi;
    private Transform[] startSpawnZombis;
    [SerializeField]
    private Transform spawnZombi;
    private Transform[] spawnZombis;

    private float carWaitTime = 10f;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Cars[0], spawnCar1.position, spawnCar1.rotation);
        Instantiate(Cars[1], spawnCar2.position, spawnCar2.rotation);

        spawnsWander = spawnWander.GetComponentsInChildren<Transform>();
        for (int i = 0; i < spawnsWander.Length; i++)
        {
            Instantiate(peasant, spawnsWander[i].position, spawnsWander[i].rotation);
        }

        startSpawnZombis = startSpawnZombi.GetComponentsInChildren<Transform>();
        for (int i = 0; i < startSpawnZombis.Length; i++)
        {
            Instantiate(zombi, startSpawnZombis[i].position, startSpawnZombis[i].rotation);
        }

        spawnZombis = spawnZombi.GetComponentsInChildren<Transform>();
    }



    // Update is called once per frame
    void Update()
    {
        WanderHealth[] foundPeasants = Object.FindObjectsOfType<WanderHealth>();
        int countPeasants = foundPeasants.Length;
        
        for (int i = countPeasants; i < 50; i++)
        {
            int pos = Random.Range(0, spawnsWander.Length);
            Instantiate(peasant, spawnsWander[pos].position, spawnsWander[pos].rotation);
        }

        EnemyHealth[] foundZombis = Object.FindObjectsOfType<EnemyHealth>();
        int countZombis = foundZombis.Length;

        for (int i = countZombis; i < 100; i++)
        {
            int pos = Random.Range(0, spawnZombis.Length);
            Instantiate(zombi, spawnZombis[pos].position, spawnZombis[pos].rotation);
        }

        timer += Time.deltaTime;

        if(timer > carWaitTime)
        {
            Instantiate(Cars[0], spawnCar1.position, spawnCar1.rotation);
            Instantiate(Cars[Random.Range(1, 3)], spawnCar2.position, spawnCar2.rotation);
            timer -= carWaitTime;
        }
    }
}
