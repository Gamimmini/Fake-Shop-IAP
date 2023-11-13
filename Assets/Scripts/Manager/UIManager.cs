using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [Header("UI Text")]
    public Text goldText;
    public Text item1Text;
    public Text item2Text;
    public Text item3Text;
    public Text item4Text;


    [Header("Panel")]
    public GameObject shopPanel;
    public GameObject expandedShopPanel;
    void Start()
    {
        
        goldText.text = "0";
        item1Text.text = "0";
        item2Text.text = "0";
        item3Text.text = "0";
        item4Text.text = "0";

        int loadedGold = ShopManager.instance.LoadGold();
        goldText.text = "Coin: " + loadedGold.ToString();

        int loadedItem1 = ShopManager.instance.LoadItem1();
        item1Text.text = "Item 1: " + loadedItem1.ToString();

        int loadedItem2 = ShopManager.instance.LoadItem2();
        item2Text.text = "Item 2: " + loadedItem2.ToString();

        int loadedItem3 = ShopManager.instance.LoadItem3();
        item3Text.text = "Item 3: " + loadedItem3.ToString();

        int loadedItem4 = ShopManager.instance.LoadItem4();
        item4Text.text = "Item 4: " + loadedItem4.ToString();

        
        shopPanel.SetActive(false);
        expandedShopPanel.SetActive(false);
    }
    public void AddValueToText(Text text, int value, string prefix = "")
    {
        int currentValue;
        if (int.TryParse(text.text.Replace(prefix, ""), out currentValue))
        {
            int newValue = currentValue + value;
            text.text = prefix + newValue.ToString();
        }
        else
        {
            
            Debug.LogError("Invalid text format: " + text.text);
        }
    }
    public void DeletePlayerData()
    {
        if (System.IO.File.Exists("playerData.json"))
        {
            System.IO.File.Delete("playerData.json");
            Debug.Log("PlayerData file deleted.");
        }
        else
        {
            Debug.Log("PlayerData file not found. No deletion needed.");
        }
    }
    public void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
