using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float crashDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] ParticleSystem snowTrail;
    [SerializeField] AudioSource crashSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && !crashSound.isPlaying)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play(); 
            crashSound.Play();
            Invoke("Restart", crashDelay);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            snowTrail.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            snowTrail.Play();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
