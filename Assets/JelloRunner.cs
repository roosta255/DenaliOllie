using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JelloRunner : MonoBehaviour
{
    private Transform m_transform;

    private CrunchyCrawl m_crunchyCrawl;

    public Transform[] m_targets;

    // Start is called before the first frame update
    void Start()
    {
        m_crunchyCrawl = GetComponent<CrunchyCrawl>();

        m_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_targets == null)
            return;
        
        var positionCurrent = m_transform.position;

        var weight = new Vector3();

        foreach(var target in m_targets)
        {
            if(target == null)
                continue;

            var positionTarget = target.position;

            weight = -positionTarget * Vector3.Distance(positionTarget, positionCurrent);
        }

        m_crunchyCrawl.m_destination = weight;
    }
}
