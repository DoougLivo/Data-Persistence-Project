using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public string name;
    public int score;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData();
        data.name = name;
        data.score = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        
        if (File.Exists(path)) // ������ ������ �����ϴ��� Ȯ��
        {
            string json = File.ReadAllText(path); // ���Ͽ��� json ���ڿ� �б�
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            name = data.name;
            score = data.score;
        } else
        {
            name = "";
            score = 0;
            Debug.Log("����� ������ ã�� �� �����ϴ�. �⺻���� ����մϴ�.");
        }
    }
}
