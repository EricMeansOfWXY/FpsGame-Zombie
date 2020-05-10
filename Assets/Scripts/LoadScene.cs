using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName = "";
    public int point;
    float f;
    public GameObject text;
    


    void Start()
    {
        point = 0;
        f = 0;
        text=GameObject.Find("Passed");
        text.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (point >= 200)
        {
            text.gameObject.SetActive(true);
            this.GetComponent<Fade>().EndScene();
            StartCoroutine(LoadAsyneScene());
            point = 0;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();

        if (player != null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    public void _pointLoad()
    {
        point += 10;
    }
    IEnumerator LoadAsyneScene()
    {
        //异步加载场景
        AsyncOperation asyneLoad = SceneManager.LoadSceneAsync(sceneName);
        asyneLoad.allowSceneActivation = false;
        while (!asyneLoad.isDone)
        {
            //设置加载下一场景的条件：一秒后加载
            if (f < 1)
            {
                f += Time.deltaTime;
                Debug.Log(f);
            }
            else
            {
                asyneLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
