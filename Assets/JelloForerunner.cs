using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JelloForerunner : MonoBehaviour
{
    private CrunchyCrawl m_crunchyCrawl;

    public Transform m_target;
    public Transform m_hunter;

    // Start is called before the first frame update
    void Start()
    {
        m_crunchyCrawl = GetComponent<CrunchyCrawl>();

        m_crunchyCrawl.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_target == null || m_hunter == null)
            return;
        
        var posHunter = m_hunter.position;
        var posTarget = m_target.position;

        m_crunchyCrawl.m_destination = (posTarget - posHunter) + posTarget;
    }
}
