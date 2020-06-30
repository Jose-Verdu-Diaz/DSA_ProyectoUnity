using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;

    public GameObject canvas;

    public Text pauseText;

    public Player player;

    public Timer timer;

    private void Start()
    {
        isPaused = false;

        var tmpColor = pauseText.color;
        tmpColor.a = 0f;
        pauseText.color = tmpColor;
    }

    public void pauseClick()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;

            var tmpColor = canvas.GetComponent<Image>().color;
            tmpColor.a = 0.3f;
            canvas.GetComponent<Image>().color = tmpColor;

            tmpColor = pauseText.color;
            tmpColor.a = 1f;
            pauseText.color = tmpColor;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;

            var tmpColor = canvas.GetComponent<Image>().color;
            tmpColor.a = 0f;
            canvas.GetComponent<Image>().color = tmpColor;

            tmpColor = pauseText.color;
            tmpColor.a = 0f;
            pauseText.color = tmpColor;
        }
    }

    public void finalizar()
    {
        Time.timeScale = 0;

        var tmpColor = canvas.GetComponent<Image>().color;
        tmpColor.a = 0.3f;
        canvas.GetComponent<Image>().color = tmpColor;

        int points = player.getPoints();
        int numObjects = player.getNumObjects();
        float time = timer.getTime();

        int totalPoints = (int)(points * (1 + numObjects / time));
        pauseText.text = points.ToString() + " pts. + (1 + " + numObjects.ToString() + " / " + time.ToString("n1") + " ) = " + totalPoints.ToString() + " pts.";

        tmpColor = pauseText.color;
        tmpColor.a = 1f;
        pauseText.color = tmpColor;
    }
}