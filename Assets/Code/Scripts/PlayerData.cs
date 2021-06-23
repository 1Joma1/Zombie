using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public int level;
    public List<int> star;
    public int energy;
    public DateTime quitGame;

    public PlayerData(int level, List<int> star, int energy, DateTime quitGame)
    {
        this.level = level;
        this.star = star;
        this.energy = energy;
        this.quitGame = quitGame;
    }
}
