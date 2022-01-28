using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //vigtig da programmet skal integerer med UI elementer
using System; //vigtig da scriptet skal tilgå computerens lokale tid

public class FreeGemTimer : MonoBehaviour
{
    public static int freeGems = 2900; //spillerens freeGems
    public float ResetTime; //hvor lang tid der går inden spilleren for flere gems
    public static float timeValue = 0; //hvor lang tid der er gået
    public float timeSinceLastPlay; //en float brugt til beregningen af hvor lang tid siden spilleren sidst spillede spillet
    public Text timeText; //Timerens textbox
    public Text freeGemText; //textboxen for den totale mængde freeGems
    private string lastPlayedString; //hvornår spilleren sidst spillede

    // Start is called before the first frame update
    void Start()
    {

        lastPlayedString = PlayerPrefs.GetString("lastQuit", ""); //bruger unity's indbyggede database til at finde hvornår spilleren sidst lukkede spillet
        if (lastPlayedString != "") //hvis spilleren har spillet før
        {
            DateTime dateQuit = DateTime.Parse(lastPlayedString); //Laver lastplayedstring om til en DateTime
            DateTime dateNow = DateTime.Now; //finder hvad tiden er på computeren lige nu
            if (dateNow > dateQuit) //sikre at der ikke er sket en fejl i timeren
            {
                TimeSpan timespan = dateNow - dateQuit; //finder hvor meget tid der er gået imellem nu og sidste gang brugeren spillede
                timeSinceLastPlay = Convert.ToSingle(timespan.TotalSeconds); //converetere det til sekunder og en float
            }
            //freeGems = PlayerPrefs.GetInt("freeGems"); //bruger unity's indbyggede database til at finde brugerens energi da de sidst loggede af
            timeValue = PlayerPrefs.GetFloat("timeValue"); //bruger unity's indbyggede database til at finde hvad timeren var på da de sidst loggede af
            timeValue -= timeSinceLastPlay; //trækker tiden siden brugeren sidst spillede fra hvad timeren er på 
        }
        else //hvis brugeren ikke har spillet spillet før sættes energien og timeren til deres default værdier
        {
            timeValue = ResetTime; 
        }
        //freeGems = 0; //til at resette timeren til testing
    }
    void OnApplicationQuit() //den metode kaldes når brugeren lukker spillet
    {
        DateTime dateQuit = DateTime.Now; //Finder hvad tiden er lige nu
        PlayerPrefs.SetString("lastQuit", dateQuit.ToString()); //gemmer "dateQuit" som en string i unity's indbyggede database
        PlayerPrefs.SetFloat("timeValue", timeValue); //gemmer "timeValue" i unity's indbyggede database
        PlayerPrefs.SetInt("freeGems", freeGems); //gemmer "freeGems" i unity's indbyggede database
    }

    void Update()
    {
        if (freeGems < 3000) //hvis spilleren har mindre energi end maxet
        {
            if (timeValue > 0) //hvis timeValue er større end 0 vil timeren tæller ned
            {
                timeValue -= Time.deltaTime;
            }
            else //hvis timeren er under 0 vil spilleren få en gen mere og resettiden vil blive lagt til timeValue
            {
                freeGems++;
                timeValue += ResetTime;
            }
            DisplayTime(timeValue); //kalder metoden DisplayTime og sender timeValue
        }
        else //hvis brugeren har max energi vil timeValue blive default tiden (5 min) og text feltet for timeren vil sige "Full"
        {
            timeValue = ResetTime;
            timeText.text = "(Full)";
        }
        freeGemText.text = freeGems.ToString(); //viser hvor meget energi spilleren har i baren
    }

    void DisplayTime(float timeToDisplay) //denne metode er hvad der opdater tiden vist på timeren
    {
        if (timeToDisplay < 0) //hvis at den tid der skal vises er negativ gøres den til nul da der ellers ville være en enkelt frame hvor timeren var negativ
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); //beregner hvor mange mintutter der er i "timeToDisplay"
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); //beregner sekunderne timeren skal vise
        string display = string.Format("{0:0}:{1:00}", minutes, seconds); //sætter formatet af timeren
        timeText.text = "(" + display + ")"; //opdatere timer textboxen
    }
}
