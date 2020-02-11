using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JelloHunter : MonoBehaviour
{
    private CrunchyCrawl m_crunchyCrawl;

    public Transform m_target;

    // Start is called before the first frame update
    void Start()
    {
        m_crunchyCrawl = GetComponent<CrunchyCrawl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_target == null)
            return;
        
        m_crunchyCrawl.m_destination = m_target.position;
    }
}
