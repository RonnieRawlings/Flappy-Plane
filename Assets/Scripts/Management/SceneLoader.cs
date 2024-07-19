// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary> method <c>LoadScene</c> uses the SceneManager class to load a scene using given string. </summary>
    public void LoadScene(string givenScene)
    {
        SceneManager.LoadScene(givenScene);
    }
}
