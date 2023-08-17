using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float restartDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] AudioSource victorySound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !victorySound.isPlaying)
        {
            finishEffect.Play();
            victorySound.Play();
            Invoke("Restart", restartDelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
