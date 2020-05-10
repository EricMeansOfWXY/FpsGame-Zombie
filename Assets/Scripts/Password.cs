using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Password : MonoBehaviour
{
    public string passWord="3651";
    public string _currentPassWord ="";
    public Vector3 from;
    public Vector3 to;
    private Transform door;
    public float fadeSpeed=0.5f;
    public GameObject _passdoor;
    private bool _pass;

    void Start()
    {
        _passdoor = GameObject.Find("Passdoor");
        door = GameObject.Find("Gen_Door_01_snaps002").transform;
        door.localPosition = from;
        _passdoor.gameObject.SetActive(false);
        _pass = false;
    }
    void Update()
    {
        
        if (_pass)
        {
            door.localPosition = Vector3.Lerp(door.localPosition, to, fadeSpeed * Time.deltaTime);

        }
    }
    public void confirm()
    {
       
        if (_currentPassWord == passWord)
        {
            _pass = true;
            

        }
        else
        {
            _currentPassWord = "";
        }
       
    }
    private void OnTriggerStay(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<AutomaticGunScriptLPFP>().enabled = false;
            _passdoor.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;//鼠标状态无限制
            Cursor.visible = true;//显示鼠标光标
        }
    }
    private void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<AutomaticGunScriptLPFP>().enabled = true;
            _passdoor.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            _currentPassWord = "";
        }
    }
    public void Button0()
    {
        _currentPassWord += "0";
    }
    public void Button1()
    {
        _currentPassWord += "1";
    }
    public void Button2()
    {
        _currentPassWord += "2";
    }
    public void Button3()
    {
        _currentPassWord += "3";
    }
    public void Button4()
    {
        _currentPassWord += "4";
    }
    public void Button5()
    {
        _currentPassWord += "5";
    }
    public void Button6()
    {
        _currentPassWord += "6";
    }
    public void Button7()
    {
        _currentPassWord += "7";
    }
    public void Button8()
    {
        _currentPassWord += "8";
    }
    public void Button9()
    {
        _currentPassWord += "9";
    }

}
