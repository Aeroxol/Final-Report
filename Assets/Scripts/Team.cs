using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public enum TeamNumber
    {
        top_team,
        bot_team,
        hostile_team,
        newtral_team,
    }
    public TeamNumber team_num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTeam(TeamNumber _team)
    {
        team_num = _team;
    }
}
