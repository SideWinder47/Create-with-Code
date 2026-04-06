using UnityEngine;

public class Target : MonoBehaviour
{
	private Rigidbody targetRb;
	private GameManager gameManager;
	
	private float minSpeed = 9;
	private float maxSpeed = 14;
	private float torqueRange = 10;
	private float xRange = 4;
	private float ySpawnPos = -1;
	
	public int pointValue;
	public ParticleSystem explosionParticle;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    targetRb = GetComponent<Rigidbody>();
	    gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
	    
	    targetRb.AddForce(RandomSpeed(), ForceMode.Impulse);
	    targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());
	    
	    transform.position = RandomSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	// OnMouseDown is called when the user has pressed the mouse button while over the GUIElement or Collider.
	protected void OnMouseDown()
	{
		if (gameManager.isGameActive)
		{
			Destroy(gameObject);
			gameManager.UpdateScore(pointValue);
			Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);	
		}
		
	}
	
	// OnTriggerEnter is called when the Collider other enters the trigger.
	protected void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);
		
		if (!gameObject.CompareTag("Bad"))
		{
			gameManager.GameOver();
		}
	}
    
	Vector3 RandomSpeed()
	{
		return Random.Range(minSpeed, maxSpeed) * Vector3.up;
	}
	
	float RandomTorque() 
	{
		return Random.Range(-torqueRange, torqueRange);
	}
	
	Vector3 RandomSpawnPosition()
	{
		return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);;
	}
	

}
