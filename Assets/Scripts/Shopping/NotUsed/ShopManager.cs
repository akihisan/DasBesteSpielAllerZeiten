using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShopManager : MonoBehaviour
{
    // Key zum Speichern des letzten Update-Datums
    private const string LastUpdateKey = "LastShopUpdate";

    void Start()
    {
        CheckForDailyShopUpdate();
    }

    // Funktion zum Prüfen und Aktualisieren des Angebots
    void CheckForDailyShopUpdate()
    {
        // Hol das aktuelle Datum
        DateTime currentDate = DateTime.Now;

        // Überprüfe, ob ein Datum für das letzte Update existiert
        if (PlayerPrefs.HasKey(LastUpdateKey))
        {
            // Hole das zuletzt gespeicherte Datum
            string lastUpdateString = PlayerPrefs.GetString(LastUpdateKey);
            DateTime lastUpdateDate = DateTime.Parse(lastUpdateString);

            // Überprüfe, ob ein neuer Tag begonnen hat
            if (currentDate.Minute > lastUpdateDate.Minute)             //WICHTIG: zu .Date ändern (.Minute nur zum Testen)!!!
            {
                UpdateShopInventory();
            }
        }
        else
        {
            // Falls es noch kein gespeichertes Datum gibt, initialisiere das Shop-Angebot
            UpdateShopInventory();
        }
    }

    // Funktion zum Aktualisieren des Shop-Angebots
    void UpdateShopInventory()
    {
        // Hier kannst du dein Shop-Angebot aktualisieren (zufällig oder mit einer Liste)
        Debug.Log("Shop-Angebot aktualisiert!");

        // Speichere das heutige Datum als letztes Update
        PlayerPrefs.SetString(LastUpdateKey, DateTime.Now.ToString());
        PlayerPrefs.Save();
    }
}

