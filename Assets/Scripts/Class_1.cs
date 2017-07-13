using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Class_1 : MonoBehaviour
{
    public static int question_no_running = 0;

    public Image Question;

    public Button[] buttons;

    public question[] questions;//question is a class and we are creating an array of a class


    void Start()
    {
        change_image();

    }

    public void change_image() //this method responsible for Changing sprite image on the answer keys.
    {

     Image[] images_=   Question.GetComponentsInChildren<Image>();
        foreach (Image img in images_) //for accessing in the array
        {

            if (img.gameObject.transform.childCount == 0) //as i need the last element of this array so i called 
            {
                img.gameObject.name = "should have no child"; //changing the name of that gameObject for checking targetting is right

                img.gameObject.GetComponent<Image>().sprite = questions[question_no_running].question_Sprite ;//accessing sprite from the multi-Dimensional array.
                                                                                                                      //Debug.Log("" + i);
            }
        }
        for (int i = 0; i < buttons.Length; i++) //for loop as we have more than one answer key.
        {
            Image[] images = buttons[i].GetComponentsInChildren<Image>();//This Line will get every single Image Component attched on the button itself and its children's also in an array. So there is a chance for getting wrong Component.

            foreach (Image img in images) //for accessing in the array
            { 
                
                    if (img.gameObject.transform.childCount == 0) //as i need the last element of this array so i called 
                    {
                        img.gameObject.name = "should have no child"; //changing the name of that gameObject for checking targetting is right

                        img.gameObject.GetComponent<Image>().sprite = questions[question_no_running].options[i].option_sprite;//accessing sprite from the multi-Dimensional array.
                        //Debug.Log("" + i);
                    }
                }

                for (int k = 0; k < images.Length; k++) //if we need to target marked child then
                {
                    if (k == 1)//child no
                    {
                        images[k].gameObject.name = "Should be target Child";
                    }
                }
            }
        }

    
    //Getting the input from the answer keys.
    public void button_input_Relust(int result)
    {

        if (result == questions[question_no_running].answer)
        {
            Debug.Log("Write Answer");
            PlayerPrefs.SetInt("Score", (PlayerPrefs.GetInt("Score") + 3));


            if (question_no_running + 1 < questions.Length)
            {
                question_no_running++;
                change_image();
            }


        }
        else
        {
            Debug.Log("Wrong Answer");
            Game_Manager.instance.Life--;
            Game_Manager.instance.LifeManager();
        }
    }
}









[System.Serializable] //for making it visible on the editor
public class question
{
    public string question_string;
    public Sprite question_Sprite;
    public Option[] options;//this is a Class Under this class 
    public int answer;

    public question(string question_string,Sprite question_Sprite, Option[] options, int answer)//constructor for accessing them by pressing .
    {
        this.question_string = question_string;
        this.question_Sprite = question_Sprite;
        this.options = options;
        this.answer = answer;
    }
}


[System.Serializable]
public class Option
{
    public string option_string;
    public Sprite option_sprite;

    public Option(string option_str, Sprite opt_spr)//constructor for accessing them by pressing .
    {
        this.option_string = option_str;
        this.option_sprite = opt_spr;
    }
}