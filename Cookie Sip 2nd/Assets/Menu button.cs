using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButton: MonoBehaviour
{
    public void ClickButton()
{
    SceneManager.LoadScene("Menu scene");//if player clicks menu butto then it is going to lead them to the mentioned

}
}