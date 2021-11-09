using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDeacrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip enemyReachBaseSFX;

    private void Update()
    {
        healthText.text = $"Base HP: {health}";
    }
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(enemyReachBaseSFX);
        health -= healthDeacrease;
    }
}
