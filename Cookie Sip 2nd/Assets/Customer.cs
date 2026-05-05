using UnityEngine;
using TMPro;

public class Customer : MonoBehaviour
{
    public float moveSpeed = 3f;

    // Queue position (0 = front)
    public int queueIndex;

    // Spacing between customers
    public float spacing = 2.5f;

    private bool isLeaving = false;
    private bool coinsAdded = false;

    private string[] drinks = { "Coffee", "Cappuccino", "Chai Latte" };
    private string[] pastries = { "Cookie", "Croissant", "Muffin" };

    private string chosenDrink;
    private string chosenPastry;

    private float waitTimer = 33f;

    public TextMeshProUGUI orderText;

    void Start()
    {
        chosenDrink = drinks[Random.Range(0, drinks.Length)];
        chosenPastry = pastries[Random.Range(0, pastries.Length)];

        string order = chosenDrink + " + " + chosenPastry;

        if (orderText != null)
        {
            orderText.text = order;
        }
    }

    void Update()
    {
        if (!isLeaving)
        {
            MoveInQueue();

            // ONLY front customer orders
            if (queueIndex == 0)
            {
                waitTimer -= Time.deltaTime;

                if (waitTimer <= 0f)
                {
                    if (!coinsAdded && CoinManager.instance != null)
                    {
                        CoinManager.instance.AddCoins(5);
                        coinsAdded = true;
                    }

                    Leave();
                }
            }
        }
        else
        {
            // Move out of screen
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(8f, 2.1f, 0f),
                moveSpeed * Time.deltaTime
            );
        }
    }

    void MoveInQueue()
    {
        // Dynamically calculate position
        float targetX = 0f - (queueIndex * spacing);
        Vector3 target = new Vector3(targetX, 2.1f, 0f);

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            moveSpeed * Time.deltaTime
        );
    }

    void Leave()
    {
        isLeaving = true;

        Customer[] customers = FindObjectsOfType<Customer>();

        foreach (Customer c in customers)
        {
            if (c.queueIndex > this.queueIndex)
            {
                c.queueIndex--;
            }
        }
    }
}