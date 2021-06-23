using System;
using UnityEngine;

public static class Energy
{
    public static PlayerData data = SaveSystem.LoadPlayer();
    private static bool started = true;

    public static void Start()
    {
        if (started)
        {
            
        }
    }

    public static bool UseEnergy()
    {
        if (data.energy < 5)
        {
            return false;
        }
        data.quitGame = DateTime.Now;
        data.energy -= 5;
        return true;
    }

    public static void Fill()
    {
        data.energy = 50;
    }
}