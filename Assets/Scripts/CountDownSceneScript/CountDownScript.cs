using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDownScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countDownDisplay;

    [SerializeField] float countDownTime;

    [SerializeField] GameObject[] gameObjects;

    [SerializeField] AudioSource countDownAudio;

    void Start()
    {
        StartCoroutine(CountDownToStart());
    }

    IEnumerator CountDownToStart()
    {
        while (countDownTime > 0)
        {

            countDownDisplay.text = countDownTime.ToString();

            yield return new WaitForSeconds(1.0f);

            countDownTime--;
        }

        gameObjects[0].SetActive(false);
        gameObjects[1].SetActive(false);
        gameObjects[2].SetActive(true);

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("PlayerModeScene");
    }

}
