using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
	public GameObject dogPrefab;
    
	private bool _canDog = true;
	private float dogRate = 1.5f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
	    if (Input.GetKeyDown(KeyCode.Space) && _canDog)
        {
		    StartCoroutine(DogRoutine());
        }
    }
    
	private IEnumerator DogRoutine()
	{
		Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
		
		_canDog = false;
		
		yield return new WaitForSeconds(dogRate);
		
		_canDog = true;
	}
}
