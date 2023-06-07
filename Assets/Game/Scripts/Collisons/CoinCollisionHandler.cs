using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Runner.Collisions
{
    public class CoinCollisionHandler : MonoBehaviour
    {
        [SerializeField] AudioClip pickupSound; // The audio clip to play when the coin is collected

        public static event Action onCoinCollect; // Event that is triggered when a coin is collected

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Singleton.Instance.AudioPlayer.PlayAudio(pickupSound); // Play the pickup sound using the AudioPlayer
                if (onCoinCollect != null)
                {
                    onCoinCollect(); // Trigger the onCoinCollect event
                }
                Destroy(gameObject); // Destroy the coin object
            }
        }
    }
}

