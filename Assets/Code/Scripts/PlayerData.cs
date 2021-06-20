using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public int level;
    public List<int> star;

    public PlayerData(int level, List<int> star)
    {
        this.level = level;
        this.star = star;
    }
}
