using UnityEngine;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour
{
    public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
    public AudioSource raceMusic;
    public AudioSource menuMusic;

    private float timer = 0.0f;
    private bool fadeClear = false;
    private bool fadeBlack = false;


    void Awake()
    {
        // Set the texture so that it is the the size of the screen and covers it.
        GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
        StartScene();
    }


    void Update()
    {
        if (fadeClear)
        {
            timer += fadeSpeed * Time.deltaTime;
            FadeToClear();
        }
        if (fadeBlack)
        {
            Debug.Log(timer.ToString() + " hello");
            timer += fadeSpeed * Time.deltaTime;
            FadeToBlack();
        }
    }


    void FadeToClear()
    {
        // Lerp the colour of the texture between itself and transparent.
        GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.clear, timer);
        if (GetComponent<GUITexture>().color.a <= 0.01f)
        {
            // ... set the colour to clear and disable the GUITexture.
            GetComponent<GUITexture>().color = Color.clear;
            GetComponent<GUITexture>().enabled = false;

            // The scene is no longer starting.
            fadeClear = false;
        }
        raceMusic.volume = 1 - GetComponent<GUITexture>().color.a;
        menuMusic.volume = 1 - GetComponent<GUITexture>().color.a;
    }


    void FadeToBlack()
    {
        // Lerp the colour of the texture between itself and black.
        GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.black, timer);
        if (GetComponent<GUITexture>().color.a >= 0.99f)
        {
            GetComponent<GUITexture>().color = Color.black;
            GetComponent<GUITexture>().enabled = true;
            // ... reload the level.
            fadeBlack = false;
        }
        raceMusic.volume = 1 - GetComponent<GUITexture>().color.a;
        menuMusic.volume = GetComponent<GUITexture>().color.a;
    }


    public void StartScene()
    {
        timer = 0.0f;
        // Fade the texture to clear.
        fadeClear = true;
        GetComponent<GUITexture>().color = Color.black;

        // If the texture is almost clear...

    }


    public void EndScene()
    {
        timer = 0.0f;
        // Make sure the texture is enabled.
        fadeBlack = true;
        GetComponent<GUITexture>().enabled = true;
     
    }
}