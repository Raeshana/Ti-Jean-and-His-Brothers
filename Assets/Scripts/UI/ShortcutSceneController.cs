using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutSceneController : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            sceneController.RestartLevel();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            sceneController.GoToHowToPlay();
        }   

        if (Input.GetKeyDown(KeyCode.P))
        {
            sceneController.GoToPauseMenu();
        }
        
        if (Input.GetButtonDown("Cancel"))
        {
            sceneController.QuitGame();
        }       
    }
}
