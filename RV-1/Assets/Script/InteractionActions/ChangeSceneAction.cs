using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAction : InteractionAction {

    public string sceneToLoad;

    public override void PlayAction()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
