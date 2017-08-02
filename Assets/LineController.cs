using UnityEngine;
using System.Collections;

public class LineController : MonoBehaviour {


    public GameObject[] Lines;
    public static int cur_Line=0;

    public static LineController instance;
    void Awake()
    {
        instance = this;
        m_Start();
    }


	// Use this for initialization
	public void m_Start ()
    {
        for(int i = 0; i <= cur_Line; i++)
        {
            if (i <= 2)
            {
                Lines[i].SetActive(true);
            }
        }
	
	}
	
}
