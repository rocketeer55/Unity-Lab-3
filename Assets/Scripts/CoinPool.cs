using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour {
    
    public int coinPoolSize = 3;
    public GameObject coinPrefab;
    public float spawnRate = 8f;
    public float coinMin = -1f;
    public float coinMax = 4f;

    private GameObject[] coins;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned = 6f;
    private float spawnXPosition = 10f;
    private int currentCoin = 0;

    void Start() {
        coins = new GameObject[coinPoolSize];
        for (int i = 0; i < coinPoolSize; i++) {
            coins[i] = (GameObject) Instantiate(coinPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update() {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(coinMin, coinMax);

            coins[currentCoin].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            coins[currentCoin].SetActive(true);
            currentCoin++;
            if (currentCoin >= coinPoolSize) {
                currentCoin = 0;
            }
        }
    }
}
