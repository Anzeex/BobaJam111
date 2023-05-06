using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public Animator animator;
    public AnimationClip transitionAnimation,ani;
    public AudioClip[] Clips;
    public AudioSource source;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(animator.gameObject);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("AnzeeMovementScene");
    }
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartTransition()
    {
        StartCoroutine(TransitionCoroutine(("AnzeeMovementScene")));
    }

    private IEnumerator TransitionCoroutine(string nextSceneName)
    {
        animator.Play(transitionAnimation.name);

        // Wait for the animation to finish
        yield return new WaitForSeconds(transitionAnimation.length);

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);

        animator.Play(ani.name);
        yield return new WaitForSeconds(ani.length);
        Destroy(gameObject);
    }
    public void PLAYSOUND(int sound )
    {
        source.clip = Clips[sound];
        source.Play();
    }
}