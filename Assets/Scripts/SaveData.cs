using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{

public static SaveData Instance;

public int score;
public string username = "DaBreaka";
public string leading_username;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }


        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveDetails
    {
        public string username;
        public string leading_username;
        public int score;


    }

    public void SaveScore() {
        SaveDetails details = new SaveDetails();
        details.score = score;
        details.username = username;
        details.leading_username = leading_username;

        string json = JsonUtility.ToJson(details);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore() {
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path)) {
        string json = File.ReadAllText(path);
        SaveDetails data = JsonUtility.FromJson<SaveDetails>(json);

        score = data.score;
        leading_username = data.leading_username;
    }

}

}
