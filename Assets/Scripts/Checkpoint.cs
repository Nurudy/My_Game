using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite activeSprite;
    public Sprite inactiveSprite;
    public AudioClip activationSound;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        DeactivateCheckpoint();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            PLAYER_MOV player = other.GetComponent<PLAYER_MOV>();
            if (player != null)
            {
                player.SetCheckpoint(transform.position);
                ActivateCheckpoint();
            }
        }
    }


    public void ActivateCheckpoint()
    {
        spriteRenderer.sprite = activeSprite;
        PlayActivationSound();
    }

    public void DeactivateCheckpoint()
    {
        spriteRenderer.sprite = inactiveSprite;
    }

    private void PlayActivationSound()
    {
        if (audioSource != null && activationSound != null)
        {
            audioSource.PlayOneShot(activationSound);
        }
    }
}
