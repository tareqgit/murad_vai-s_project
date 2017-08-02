using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class class_3 : MonoBehaviour {

    public static int question_no_running = 0;
    public GameObject Question;
    public GameObject answer;

    public question[] questions ;
    public static class_3 instance;


	// Use this for initialization
	void Awake () {
        answer.AddComponent<Button>();
        instance = this;
	}


    void Start()
    {
        change_image();

    }

    // Update is called once per frame
    void change_image() {
        Image[] images_ = Question.GetComponentsInChildren<Image>();
        foreach (Image img in images_) //for accessing in the array
        {

            if (img.gameObject.transform.childCount == 0) //as i need the last element of this array so i called 
            {
                img.gameObject.name = "should have no child"; //changing the name of that gameObject for checking targetting is right

                img.gameObject.GetComponent<Image>().sprite = questions[question_no_running].question_Sprite;//accessing sprite from the multi-Dimensional array.

                Camera.main.GetComponent<AudioSource>().clip = (questions[question_no_running].q_Clip);
                Camera.main.GetComponent<AudioSource>().Play();
                //Debug.Log("" + i);
            }
        }
        Image[] images_a = answer.GetComponentsInChildren<Image>();
        foreach (Image img in images_a) //for accessing in the array
        {

            if (img.gameObject.transform.childCount == 0) //as i need the last element of this array so i called 
            {
                img.gameObject.name = "should have no child"; //changing the name of that gameObject for checking targetting is right

                img.gameObject.GetComponent<Image>().sprite = questions[question_no_running].options;//accessing sprite from the multi-Dimensional array.

               
                //Debug.Log("" + i);
            }
        }
        answer.GetComponent<Button>().onClick.AddListener(open_button_panel);

    }
    public GameObject button_Panel;


    public void open_button_panel()
    {
        button_Panel.SetActive(true);
    }

    //Getting the input from the answer keys.
    public void button_input_Relust(int result)
    { 

        if (result == questions[question_no_running].answer)
        {
            Debug.Log("Write Answer");
           // PlayerPrefs.SetInt("Score", (PlayerPrefs.GetInt("Score") + 3));


            if (question_no_running + 1 < questions.Length)
            {
                question_no_running++;
                Camera.main.GetComponent<AudioSource>().Stop();
                change_image();

            }


        }
        else
        {
            Debug.Log("Wrong Answer");
            Game_Manager.instance.Life--;
            Game_Manager.instance.LifeManager();
            //Camera.main.GetComponent<AudioSource>().Stop();
        }
    }






 [System.Serializable] //for making it visible on the editor
    public class question
    {
        public string question_string;
        public Sprite question_Sprite;
        public Sprite options;//this is a Class Under this class 
        public int answer;
        public AudioClip q_Clip;

        public question(string question_string, Sprite question_Sprite, Sprite options, int answer, AudioClip q_clip)//constructor for accessing them by pressing .
        {
            this.question_string = question_string;
            this.question_Sprite = question_Sprite;
            this.options = options;
            this.answer = answer;
            this.q_Clip = q_clip;
        }
    }

}
