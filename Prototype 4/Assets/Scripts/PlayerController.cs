using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	private Rigidbody playerRb;
	private GameObject focalPoint;
	public GameObject powerupIndicator;
	
	public float speed = 5.0f;
	public bool hasPowerup = false;
	private float powerupStrength = 15.0f;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    playerRb = GetComponent<Rigidbody>();
	    focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
	    float forwardInput = Input.GetAxis("Vertical");
	    
	    powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
	    
	    playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
	    
	    if (transform.position.y < -10)
	    {
	    	Debug.Log("Game Over!");
	    }
    }
    
	// OnTriggerEnter is called when the Collider other enters the trigger.
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Powerup"))
		{
			powerupIndicator.SetActive(true);
			Destroy(other.gameObject);
			hasPowerup = true;
			StartCoroutine(PowerupCountdownRoutine());
		}
	}
	
	IEnumerator PowerupCountdownRoutine()
	{
		yield return new WaitForSeconds(7);
		hasPowerup = false;
		powerupIndicator.SetActive(false);
		Debug.Log("Powerup disabled");
	}
	
	// OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
	protected void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
		{
			Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
			Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;
			
			enemyRigidBody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
			//Debug.Log("Player collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
		}
	}
}
