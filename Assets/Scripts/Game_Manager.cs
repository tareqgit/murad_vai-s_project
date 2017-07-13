using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour {
    

    public int score;
    public Text score_text;
    public GameObject Gameover;
    public Button retry;
    public Button exit;

    public Sprite[] life_and_death;
    public Image[] lifes_3;
    public static Game_Manager instance;
    public int Life;

    public Camera m_cam;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }




    void Start()
    {
        gameObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
        gameObject.GetComponent<Canvas>().worldCamera = GameObject.Find("Camera").GetComponent<Camera>();

        Gameover.SetActive(false);
        if (PlayerPrefs.GetInt("Score") <= -1)
        {
            score = PlayerPrefs.GetInt("Score", 0);
            PlayerPrefs.SetInt("Score", 10);
             }
        Life = 3;
        LifeManager();

    }


    // Update is called once per frame
    void Update () {


        if (gameObject.GetComponent<Canvas>().worldCamera==null)
        {
            gameObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
            gameObject.GetComponent<Canvas>().worldCamera = GameObject.Find("Camera").GetComponent<Camera>();

        }

        score = PlayerPrefs.GetInt("Score", 0);
        score_text.text = ""+score;
        if (Life <= 0)
        {
            Gameover.SetActive(true);
            
        }
    }

  public  void _Retry()
    {
        Debug.Log("Retry");
        if (PlayerPrefs.GetInt("Score") - 10 >= 0)
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - 10);
        }
        else
        {
            
        }
        Life++;
        LifeManager();
        Gameover.SetActive(false);

    }

   public void _Exit()
    {
        Gameover.SetActive(false);
        Debug.Log("Exit");
    }

  public  void LifeManager()
    {
        if (Life >= 0)
        {
            for (int i = 0; i < 3; i++) //as we have total 3 star 
            {
                if (i < Life)
                {
                    lifes_3[i].sprite = life_and_death[0];//set all of them life
                }
                else
                {
                    lifes_3[i].sprite = life_and_death[1];//set others death
                }
            }
        }

    }
}
