using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadExcel : MonoBehaviour
{
    public string CSVFilename = "";
    public Item blankItem;
    [SerializeField]
    public List<Item> itemDatabase = new List<Item>();

    public static LoadExcel instance;

    private void Awake()
    {
        instance = this;
    }

    public void LoadItemData()
    {
        //Clear database
        itemDatabase.Clear();

        //READ CSV files
        List<Dictionary<string, object>> data = CSVReader.Read(CSVFilename);
        for(var i = 0; i < data.Count; i++)
        {
            int textNumber = int.Parse(data[i]["TextNumber"].ToString(), System.Globalization.NumberStyles.Integer);
            string character = data[i]["Character"].ToString();
            string line = data[i]["Line"].ToString();

            AddItem(textNumber, character, line);
        }
    }

    public Item GetItem(int textNumber)
    {
        if(textNumber < 0)return null;
        return itemDatabase[textNumber];
    }

    void AddItem(int textNumber, string character, string line)
    {
        Item tempItem = new Item(blankItem);

        tempItem.textNumber = textNumber;
        tempItem.character = character;
        tempItem.line = line;

        itemDatabase.Add(tempItem);
    }
}
