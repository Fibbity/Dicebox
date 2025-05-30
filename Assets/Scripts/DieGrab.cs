using UnityEngine;

public class DieGrab : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask interactableMask;

    [Header("Game Specific Params")]
    [SerializeField] private float maxCastDistance;
    [SerializeField] private float maximumHeight;
    [SerializeField] private float tossCoyoteTime;

    public bool canGrabDie;

    private bool isMovingDie;

    private GameObject selectedDie;

    //-----------------------//
    void Start()
    //-----------------------//
    {
        Init();
    }//END Start

    //-----------------------//
    void Update()
    //-----------------------//
    {
        GrabDie();

    }//END Update

    //-----------------------//
    void FixedUpdate()
    //-----------------------//
    {
        MoveDie();

    }//END FixedUpdate

    //-----------------------//
    void Init()
    //-----------------------//
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
        
    }//END Init

    //-----------------------//
    void GrabDie()
    //-----------------------//
    {
        Vector3 _mousePosition = Input.mousePosition;
        _mousePosition.y = maximumHeight; //Lock die height when grabbed?
        _mousePosition = playerCamera.ScreenToWorldPoint(_mousePosition); //Unnecessary?


        if (canGrabDie == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray _ray = playerCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit _rayHit;

                if (Physics.Raycast(_ray, out _rayHit, maxCastDistance, interactableMask))
                {
                    // if (_rayHit.transform.GetComponentInChildren<Renderer>().material.color == Color.blue)
                    // {
                    //     _rayHit.transform.GetComponentInChildren<Renderer>().material.color = Color.red;
                    // }
                    // else
                    // {
                    //     _rayHit.transform.GetComponentInChildren<Renderer>().material.color = Color.blue;
                    // }

                    if (_rayHit.transform.GetComponent<Die>())
                    {
                        selectedDie = _rayHit.transform.gameObject;
                        isMovingDie = true;
                    }
                }
            }
            else
            {
                selectedDie = null;
                isMovingDie = false;
            }
        } 

    }//END GrabDie

    //-----------------------//
    void MoveDie()
    //-----------------------//
    {
        if (isMovingDie == true)
        {
            selectedDie.transform.position = Input.mousePosition;
        }

    }//END MoveDie

}//END CLASS DieGrab
