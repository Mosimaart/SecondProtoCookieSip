using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playbutton : MonoBehaviour
{
   public void ClickButton()
{//if player clicks quit button, the game will lead them to the main game scene
    SceneManager.LoadScene("Worker Choice Scene");

}
}