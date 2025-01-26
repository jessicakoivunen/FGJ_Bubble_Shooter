using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    //Panels
    public GameObject ControlsPanel;
    public GameObject PausePanel;
    public GameObject PauseButton;
    public GameObject WinPanel;

    //Sounds
    public AudioSource audioSource;
    public AudioClip pop;
    public AudioSource mainCamera;

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (ControlsPanel.activeInHierarchy || PausePanel.activeInHierarchy || WinPanel.activeInHierarchy)
            {
                mainCamera.Pause();
            }
            else mainCamera.UnPause();
        }

    }

    public void StartGame()
    {
        audioSource.PlayOneShot(pop);
        //load game scene
        SceneManager.LoadScene(1);
    }

    public void OpenControls()
    {
        audioSource.PlayOneShot(pop);

        if (ControlsPanel.activeInHierarchy)
        {
            ControlsPanel.SetActive(false);
        }
        else ControlsPanel.SetActive(true);
    }

    public void OpenMenu()
    {
        audioSource.PlayOneShot(pop);
        //load main menu scene
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        audioSource.PlayOneShot(pop);

        if (!PausePanel.activeInHierarchy)
        {
            PausePanel.SetActive(true);
            PauseButton.SetActive(false);
            Time.timeScale = 0.0f;
        }
        else
        {
            PausePanel.SetActive(false);
            PauseButton.SetActive(true);
            Time.timeScale = 1.0f;
        }
    }

    public void QuitGame()
    {
        audioSource.PlayOneShot(pop);
        Debug.Log("CLOSE");
        Application.Quit();
    }
}
