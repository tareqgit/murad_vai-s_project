using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class class2 : MonoBehaviour {


    private List<Vector3> pos_S;
    private Vector3 _endPos;
    private bool _hasStartPos;
    private LineRenderer _lineRenderer;
    private bool _mouseDown;
    private Vector3 _startPos;
    private Camera _camera;

    // Use this for initialization
    void Start () {
        _lineRenderer = gameObject.GetComponent<LineRenderer>();
        _camera = Camera.main;

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
         // StartCoroutine(m_Coroutine());
        }




        if (Input.GetMouseButtonDown(0))
        {
            _mouseDown = true;

         



            Vector3 mousePos = Input.mousePosition;
            mousePos.y = Screen.height - mousePos.y;
          
        }




        if (Input.GetMouseButtonDown(0) && _mouseDown)
        {
            _startPos = Input.mousePosition;
            _hasStartPos = true;


        }

        else if (_hasStartPos && Input.GetMouseButtonUp(0) && _mouseDown )
        {


            _endPos = Input.mousePosition;


            if ((start_name == end_name) && (start_name != "") && (end_name != ""))
            {
                Debug.Log("Match");
            }else if((start_name != end_name) && (start_name != "") && (end_name != ""))
            {
                Debug.Log("Not Matched");
            }





            _hasStartPos = false;
            _lineRenderer.enabled = false;
          

        }


        if (_hasStartPos )
        {
            _lineRenderer.SetWidth(.5f, .5f);

            _lineRenderer.enabled = true;


            // _lineRenderer.SetPosition(0,new Vector3( _startPos.x,_startPos.y,-0.5f));
            //_lineRenderer.SetPosition(1, new Vector3(Input.mousePosition.x,Input.mousePosition.y, -0.5f)) ;
          
                _lineRenderer.SetPosition(0, new Vector3(GetPosInWorld(_startPos).x, GetPosInWorld(_startPos).y, -0.5f));
                _lineRenderer.SetPosition(1, new Vector3(GetPosInWorld(Input.mousePosition).x, GetPosInWorld(Input.mousePosition).y, -0.5f));
          
            if (Vector3.Distance(_startPos, Input.mousePosition) > MinSplitDistance)
            {


                RaycastHit hitInfo;
                Ray ray = _camera.ScreenPointToRay(_startPos);
                if (Physics.Raycast(ray, out hitInfo))
                {
                    tags = hitInfo.collider.gameObject.tag;
                        start_name = hitInfo.collider.gameObject.name;
                        Debug.Log(start_name);
                    
                }

                RaycastHit hitInfo_E;
                Ray ray_E = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray_E, out hitInfo_E))
                {
                    if (hitInfo_E.collider.tag != tags)
                    {
                        end_name = hitInfo_E.collider.gameObject.name;
                        Debug.Log(end_name + "");


                    }
                }
            }
            else
            {
                start_name = end_name = "";
            }


           
        }
    }

    public string tags="";
  public  string start_name, end_name;
    private Vector3 GetPosInWorld(Vector3 pos)
    {
        Ray ray = _camera.ScreenPointToRay(pos);
        return ray.origin + ray.direction * CutPlaneDistance;
    }



    public bool interrrupted { get; private set; }
    public float MinSplitDistance = 10;

    public float CutPlaneDistance = 5f;

   
}
