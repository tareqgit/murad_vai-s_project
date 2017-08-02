using UnityEngine;
using System.Collections;

public class Our_Button : MonoBehaviour {
    public static int selectedButton;


    public void m_selectedButton(int clickedBut)
    {
        selectedButton = clickedBut;
        class_3.instance.button_input_Relust(clickedBut);
    }
	
}
