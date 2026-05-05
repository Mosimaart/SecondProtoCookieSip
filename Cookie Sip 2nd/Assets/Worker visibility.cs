using UnityEngine;

public class WorkerVisibility : MonoBehaviour
{
    public int thisWorkerNumber;
//if a player does not choose a specific number then it does not become visible in the next scene.
    void Start()
    {
        int chosen = PlayerPrefs.GetInt("ChosenWorker", 0);
        if (chosen != thisWorkerNumber)
        {
            gameObject.SetActive(false);
        }
    }
}