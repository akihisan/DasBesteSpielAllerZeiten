using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoTextCode : MonoBehaviour
{
    public TextMeshProUGUI InfoText;
    private string takoyaki, ramen, baguette, pizza, waffeln;
    private string donut, biskuitrolle, eiscreme, muffin, schokolade;
    private string bubbletea, kaffee, spazi, tee, wasser;

    void Start(){
        takoyaki = "“Gebratene Krake”, eine kleine, warme befüllte Teigkugel aus Japan.";
        ramen = "Eine japanische Nudelsuppe. Heiß und lecker!";
        donut = "Kleiner, runder, amerikanischer Kuchen.";
        bubbletea = "Taiwanisches Getränk auf Basis von gesüßtem Schwarzen- oder Grünem Tee.";
        baguette = "Ein langes, französisches Brot. Probier es mal mit Käse!";
        pizza = "Italienisches, würzig belegtes Fladenbrot aus Hefeteig. Vorsicht heiß!";
        waffeln = "“Die Waffel ist ein uraltes niederfränkisches Fest- und Fastengebäck” - Gebrüder Grimm";
        biskuitrolle = "Gerollter, österreichischer Kuchen.";
        eiscreme = "Achtung, Gehirnfrost!";
        muffin = "Die Herkunft dieser leckeren Minikuchen ist unbekannt. Trotzdem lecker!";
        schokolade = "Hmmm.. Warte, ist sie schon alle?";
        kaffee = "Koffeinhaltiges Getränk, welches aus Bohnen besteht.";
        spazi = "Mischung aus Orangenlimonade und einem anderen koffeinhaltigem Getränk.";
        tee = "Aufgussgetränk, welches aus Blättern, Knospen, Blüten, Rinden oder auch Wurzeln bestehen kann.";
        wasser = "Sehr erfrischend!";
        InfoText.text = "";
    }

    public void ChangeInfo(string newText){
        switch(newText){
            case "takoyaki": InfoText.text = takoyaki; break;
            case "ramen": InfoText.text = ramen; break;
            case "donut": InfoText.text = donut; break;
            case "bubbletea": InfoText.text = bubbletea; break;
            case "baguette": InfoText.text = baguette; break;
            case "pizza": InfoText.text = pizza; break;
            case "waffeln": InfoText.text = waffeln; break;
            case "biskuitrolle": InfoText.text = biskuitrolle; break;
            case "eiscreme": InfoText.text = eiscreme; break;
            case "muffin": InfoText.text = muffin; break;
            case "schokolade": InfoText.text = schokolade; break;
            case "kaffee": InfoText.text = kaffee; break;
            case "spazi": InfoText.text = spazi; break;
            case "tee": InfoText.text = tee; break;
            case "wasser": InfoText.text = wasser; break;
        }
    }

    public void EmptyText(){
        InfoText.text = "";
    }

    void OnEnable(){
        InfoText.text = "";
    }
}
