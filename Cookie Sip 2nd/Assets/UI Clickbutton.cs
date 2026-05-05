using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIClickbutton : MonoBehaviour
{
    public void MoveToSCene(int sceneID)
    {
        SceneManager.LoadScene("Worker Choice Scene");
    }
}
