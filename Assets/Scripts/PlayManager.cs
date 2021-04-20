using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayManager : MonoBehaviour
{
    public float start_time;
    public Text timer;
    public TeamManager top_team;
    public TeamManager bot_team;
    public GameObject top_base;
    public GameObject bot_base;
    public TeamManager neutral_team;
    public TeamManager hostile_team;

    // Start is called before the first frame update
    void Start()
    {
        start_time = Time.time;
        top_team = new TeamManager();
        bot_team = new TeamManager();
        neutral_team = new TeamManager();
        hostile_team = new TeamManager();
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = (Time.time -  start_time).ToString();
    }
}
