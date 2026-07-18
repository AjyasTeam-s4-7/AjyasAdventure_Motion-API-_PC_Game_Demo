using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class SaveManager
{
    static string PathFile => Path.Combine(Application.persistentDataPath, "scores.json");
    public static List<UserScore> GetTopScores(int count = 10)
    {
        SaveData data = Load();
        return data.users
            .OrderByDescending(x => x.score)
            .Take(count)
            .ToList();
    }
    public static SaveData Load()
    {
        if (!File.Exists(PathFile))
            return new SaveData();

        string json = File.ReadAllText(PathFile);
        return JsonUtility.FromJson<SaveData>(json) ?? new SaveData();
    }

    public static void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(PathFile, json);
    }

    public static int GetScore(string id)
    {
        var data = Load();
        var user = data.users.FirstOrDefault(u => u.id == id);
        return user != null ? user.score : 0;
    }

    public static void SetScore(string id, int score)
    {
        var data = Load();
        var user = data.users.FirstOrDefault(u => u.id == id);

        if (user == null)
        {
            data.users.Add(new UserScore { id = id, score = score });
        }
        else
        {
            user.score = score;
        }

        Save(data);
    }
}
