using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MenuNavigation : MonoBehaviour
{

   // public Selectable defaultSelection;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;//鼠标状态无限制
        Cursor.visible = true;//显示鼠标光标
       // EventSystem.current.SetSelectedGameObject(null);
    }

    /*void LateUpdate()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            if (Input.GetButtonDown("Submit")
               || Input.GetAxisRaw("Horizontal") != 0
                || Input.GetAxisRaw("Vertical") != 0)
           {
                EventSystem.current.SetSelectedGameObject(defaultSelection.gameObject);
            }
        }
    }*/
}
