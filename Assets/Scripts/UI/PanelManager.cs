using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PanelManager : MonoBehaviour
{
    #region Dependencies 
    public KeyCode keyCode;
    public GameObject panel;
    #endregion

    public bool IsOpen;

    #region Events 
    public UnityEvent OnOpen;
    public UnityEvent OnClose;
    #endregion

    // Update is called once per frame
    void Update()
    {
        IsOpen = panel.activeSelf;
        if (Input.GetKeyDown(keyCode)) 
        {
            if (IsOpen)
            {
                CloseCurrentPanel();
                
            }
            else 
            {
                OpenCurrentPanel();
                
            }
        }
    }

    public void Toggle() 
    {
        panel.SetActive(!panel.activeSelf);
    }

    public void GoToPanel(GameObject _panel, bool closeCurrent) 
    {
        _panel.SetActive(_panel.activeSelf);
        if (closeCurrent) 
        { 
            CloseCurrentPanel();
        }
    }

    private void OpenCurrentPanel() 
    {
        panel.SetActive(true);
        Debug.Log(panel.activeSelf);
        OnOpen.Invoke();
    }
    private void CloseCurrentPanel() 
    {
        OnClose.Invoke();
        panel.SetActive(false);
    }
}
