using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UILoadScene : MonoBehaviour
{
    public Canvas _quitMenu;
    public Button _play;
    public Button _quit;
    void Start()
    {
        _quitMenu.enabled = false;
    }
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == gameObject
           && Input.GetButtonDown("Submit"))
        {
            PlayAgine();
        }
    }
    public void PlayAgine()
    {
       
        SceneManager.LoadScene("VillageZombie");
    }
    public void Menu()
    {
        SceneManager.LoadScene("PlayGame");
    }
    public void Quit()
    {
        _quitMenu.enabled = true;
        _play.enabled = false;
        _quit.enabled = false;

    }
    public void No()
    {
        _quitMenu.enabled = false;
        _play.enabled = true;
        _quit.enabled = true;
    }
    public void Yes()
    {
        Application.Quit();
    }
}
