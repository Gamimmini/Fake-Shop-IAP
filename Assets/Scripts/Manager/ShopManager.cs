using Unity.VisualScripting;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public UIManager uiManager;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        LoadGold();
    }
    public void BuyCoin(UnityEngine.Purchasing.Product product)
    {
        int goldAmount = 0;
        int item1 = 0;
        int item2 = 0;
        int item3 = 0;
        int item4 = 0;

        
        foreach (var payout in product.definition.payouts)
        {
            if (payout.subtype == "Gold")
            {
                goldAmount += (int)payout.quantity;
            }
            else if (payout.subtype == "Item 1")
            {
                item1 += (int)payout.quantity;
            }
            else if (payout.subtype == "Item 2")
            {
                item2 += (int)payout.quantity;
            }
            else if (payout.subtype == "Item 3")
            {
                item3 += (int)payout.quantity;
            }
            else if (payout.subtype == "Item 4")
            {
                item4 += (int)payout.quantity;
            }
        }

        
        if (goldAmount > 0)
        {
            CustomEvent.Trigger(gameObject, "addGold", goldAmount);
            Debug.Log("Added " + goldAmount + " gold to the player.");

            
            uiManager.AddValueToText(uiManager.goldText, goldAmount, "Coin: ");
            SaveGold(goldAmount);
        }
        if (item1 > 0)
        {
            CustomEvent.Trigger(gameObject, "addItem1", item1);
            Debug.Log("Added " + item1 + " items of type 1 to the player.");

            
            uiManager.AddValueToText(uiManager.item1Text, item1, "Item 1: ");
            SaveItem1(item1);
        }
        if (item2 > 0)
        {
            CustomEvent.Trigger(gameObject, "addItem2", item2);
            Debug.Log("Added " + item2 + " items of type 2 to the player.");

            
            uiManager.AddValueToText(uiManager.item2Text, item2, "Item 2: ");
            SaveItem2(item2);
        }
        if (item3 > 0)
        {
            CustomEvent.Trigger(gameObject, "addItem3", item3);
            Debug.Log("Added " + item3 + " items of type 3 to the player.");

            
            uiManager.AddValueToText(uiManager.item3Text, item3, "Item 3: ");
            SaveItem3(item3);
        }
        if (item4 > 0)
        {
            CustomEvent.Trigger(gameObject, "addItem4", item4);
            Debug.Log("Added " + item4 + " items of type 4 to the player.");

            
            uiManager.AddValueToText(uiManager.item4Text, item4, "Item 4: ");
            SaveItem4(item4);
        }
    }
    public void SaveGold(int goldAmount)
    {
        PlayerData playerData;

        if (System.IO.File.Exists("playerData.json"))
        {
            string json = System.IO.File.ReadAllText("playerData.json");
            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            playerData = new PlayerData();
        }

        playerData.gold += goldAmount;

        string updatedJson = JsonUtility.ToJson(playerData);
        System.IO.File.WriteAllText("playerData.json", updatedJson);
    }

    public int LoadGold()
    {
        if (System.IO.File.Exists("playerData.json"))
        {
            string json = System.IO.File.ReadAllText("playerData.json");
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Loaded gold: " + playerData.gold);
            return playerData.gold;
        }
        return 0; 
    }
    public void SaveItem1(int itemAmount)
    {
        PlayerData playerData;

        if (System.IO.File.Exists("playerData.json"))
        {
            string json = System.IO.File.ReadAllText("playerData.json");
            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            playerData = new PlayerData();
        }

        playerData.item1 += itemAmount;
        string updatedJson = JsonUtility.ToJson(playerData);
        System.IO.File.WriteAllText("playerData.json", updatedJson);
    }

    public int LoadItem1()
    {
        if (System.IO.File.Exists("playerData.json"))
        {
            string json = System.IO.File.ReadAllText("playerData.json");
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Loaded item1: " + playerData.item1);
            return playerData.item1;
        }
        return 0; 
    }
    public void SaveItem2(int itemAmount)
    {
        PlayerData playerData;

        if (System.IO.File.Exists("playerData.json"))
        {
            string json = System.IO.File.ReadAllText("playerData.json");
            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            playerData = new PlayerData();
        }

        playerData.item2 += itemAmount;
        string updatedJson = JsonUtility.ToJson(playerData);
        System.IO.File.WriteAllText("playerData.json", updatedJson);
    }

    public int LoadItem2()
    {
        if (System.IO.File.Exists("playerData.json"))
        {
            string json = System.IO.File.ReadAllText("playerData.json");
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Loaded item2: " + playerData.item2);
            return playerData.item2;
        }
        return 0; 
    }

    
    public void SaveItem3(int itemAmount)
    {
        PlayerData playerData;

        if (System.IO.File.Exists("playerData.json"))
        {
            string json = System.IO.File.ReadAllText("playerData.json");
            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            playerData = new PlayerData();
        }

        playerData.item3 += itemAmount;
        string updatedJson = JsonUtility.ToJson(playerData);
        System.IO.File.WriteAllText("playerData.json", updatedJson);
    }

    public int LoadItem3()
    {
        if (System.IO.File.Exists("playerData.json"))
        {
            string json = System.IO.File.ReadAllText("playerData.json");
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Loaded item3: " + playerData.item3);
            return playerData.item3;
        }
        return 0; 
    }

    public void SaveItem4(int itemAmount)
    {
        PlayerData playerData;

        if (System.IO.File.Exists("playerData.json"))
        {
            string json = System.IO.File.ReadAllText("playerData.json");
            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            playerData = new PlayerData();
        }

        playerData.item4 += itemAmount;
        string updatedJson = JsonUtility.ToJson(playerData);
        System.IO.File.WriteAllText("playerData.json", updatedJson);
    }

    public int LoadItem4()
    {
        if (System.IO.File.Exists("playerData.json"))
        {
            string json = System.IO.File.ReadAllText("playerData.json");
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Loaded item4: " + playerData.item4);
            return playerData.item4;
        }
        return 0; 
    }

}
