using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animfinsiher : MonoBehaviour
{
    public Animator animator;
    public AnimationClip animationClip;
    public string previousSceneName;

    void Start()
    {
        Scene previousScene = SceneManager.GetSceneByName(previousSceneName);
        if (previousScene.IsValid() && previousScene.isLoaded)
        {
            animator.Play(animationClip.name, -1, 1f);
        }
    }
}
