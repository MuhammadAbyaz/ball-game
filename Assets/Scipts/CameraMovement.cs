using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform m_target;
    [SerializeField] Vector3 m_boardCenter;
    Vector3 m_offset;
    void Start()
    {
       m_offset = transform.position - m_boardCenter; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(m_target.position.x + m_offset.x,transform.position.y,m_target.position.z + m_offset.z);
        transform.position = Vector3.Lerp(transform.position,target,Time.deltaTime);
    }
}
