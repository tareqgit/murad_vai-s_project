using UnityEngine;
using System.Collections;

public class buttonHandler : MonoBehaviour {

    public static string Selected_Class;

    public void class_selection(int m_class)
    {
        Selected_Class = m_class+"";
        Change_Sceane();//just for test
       
    }

    void Change_Sceane()
    {
        Instantiate(Resources.Load("loading_Canvas"));

    }

}
