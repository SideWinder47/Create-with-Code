using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
	public List<GameObject> targets;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;
	public Button restartButton;
	public GameObject titleScreen;
	public bool isGameActive;
	
	private float spawnRate = 1.75f;
	private int score = 0;
    
	IEnumerator SpawnTarget()
	{
		while(isGameActive)
		{
			yield return new WaitForSeconds(spawnRate);
			int index = Random.Range(0, targets.Count);
			Instantiate(targets[index]);
		}
	}
	
	public void UpdateScore(int scoreToAdd) 
	{
		score += scoreToAdd;
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver()
	{
		restartButton.gameObject.SetActive(true);
		gameOverText.gameObject.SetActive(true);
		isGameActive = false;
	}
	
	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	public void StartGame(int difficulty)
	{
		isGameActive = true;
		spawnRate /= difficulty;
		scoreText.text = "Score: " + score;
		StartCoroutine(SpawnTarget());
		
		titleScreen.SetActive(false);
		scoreText.gameObject.SetActive(true);
	}
}








