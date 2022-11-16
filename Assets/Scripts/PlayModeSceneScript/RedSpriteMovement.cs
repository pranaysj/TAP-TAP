using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedSpriteMovement : MonoBehaviour
{
    [SerializeField] GameObject[] finalText;
    [SerializeField] GameObject[] playText;
    [SerializeField] GameObject[] playerVsPlayer;
    [SerializeField] AudioSource endAudioClip;
    
    private void Start()
    {
        InterstitialAdManager.instance.RequestInterstitial();
    }

    public void UpButton()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);
        playText[0].SetActive(false);
        playText[1].SetActive(false);
        playerVsPlayer[0].SetActive(true);
        playerVsPlayer[1].SetActive(true);
    }

    public void DownButton()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.25f);
        playText[0].SetActive(false);
        playText[1].SetActive(false);
        playerVsPlayer[0].SetActive(true);
        playerVsPlayer[1].SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Upper_Collider")
        {
            playerVsPlayer[1].GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
            endAudioClip.Play();
            finalText[0].SetActive(true);
            finalText[1].SetActive(true);
            StartCoroutine(InterstitialAd());
        }
        else if (collision.gameObject.name == "Lower_Collider")
        {
            endAudioClip.Play();
            finalText[2].SetActive(true);
            finalText[3].SetActive(true);
            StartCoroutine(InterstitialAd());
        }
    }

    IEnumerator InterstitialAd()
    {
        yield return new WaitForSeconds(1.0f);
        InterstitialAdManager.instance.ShowInterstitial();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("GameStartScene");
    }
}
