using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseBar;
    [SerializeField] private GameObject _settingBar;
    [SerializeField] private _playerMousecontroller _mouseController;

    private bool _isOpened;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !_isOpened)
        {
            Invoke("OpenPauseClick",0.2f);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(Input.GetKey(KeyCode.Escape) && _isOpened) 
        {
            Invoke("ResumeBtn", 0.2f); 
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void ToMenuBtn() 
    {
        SceneManager.LoadScene("Menu");
    }

    private void OpenPauseClick() 
    {
        _pauseBar.SetActive(true);
        _isOpened = true;
        _mouseController.enabled = false;
    }

    public void ResumeBtn() 
    {
        _pauseBar.SetActive(false);    
        _isOpened = false;
        Cursor.visible = false;
        _mouseController.enabled = true;
    }

    public void OpenSettingsBtn() 
    {
        _pauseBar.SetActive(false);
        _settingBar.SetActive(true);
    }

    public void CloseSettingsClick() 
    {
        _pauseBar.SetActive(true);
        _settingBar.SetActive(false);
    }

    public void ExitBtn() 
    {
        Application.Quit();
    }

}
