using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToOrder : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Orderlist orderlist;

    void Awake()
    {
        if (cam == null) cam = Camera.main;
    }

    void Update()
    {
        if (Mouse.current == null || cam == null || orderlist == null)
            return;

        if (!Mouse.current.leftButton.wasPressedThisFrame)
            return;

        Vector2 mouseScreen = Mouse.current.position.ReadValue();
        Vector3 world = cam.ScreenToWorldPoint(new Vector3(mouseScreen.x, mouseScreen.y, -cam.transform.position.z));

        RaycastHit2D hit = Physics2D.Raycast(world, Vector2.zero);
        if (hit.collider == null) return;

        
        var clickable = hit.collider.GetComponent<ClickableItem>();
        if (clickable == null) return;

        clickable.Click(orderlist);
    }

}