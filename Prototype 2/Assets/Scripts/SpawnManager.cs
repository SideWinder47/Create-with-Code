using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	
	public GameObject[] animals;
	private int spawnRangeX = 20;
	private int spawnPosZ = 20;
	private float startDelay = 2;
	private float spawnInterval = 1.5f;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
	{
		
	}
    
	void SpawnRandomAnimal()
	{
		// Randomly spawns different animals at different positions
		int animalIndex = Random.Range(0, animals.Length);
		Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
			
		Instantiate(animals[animalIndex], spawnPos, animals[animalIndex].transform.rotation);
	}
}
