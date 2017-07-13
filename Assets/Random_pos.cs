using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Random_pos : MonoBehaviour {
  public List <Question> questions;

 public  List<Image> L_buttons;
 
 public   List<Image> R_buttons;

   

    test[] tests = new test[]
    {
      new test(new int[] { 0, 1, 2 }),
      new test(new int[] { 2, 0, 1 }),

     new test( new int[] { 1, 0, 2 }),
     new test(new int[] { 1, 2, 0 } ),
     new test(new int[] { 2, 1, 0 })
    };

    int num = 0;
    void Awake()
    {

        num = 0;
        int random_value = Random.Range(1, 5);
        foreach (GameObject gobj in GameObject.FindGameObjectsWithTag("Left"))
        {
            Image[] images_ = gobj.GetComponentsInChildren<Image>();
           
            foreach (Image img in images_) //for accessing in the array
            {
                
                if (img.gameObject.transform.childCount == 0) //as i need the last element of this array so i called 
                {
                    img.gameObject.name = "should have no child"; //changing the name of that gameObject for checking targetting is right
              //      img.sprite = choises[tests[ random_value].test1[num]].chs_sprites_1;
                    gobj.name = img.sprite.name;
                    
                    //Debug.Log("" + i);
                }
            }
            L_buttons.Add( gobj.GetComponent<Image>());
            num++;
          
        }
        num = 0;
        random_value = Random.Range(1, 5);
        foreach (GameObject gobj in GameObject.FindGameObjectsWithTag("Right"))
        {


            Image[] images_ = gobj.GetComponentsInChildren<Image>();
            foreach (Image img in images_) //for accessing in the array
            {

                if (img.gameObject.transform.childCount == 0) //as i need the last element of this array so i called 
                {
                    img.gameObject.name = "should have no child"; //changing the name of that gameObject for checking targetting is right
                 //   img.sprite = choises[tests[random_value].test1[num]].chs_sprites_2;
                    gobj.name = img.sprite.name;

                    //Debug.Log("" + i);
                }
            }
            R_buttons.Add(gobj.GetComponent<Image>());
            num++;
        }

    }
    // Use this for initialization
    void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

[System.Serializable]
public class Question
{
    public string name;
  public  chs_sprites ch1;
   public chs_sprites ch2;
   public chs_sprites ch3;

    public Question(string name, chs_sprites ch1, chs_sprites ch2,chs_sprites ch3)
    {   
        
        this.name=name;
        this.ch1 = ch1;
        this.ch2 = ch2;
        this.ch3 = ch3;   

    }
}


[System.Serializable]
public class chs_sprites
{
    public Sprite chs_sprites_1;
    public Sprite chs_sprites_2;
    public chs_sprites(Sprite _chs_sprutes_1, Sprite _chs_sprutes_2)
    {
        chs_sprites_1 = _chs_sprutes_1;
        chs_sprites_2 = _chs_sprutes_2;

    }

}

public class test
{
    public int[] test1;

        public test(int[] test1)
    {
        this.test1 = test1;
    }
}
