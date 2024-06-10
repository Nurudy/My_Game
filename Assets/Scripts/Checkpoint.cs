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

    private void OnTriggerEnter2D(Collider2D other) //si el jugador pasa por en frente el check se activa 
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


    public void ActivateCheckpoint() //y hace ruidito
    {
        spriteRenderer.sprite = activeSprite;
        PlayActivationSound();
    }

    public void DeactivateCheckpoint() //aqui muestra que pasa de desactivado(dibujo) a activado
    {
        spriteRenderer.sprite = inactiveSprite;
    }

    private void PlayActivationSound() //el sonidito al activarse o pasar.
    {
        if (audioSource != null && activationSound != null)
        {
            audioSource.PlayOneShot(activationSound);
        }
    }
}
