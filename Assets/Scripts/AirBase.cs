using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBase : MonoBehaviour
{
    private Collider2D m_collider;
    private Vector3 m_min, m_max;
    public GameObject revive_point;
    public Team team;
    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<Collider2D>();
        m_min = m_collider.bounds.min;
        m_max = m_collider.bounds.max;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Hero _hero = collision.gameObject.GetComponent<Hero>();
        if (_hero && _hero.is_flying == false)
        {
            StrikerUnit _striker_unit = _hero.striker_unit;
            if (_striker_unit)
            {
                _hero.is_flying = true;
            }
            else
            {
                _hero.transform.position = new Vector3(Mathf.Clamp(_hero.transform.position.x, m_min.x-0.4f, m_max.x+0.4f), Mathf.Clamp(_hero.transform.position.y, m_min.y-0.4f, m_max.y+0.4f), 0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovingObject _ob = collision.gameObject.GetComponent<MovingObject>();
        Team _team = collision.gameObject.GetComponent<Team>();
        if(_ob && _team && _ob.is_flying == true && _team.team_num == team.team_num)
        {
            _ob.is_flying = false;
        }
    }
}
