using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectableContainer : MonoBehaviour
{
    private string _path;
    private CollectableListInfo _list;
    private static CollectableContainer _instance;
    
    void Awake()
    {
        //Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        _path = Path.Combine(Application.dataPath, "Scripts/Collectables/collectables.json");
        try
        {
            if (!File.Exists(_path))
            {
                throw new Exception("Pasame la ruta bien hombre.");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
        loadCollectables();
        writeCollectables();
    }

    private void writeCollectables()
    {
        GameObject[] uiCollectables = GameObject.FindGameObjectsWithTag("CollectableUI");
        Debug.Log("Cracckkkkk" + uiCollectables.Length);
        for(int i = 0; i < uiCollectables.Length; i++)
        {
            uiCollectables[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _list.collectables[i].title;
            uiCollectables[i].transform.GetChild(1).GetComponent<Text>().text = _list.collectables[i].description;
            if (_list.collectables[i].pickup)
            {
                uiCollectables[i].GetComponent<Button>().enabled = true;
                uiCollectables[i].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
            }else
            {
                uiCollectables[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "?";
                uiCollectables[i].GetComponent<Button>().enabled = false;
            }
                
        }
    }

    public void loadCollectables()
    {
        string dataFromJson = File.ReadAllText(_path);
        _list = JsonUtility.FromJson<CollectableListInfo>(dataFromJson);
    }
    public void WriteRecord()
    {
        //checkRecord(_name, _record);
        string dataToJson = JsonUtility.ToJson(_list, true);
        File.WriteAllText(_path, dataToJson);
    }

    public CollectableListInfo getList()
    {
        return _list;
    }

    public void UnlockCollectable(int id)
    {
        _list.collectables[id].pickup = true;
        writeCollectables();
        WriteRecord();
    }

    public void DisabledCollectableList()
    {
        Debug.Log("hagoaoao");
        this.transform.GetChild(0).GetComponent<Canvas>().enabled = false;
        //this.gameObject.GetComponent<Canvas>().enabled = false;
    }

#if UNITY_EDITOR
    public void setFalseAll()
    {
        CollectableListInfo falselist = _list;
        for (int i = 0; i < _list.collectables.Count; i++)
        {
            falselist.collectables[i].title = _list.collectables[i].title;
            falselist.collectables[i].description = _list.collectables[i].description;
            falselist.collectables[i].pickup = false;
        }
        string dataToJson = JsonUtility.ToJson(falselist, true);
        File.WriteAllText("Scripts/Collectables/collectables_false.json", dataToJson);
    }
#endif
}
