using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public Player Knight;
    public Player Dwarf;
    public Player Wizzard;

    public List<ItemData> allItemDatas; // 전체 아이템 데이터 리스트

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
        
    }
    
    private void Start()
    {
        // 전체 아이템 리스트에 Resources 폴더를 이용해 전부 추가하기
        ItemData[] items = Resources.LoadAll<ItemData>("ScriptableObjects");
        allItemDatas.AddRange(items);
        
        /*
        Knight.LoadData(LoadAllPlayerData()[0], allItemDatas);
        Dwarf.LoadData(LoadAllPlayerData()[1], allItemDatas);
        Wizzard.LoadData(LoadAllPlayerData()[2], allItemDatas);
        */

        Load();
    }

    /*
    public List<PlayerData> LoadAllPlayerData()
    {
        return new List<PlayerData>
        {
            new PlayerData { playerName = "Knight", level = 10, gold = 5000, strength = 45, defense = 20, health = 200, critical = 10, equippedItemNames = new List<string>{"Sword"} },
            new PlayerData { playerName = "Dwarf", level = 15, gold = 10000, strength = 50, defense = 25, health = 120, critical = 20, equippedItemNames = new List<string>{"Axe"} },
            new PlayerData { playerName = "Wizzard", level = 8, gold = 500, strength = 30, defense = 20, health = 80, critical = 60, equippedItemNames = new List<string>{"Staff"} }
        };
    }
    */
    
    
    // StreamingAssets를 통해 PlayerData.csv 파일 읽어오기
    public List<PlayerData> LoadPlayerDataFromStreamingAssets()
    {
        List<PlayerData> playerDatas = new List<PlayerData>();
        string path = Path.Combine(Application.streamingAssetsPath, "PlayerData.csv");

        if (!File.Exists(path))
        {
            Debug.Log("파일이 존재하지 않습니다.");
            return playerDatas;
        }
        
        string[] row = File.ReadAllLines(path); // 엑셀의 행을 의미
        if (row.Length <= 1) return playerDatas; // row.Length가 1이면 전체 1행만 존재, 헤더만 존재므로 데이터가 없는 경우

        for (int i = 1; i < row.Length; i++)
        {
            string[] column = row[i].Split(',');  // 엑셀의 열을 의미
            if (column.Length < 8)  
            {
                Debug.Log("Data에 공란이 있습니다.");
                return playerDatas;
            } 
            
            playerDatas.Add(new  PlayerData
            {
                playerName = column[0],
                level = int.Parse(column[1]),
                gold = int.Parse(column[2]),
                strength = int.Parse(column[3]),
                defense = int.Parse(column[4]),
                health = int.Parse(column[5]),
                critical = int.Parse(column[6]),
                // 장비가 여러 개일 경우 세미클론(;)으로 구분
                equippedItemNames = new List<string>(column[7].Split(';'))
            });
        }
        return playerDatas;
        
    }

    // StreamingAssets를 통해 PlayerData를 PlayerData.csv 파일에 저장하기
    public void SavePlayerDataToStreamingAssets(List<PlayerData> playerDatas)
    {
        // 여러 경로 문자열 합치기, 경로 : Application.streamingAssetsPath/PlayerData.csv
        string path = Path.Combine(Application.streamingAssetsPath, "PlayerData.csv");
        
        // 헤더
        StringBuilder header = new StringBuilder(); // 문자열을 더할때 더 효율적으로 사용 가능, 임시 문자열 객체 생성을 줄여 가비지 컬렉터 호출 감소
        header.AppendLine("playerName,level,gold,strength,defense,health,critical,equippedItemNames");

        foreach (PlayerData datas in playerDatas)
        {
            // equippedItemNames는 ;으로 각각의 아이템들을 구분
            string equippedItems = string.Join(";", datas.equippedItemNames ?? new List<string>()); // ??연산자, datas.equippedItemNames가 null이 아니면 그대로 사용, null이면 new List<string> 
            header.AppendLine($"{datas.playerName},{datas.level},{datas.gold},{datas.strength},{datas.defense},{datas.health},{datas.critical},{equippedItems}");
            
            File.WriteAllText(path, header.ToString(), Encoding.UTF8); // UTF-8으로 인코딩
            
        }
    }
    
    // StreamingAssets를 통해 가져온 PlayerData List를 각각 오브젝트에 적용
    private void Load()
    {
        Knight.LoadData(LoadPlayerDataFromStreamingAssets()[0], allItemDatas);
        Dwarf.LoadData(LoadPlayerDataFromStreamingAssets()[1], allItemDatas);
        Wizzard.LoadData(LoadPlayerDataFromStreamingAssets()[2], allItemDatas);
    }
    
    
    // Player에서 player 인스턴스의 현재 정보를 PlayerData로 변환하고, 그 Data를 csv 파일에 저장
    public void Save()
    {
        List<PlayerData> playerDatas = new List<PlayerData>
        {
            Knight.SaveData(),
            Dwarf.SaveData(),
            Wizzard.SaveData()
        };
        SavePlayerDataToStreamingAssets(playerDatas);
    }
    
}
