using UnityEngine;
using DG.Tweening;
using Runner.Collisions;
using System;
using Runner.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Pool;

namespace Runner.UI
{
    public class CoinCollectAnimation : MonoBehaviour 
    {
        [SerializeField] UICoin uiCoin;  // The UI coin prefab to be instantiated
        [SerializeField] Transform destination;  // The destination transform for the coin animation
        [SerializeField] private Vector3 startingPosition;  // The starting position for the coins
        [SerializeField] AudioClip coinSound;  // Sound clip for the coin collect event
        
        private IObjectPool<UICoin> coinPool;  // Object pool for managing the UI coins
        private int _coinCount = 5;  // Number of coins to animate
        
        private void OnEnable() 
        {
            CoinCollisionHandler.onCoinCollect += StartAnimation;  // Subscribe to the coin collect event
        }

        private void OnDisable() 
        {
            CoinCollisionHandler.onCoinCollect -= StartAnimation;  // Unsubscribe from the coin collect event
        }

        private void Awake() 
        {
            coinPool = new ObjectPool<UICoin>(CreateCoin, OnGet, OnRelease, maxSize: 15);  // Initialize the object pool
        }

        private UICoin CreateCoin()
        {
            return Instantiate(uiCoin, startingPosition, Quaternion.identity, transform);  // Instantiate a new UI coin from the prefab
        }

        private void OnGet(UICoin coin)
        {
            coin.gameObject.SetActive(true);  // Activate the UI coin
            coin.transform.localPosition = startingPosition;  // Set the starting position of the coin
            coin.transform.DOMove(destination.position, 1f).SetEase(Ease.Linear).OnComplete(() => 
            {
                Singleton.Instance.AudioPlayer.PlayAudio(coinSound, volume: 0.5f);  // Play the coin sound
                coinPool.Release(coin);  // Release the UI coin back to the object pool
            });
        }

        private void OnRelease(UICoin coin)
        {
            coin.gameObject.SetActive(false);  // Deactivate the UI coin
        }

        private void StartAnimation()
        {
            StartCoroutine(CoinAnimation());  // Start the coin animation coroutine
        }

        private IEnumerator CoinAnimation()
        {
            while (true)
            {
                for (int i = 0; i < _coinCount; i++)
                {
                    var coin = coinPool.Get();  // Get a UI coin from the object pool
                    yield return new WaitForSeconds(0.1f);  // Wait for a small delay between spawning coins
                }
                yield break;
            }
        }
    }
}
