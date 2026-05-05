using UnityEngine;
using TMPro;
using System.Collections;

public class Customer : MonoBehaviour
{
    [SerializeField] private Orderlist orderlist;
    public float moveSpeed = 3f;
    public int queueIndex;
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
        GenerateOrder();
        StartCoroutine(OrderLoop());
    }
    
    void ShowOrder()
    {
        orderlist.ShowOrder(chosenDrink, chosenPastry);
    }

    void Update()
    {
        if (!isLeaving)
        {
            MoveInQueue();

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
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(12f, 1.3f, 0f),
                moveSpeed * Time.deltaTime
            );
        }
    }

    void MoveInQueue()
    {
        float targetX = 0f - (queueIndex * spacing);
        Vector3 target = new Vector3(targetX, 1.3f, 0f);

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

    void GenerateOrder()
    {
        chosenDrink = drinks[Random.Range(0, drinks.Length)];
        chosenPastry = pastries[Random.Range(0, pastries.Length)];

        string order = chosenDrink + " + " + chosenPastry;

        if (orderText != null)
        {
            orderText.text = order;
        }
    }

    IEnumerator OrderLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(34f);
            GenerateOrder();
        }
    }
}