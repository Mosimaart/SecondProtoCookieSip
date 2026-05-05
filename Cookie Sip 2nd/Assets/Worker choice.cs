using UnityEngine;
using UnityEngine.SceneManagement;

public class WorkerChoice : MonoBehaviour
{//Player chooses their desired worker.
    public void ChooseWorker1()
    {
        PlayerPrefs.SetInt("ChosenWorker", 1);
        SceneManager.LoadScene("SampleScene");
    }

    public void ChooseWorker2()
    {
        PlayerPrefs.SetInt("ChosenWorker", 2);
        SceneManager.LoadScene("SampleScene");
    }

    public void ChooseWorker3()
    {
        PlayerPrefs.SetInt("ChosenWorker", 3);
        SceneManager.LoadScene("SampleScene");
    }
}
