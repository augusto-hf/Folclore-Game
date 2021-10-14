using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;

        }
        instance = this;
    }
    #endregion

    public GameObject InventoryMenuUI;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public static bool InventoryActive = false;
    public static bool GameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryActive)
            {
                Resume();
            }
            else
            {
                InventoryEnable();
            }
        }
    }
    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }
            items.Add(item);

            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    void InventoryEnable()
    {
        InventoryMenuUI.SetActive(true);
        Time.timeScale = 0f;
        InventoryActive = true;
        GameIsPaused = true;
    }

    void Resume()
    {
        InventoryMenuUI.SetActive(false);
        Time.timeScale = 1f;
        InventoryActive = false;
    }

}
