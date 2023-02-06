using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Simulation : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI entityText;
    public GameObject DayNightController;
    public GameObject moon;
    public GameObject sun;
    string text;
    float timer = 0.0f;
    int days = 0;
    float minutes;
    float seconds;
    bool IsNight = false;
    bool doOnce = true;
    
    // Start is called before the first frame update
    void Start()
    {
        DayNightController = GameObject.Find("DayNightController");
        timeText = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();
        entityText = GameObject.Find("EntityCount").GetComponent<TextMeshProUGUI>();
        moon = GameObject.Find("Moon");
        sun = GameObject.Find("Sun");
    }

    // Update is called once per frame
    void Update()
    {
        Human[] humans = FindObjectsOfType<Human>();
        Zombie[] zoms = FindObjectsOfType<Zombie>();
        Deer[] deers = FindObjectsOfType<Deer>();
        timer += Time.deltaTime;
        if (timer > 10 && doOnce) {
            IsNight = true;
            doOnce = false;
        }
        if (timer > 20) {
            timer = 0;
            days++;
            doOnce = true;
            IsNight = false;
        }

        if (IsNight) {
            moon.SetActive(true);
            sun.SetActive(false);
        }
        else {
            moon.SetActive(false);
            sun.SetActive(true);
        }
        float hours = Mathf.FloorToInt(timer / 3600);
        float minutes = Mathf.FloorToInt(timer % 3600);
        text = string.Format("{0:00}:{1:00}", hours, minutes);
        timeText.SetText("Day " + days + ": " + text);
        entityText.SetText("Zombies: " + zoms.Length + "\n" + "Humans: " + humans.Length + "\n" + "Deer: " + deers.Length);
    }
}