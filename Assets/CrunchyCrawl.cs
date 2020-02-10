using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrunchyCrawl : MonoBehaviour
{
    private Rigidbody m_rigidbody;

    public Vector3 m_destination;
    public float m_speed;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        // Moves the GameObject using its transform
        m_rigidbody.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_destination == null)
            return;

        var speed = m_speed * Time.fixedDeltaTime * (Mathf.Sin(Time.time * m_speed * 3.0f) + 0.5f);

        var direction = m_destination - transform.position;

        m_rigidbody.MovePosition(transform.position + Vector3.ClampMagnitude(direction, speed));
    }

}
