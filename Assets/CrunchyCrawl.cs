using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrunchyCrawl : MonoBehaviour
{
    private Rigidbody m_rigidbody;

    private Transform m_transform;

    private IEnumerable<Transform> m_jellos;

    public Vector3 m_destination;

    public float m_jelloDistance;

    public float m_speed;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        
        m_transform = GetComponent<Transform>();

        // Moves the GameObject using its transform
        m_rigidbody.isKinematic = false;

        m_jellos = FindObjectsOfType<CrunchyCrawl>()
            .Where(crawler => crawler != this && crawler.enabled)
            .Select(crawler => crawler.GetComponent<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        if(m_destination == null)
            return;

        var speed = m_speed * Time.fixedDeltaTime * (Mathf.Sin(Time.time * m_speed * 3.0f) + 0.75f);

        var position = transform.position;

        var direction = m_destination - position;

        foreach(var jello in m_jellos.Select(t => t.position))
        {
            if(Vector3.Distance(position, jello) < m_jelloDistance)
            {
                direction = direction + (position - jello) * 3.141517f;
            }
        }

        m_rigidbody.MovePosition(position + Vector3.ClampMagnitude(direction, speed));
        
        m_transform.forward = Vector3.ClampMagnitude(direction, 1.0f);
        
    }

}
