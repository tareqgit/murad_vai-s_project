using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    AsyncOperation asyncOperation;
    public GameObject loadingScreeen;

    public Slider progressbar;

    public Text LoadingText;

    public bool small_Scene =false;


    void Disable_All_canvas()
    {
        if (GameObject.Find("Canvas")!=null)
        {
            Debug.Log("Found");
        }
    }


    public void OnEnable()
    {
        
        loadingScreeen.SetActive(true);
        progressbar.gameObject.SetActive(true);
        LoadingText.gameObject.SetActive(true);
        LoadingText.text = "Loading....";


        StartCoroutine(LoadLevelRealProgress(SceneManager.GetActiveScene().buildIndex + 1));//



    }





    IEnumerator LoadLevelRealProgress(int level)
    {
        
        yield return new WaitForSeconds(1); //this is for showing all object on load sceane.

        asyncOperation = SceneManager.LoadSceneAsync(level);

        asyncOperation.allowSceneActivation = false; //this is why I dont want to allow sceane Active until user touch on the screen

        while (!asyncOperation.isDone)//as long as asynchronization is working
        {
            float l_progress = Mathf.Clamp01(asyncOperation.progress / 0.9f); //for showing progress
            Debug.Log("loading progress" + (l_progress * 100) + "%");


           
            if (!small_Scene) {
                progressbar.value = l_progress *100; //this line only shows actual progress can be fissy for little sceane
            }else
            {
                progressbar.value += Mathf.Lerp(0, asyncOperation.progress, Time.deltaTime); //setting progress value
            }

            if (asyncOperation.progress == 0.9f) //as it is near end so now asking for touch
            {
                if (small_Scene)
                {
                    progressbar.value += Mathf.Lerp(0, asyncOperation.progress, Time.deltaTime); //setting progress value
                }

                LoadingText.text = "Touch to Continue";
                if (Input.GetMouseButtonDown(0))
                {
                    asyncOperation.allowSceneActivation = true;
                }

            }

            yield return null;//execution will be paused and will continue in next frame
        }

    }


}
