using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour
{
    //Taken from tanks tutorial and edited by Edwin Aguirre
    //This script allows the camera to follow the player
    
    [SerializeField]
    private float m_DampTime = 0.2f;
    [SerializeField]               
    private float m_ScreenEdgeBuffer = 4f;   
    [SerializeField]        
    private float m_MinSize = 6.5f;    
    // [SerializeField]              
    // private Transform[] m_Targets;
    [SerializeField]
    private List<Transform> m_Targets;

    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    private bool isP1NotActive;//These are to save performance and also lets you play alone without having extra things on screen
    private bool isP2NotActive;//These are to save performance and also lets you play alone without having extra things on screen

    [SerializeField]
    private GameObject p1Farm;
    [SerializeField]
    private GameObject p2Farm;


    private Camera m_Camera;                        
    private float m_ZoomSpeed;                      
    private Vector3 m_MoveVelocity;                 
    private Vector3 m_DesiredPosition;              


    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }

    private void Start() 
    {
        isP1NotActive = true;
        isP2NotActive = true;
    }

    private void Update() 
    {
        Player1Camera();
        Player2Camera();
        MultiplayerCamera();
    }


    private void FixedUpdate()
    {
        Move();
        Zoom();
    }

    private void Player1Camera()//Focuses the camera on player 1
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            if(isP1NotActive)
            {
                m_Targets.Add(player1.transform);
                isP1NotActive = false;
                m_ScreenEdgeBuffer = 3f;
                m_MinSize = 4f;
                p2Farm.SetActive(false);
            }
        }
    }

    private void Player2Camera()//Focuses the camera on player 2
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(isP2NotActive)
            {
                m_Targets.Add(player2.transform);
                isP2NotActive = false;
                m_ScreenEdgeBuffer = 3f;
                m_MinSize = 4f;
                p1Farm.SetActive(false);
            }
        }
    }

    private void MultiplayerCamera()//Focuses the camera on both players
    {
        if(!isP1NotActive && !isP2NotActive)
        {
            m_ScreenEdgeBuffer = 5f;
            m_MinSize = 6f;
            p1Farm.SetActive(true);
            p2Farm.SetActive(true);
        }
    }

    private void Move()
    {
        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }


    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        for (int i = 0; i < m_Targets.ToArray().Length; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            averagePos += m_Targets[i].position;
            numTargets++;
        }

        if (numTargets > 0)
            averagePos /= numTargets;

        averagePos.y = transform.position.y;

        m_DesiredPosition = averagePos;
    }


    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
    }


    private float FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);

        float size = 0f;

        for (int i = 0; i < m_Targets.ToArray().Length; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            Vector3 targetLocalPos = transform.InverseTransformPoint(m_Targets[i].position);

            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.y));

            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.x) / m_Camera.aspect);
        }
        
        size += m_ScreenEdgeBuffer;

        size = Mathf.Max(size, m_MinSize);

        return size;
    }


    public void SetStartPositionAndSize()
    {
        FindAveragePosition();

        transform.position = m_DesiredPosition;

        m_Camera.orthographicSize = FindRequiredSize();
    }
}