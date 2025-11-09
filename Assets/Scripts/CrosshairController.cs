// 更新 CrosshairController.cs
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    [Header("准星设置")]
    public Texture2D crosshairTexture;
    public Vector2 crosshairSize = new Vector2(20, 20);

    [Header("射线检测")]
    public float interactionDistance = 100f;
    public LayerMask floorLayerMask = -1;

    public int num;
    private TextMeshProUGUI tmp;
    private void Start()
    {
        if(SceneManager.GetActiveScene().name == Scene1.name)
        {
            num = 10;
        }
        else if (SceneManager.GetActiveScene().name == Scene2.name)
        {
            num = 13;
        }
        else if (SceneManager.GetActiveScene().name == Scene3.name)
        {
            num = 17;
        }
        Debug.Log("哦啦啦啦");
        gameRoot.Instance.UIManagerRoot.push(new NumPanel());
        if (gameRoot.Instance.UIManagerRoot.uidic.ContainsKey(NumPanel.uIType.Name))
        {
            Debug.Log("yeah磊哥磊哥磊哥");
             tmp = gameRoot.Instance.UIManagerRoot.uidic[NumPanel.uIType.Name].transform.Find("Text").GetComponent<TextMeshProUGUI>();
            tmp.text = num.ToString();
            



        }
    }

    void Update()
    {
        
        CheckForFloorClick();
        CheckEventClick();
        numCheck();
    }

    void numCheck()
    {
        
        if(Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.Locked&&gameRoot.Instance.SceneSW==false&&num>0)num--;
        tmp.text = num.ToString();
        if (num <= 0 && gameRoot.Instance.UIManagerRoot.uidic.ContainsKey(LosePanel.uIType.Name)==false) 
        {
           // gameRoot.Instance.UIManagerRoot.push(new LosePanel());
        }

    }
    void OnGUI()
    {
        // 只在鼠标锁定时显示准星
        if (Cursor.lockState == CursorLockMode.Locked && crosshairTexture != null)
        {
            Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            Rect crosshairRect = new Rect(
                screenCenter.x - crosshairSize.x / 2,
                screenCenter.y - crosshairSize.y / 2,
                crosshairSize.x,
                crosshairSize.y
            );
            GUI.DrawTexture(crosshairRect, crosshairTexture);
        }
    }

    private void CheckForFloorClick()
    {
        if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.Locked)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance, floorLayerMask))
            {
                //soundeff();
                FloorController floor = hit.collider.GetComponent<FloorController>();
                if (floor != null)
                {
                    floor.OnFloorClicked();
                }
            }
        }
    }

    //kjq do work  vvvvv
    private void CheckEventClick()
    {
        if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.Locked)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance, floorLayerMask))
            {
                soundeff();
                cubeController cube = hit.collider.GetComponent<cubeController>();
                if (cube != null)
                {
                    cube.OnCubeClicked();
                }
                scene1Tigger scene1tigger = hit.collider.GetComponent<scene1Tigger>();
                scene2Tigeer scene2tigger = hit.collider.GetComponent<scene2Tigeer>();
                scene3Tigger sc3t= hit.collider.GetComponent<scene3Tigger>();
                if(scene1tigger != null)
                {
                    //.Log("sc1tiger");
                    scene1tigger.eventTigger();
                }
               // Debug.Log("ROROORORCK");
               
                else if (scene2tigger != null)
                {
                    scene2tigger.eventTigger();
                }
                
                else if (sc3t != null)
                {
                    sc3t.eventTigger();
                }

            }
        }
    }

    private void soundeff()
    {
        GameObject.Instantiate(Resources.Load("soundPrefabs/touch"));
    }

}