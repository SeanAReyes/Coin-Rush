using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [SerializeField] private AudioClip boingClip;
    [SerializeField] float bounceForce = 15f;

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb == null) return;

        if (rb.velocity.y > 0.1f) return;

        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);

        PlayerGravityMovement player = other.GetComponent<PlayerGravityMovement>();
        if (player != null)
          player.ResetJumps();
          AudioManager.instance.PlaySoundFXClip(boingClip, transform, 0.8f);
    }    

}
