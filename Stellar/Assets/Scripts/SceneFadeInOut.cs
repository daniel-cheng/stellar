using UnityEngine;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour
{
    public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
    public AudioSource raceMusic;
    public AudioSource menuMusic;

    private bool sceneStarting = true;      // Whether or not the scene is still fading in.
    private float timer = 0.0f;
    private bool fadeClear = false;
    private bool fadeBlack = false;


    void Awake()
    {
        // Set the texture so that it is the the size of the screen and covers it.
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
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
        guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, timer);
        if (guiTexture.color.a <= 0.01f)
        {
            // ... set the colour to clear and disable the GUITexture.
            guiTexture.color = Color.clear;
            guiTexture.enabled = false;

            // The scene is no longer starting.
            sceneStarting = false;
            fadeClear = false;
        }
        raceMusic.volume = 1 - guiTexture.color.a;
        menuMusic.volume = 1 - guiTexture.color.a;
    }


    void FadeToBlack()
    {
        // Lerp the colour of the texture between itself and black.
        guiTexture.color = Color.Lerp(guiTexture.color, Color.black, timer);
        if (guiTexture.color.a >= 0.99f)
        {
            guiTexture.color = Color.black;
            guiTexture.enabled = true;
            // ... reload the level.
            fadeBlack = false;
        }
        raceMusic.volume = 1 - guiTexture.color.a;
        menuMusic.volume = guiTexture.color.a;
    }


    public void StartScene()
    {
        timer = 0.0f;
        // Fade the texture to clear.
        fadeClear = true;
        guiTexture.color = Color.black;

        // If the texture is almost clear...

    }


    public void EndScene()
    {
        timer = 0.0f;
        // Make sure the texture is enabled.
        fadeBlack = true;
        guiTexture.enabled = true;
     
    }
}