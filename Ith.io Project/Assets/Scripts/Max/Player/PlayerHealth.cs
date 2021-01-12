using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Range(0,3)]
    [Header("amount of health the player has")]
    [SerializeField] private int health = 0;

    [Header("images of the health")]
    [SerializeField] private GameObject[] healthImages = null;

    [Header("panel that activates when the player dies")]
    [SerializeField] private GameObject deathPanel = null;

    [Header("how long the invincibilty frames are active")]
    [SerializeField] private float invincibilityFramesTimer;

    [Header("Renderer of the player")]
    private SpriteRenderer playerRenderer;

    [Header("colors the player displays when hit by the enemy and has invincibility frames")]
    [SerializeField] private Color renderColorOff;
    [SerializeField] private Color renderColorDefault;

    [Header("Checks if the invincibility frames are active")]
    private bool invincibilityFramesActive = false;

    void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>();

        health = healthImages.Length;
    }

    void Update()
    {
        CheckHealthStatus();

        if (invincibilityFramesActive)
        {
            StartCoroutine(TurnOffInvincibilityFrames(invincibilityFramesTimer));
        }
    }

    //when the player collides with an enemy his health will drop and an image in the array will be turned off
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (health > 0 && !invincibilityFramesActive)
            {
                health--;
                healthImages[health].SetActive(false);

                StartCoroutine(InvincibilityFrames());
            }
        }
    }

    //checks if the health is below 0
    private void CheckHealthStatus()
    {
        if(health <= 0)
        {
            Time.timeScale = 0.0f;

            deathPanel.SetActive(true);
        }
    }

    private IEnumerator InvincibilityFrames()
    {
        invincibilityFramesActive = true;

        while (invincibilityFramesActive)
        {
            playerRenderer.color = renderColorOff;

            yield return new WaitForSeconds(.10f);

            playerRenderer.color = renderColorDefault;

            yield return new WaitForSeconds(.10f);

            playerRenderer.color = renderColorOff;
        }
    }

    private IEnumerator TurnOffInvincibilityFrames(float delay)
    {
        yield return new WaitForSeconds(delay);

        invincibilityFramesActive = false;

        playerRenderer.color = renderColorDefault;
    }


}
