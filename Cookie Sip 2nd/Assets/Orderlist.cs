using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Orderlist : MonoBehaviour
{
    [ Header("Display postions ( world coordinates)")]
    [SerializeField] private Vector3 pastryworldPos;
    [SerializeField] private Vector3 drinkworldPos;

    [Header("Auto reset")]
    [SerializeField] private bool autoRest = true;
    [SerializeField] private float autoResetDelay  = 10f;
    private Coroutine _autoResetCorountine;

    [Header("Display positions ( world coordinates)")]
    [SerializeField] private Transform pastryTillSlot;
    [SerializeField] private Transform drinkTillSlot;

    [Header("Pastries")]
    [SerializeField] private Objectshake donut;
    [SerializeField] private Objectshake muffin;
    [SerializeField] private Objectshake croissant;

    [Header("Drinks")]
    [SerializeField] private Objectshake coffee;
    [SerializeField] private Objectshake chaiLatte;
    [SerializeField] private Objectshake cappucino;

    private class HomeState
    {
        public Transform parent;
        public Vector3 localPos;
    }

    private readonly Dictionary<Objectshake, HomeState> _homes = new Dictionary<Objectshake, HomeState>();

    private void EnsureHome(Objectshake item)
    {
        if (item == null || _homes.ContainsKey(item)) return;

        _homes[item] = new HomeState
        {
            parent = item.transform.parent,
            localPos = item.transform.localPosition
        };
    }

    private void MoveToWorldPosition(Objectshake item, Vector3 worldPosition)
    {
        if (item == null) return;
        EnsureHome(item);
        item.transform.position = worldPosition;
        item.RefreshOriginalLocal();
    }

    private void RestoreHomes()
    {
        foreach (var kvp in _homes)
        {
            var item = kvp.Key;
            var home = kvp.Value;
            if (item == null) continue;
            
            item.transform.SetParent(home.parent, worldPositionStays: false);
            item.transform.localPosition = home.localPos;
            item.RefreshOriginalLocal();
        }
    }

    private IEnumerator AutoResetAfterDelay()
    {
        yield return new WaitForSeconds(autoResetDelay);
        ResetAll();
    }

    public void ShowOrder(string drink, string pastries)
    {
        var d = GetDrink(drink);
        var p = GetPastries(pastries);

        MoveToWorldPosition(p, pastryworldPos);
        MoveToWorldPosition(d, drinkworldPos);

        d?.StartShake();
        p?.StartShake();
        
        if (autoRest)
        {
            if (_autoResetCorountine != null) StopCoroutine(_autoResetCorountine);
            _autoResetCorountine = StartCoroutine(AutoResetAfterDelay());
        }
    }

    private Objectshake GetDrink(string drink)
    {
        if (string.IsNullOrEmpty(drink)) return null;
        drink = drink.Trim().ToLowerInvariant();

        if (drink == "coffee") return coffee;
        if (drink == "chai latte") return chaiLatte;
        if (drink == "cappucino") return cappucino;

        return null;
    }

    private Objectshake GetPastries(string pastries)
    {
        if (string.IsNullOrEmpty(pastries)) return null;
        pastries = pastries.Trim().ToLowerInvariant();

        if (pastries == "croissant") return croissant;
        if (pastries == "muffin") return muffin;
        if (pastries == "donut") return donut;

        return null;
    }

    public void ResetAll()
    {
        if (_autoResetCorountine != null)
        {
            StopCoroutine(_autoResetCorountine);
            _autoResetCorountine = null;
        }


        RestoreHomes();


        coffee?.ResetObject();
        chaiLatte?.ResetObject();
        cappucino?.ResetObject();
        croissant?.ResetObject();
        muffin?.ResetObject();
        donut?.ResetObject();
    }    
}
