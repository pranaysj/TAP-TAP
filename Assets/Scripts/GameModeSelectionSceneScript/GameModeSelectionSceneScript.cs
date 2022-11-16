using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeSelectionSceneScript : MonoBehaviour
{
    public void PlayerMode()
    {
        StartCoroutine(WaitForPlayerMode());
    }

    IEnumerator WaitForPlayerMode()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("CountDownScene");
    }

    public void ComputerMode()
    {
        StartCoroutine(WaitForComputerMode());
    }

    IEnumerator WaitForComputerMode()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("CountDownForComScene");
    }
}
