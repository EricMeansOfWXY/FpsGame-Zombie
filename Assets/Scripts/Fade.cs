using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    private float fadeSpeed = 1f;
    private bool sceneStarting = true;
    [SerializeField]
    Image tex;
    public string sceneName = "";
    // Start is called before the first frame update
    void Update()
    {
        if (sceneStarting)
        {
            StartScene();
        }
    }

    private void FadeToClear()
    {
        tex.color = Color.Lerp(tex.color, Color.clear, fadeSpeed*Time.deltaTime);
    }
    private void FadeToBlack()
    {
        tex.color = Color.Lerp(tex.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    private void StartScene()
    {
        FadeToClear();
        if (tex.color.a <= 0.05f)
        {
            tex.color = Color.clear;
            tex.enabled = false;
            sceneStarting = false;
        }
    }
    public void EndScene()
    {
        tex.enabled = true;
        FadeToBlack();
        if (tex.color.a >= 0.95f)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
