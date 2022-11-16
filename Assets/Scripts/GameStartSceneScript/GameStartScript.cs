using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartScript : MonoBehaviour
{
    private Animator tapToPlayAnimation;
    [SerializeField] AudioSource tapAudio;

    private void Start()
    {
        tapToPlayAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                StartCoroutine(Waitsc());
            }
        }
    }

    IEnumerator Waitsc()
    {
        tapAudio.Play();
        tapToPlayAnimation.SetTrigger("Outside_Animation_Trigger");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameModeSelectionScene");
    }

}
