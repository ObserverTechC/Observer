using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Chat : MonoBehaviour {

    //要素を追加するコンテント
    [SerializeField] RectTransform content;

    //生成する要素
    [SerializeField] RectTransform chatBack; //チャットの枠

    [SerializeField] Text chatText; //チャットのテキスト

    public string[] talk; //チャットの内容を格納
    public int currenttalk = 0;// 現在のテキスト
    public stickset st;
    Image chatcolor; //チャットの枠の色
    public Image haikei; //チャット背景
    public GameObject scroll;
    public jairon Jairon;
    public GameObject[] obj;

    void Awake()
    {

        chatBack.gameObject.SetActive(false); 
        haikei.enabled = false; 
        scroll.SetActive(false);
    }

    void Start()
    {

        this.GetComponent<Canvas>().enabled = true; 
        st.enabled = false; //sticksetを無効
        haikei.enabled = true;
        scroll.SetActive(true);
        chatcolor = chatBack.GetComponent<Image>();
        OnSubmit();
    }

   void Update()
    {
        
       if (Input.GetButtonDown("Fire1"))
        {
           //currenttalkが９以上で処理
            if (currenttalk >= 9)
            {
                haikei.enabled = false;
                scroll.SetActive(false);
                st.enabled = true; //sticksetを有効
                this.GetComponent<Chat>().enabled = false;
                Jairon.enabled = true;

                for (int i = 0; i < obj.Length; i++)
                {
                    obj[i].SetActive(false);
                }

            }
            else
            {
                OnSubmit();
                
            }
            
        }
      
      
    }
    
    
    public void OnSubmit()
    {
        //currenttalkによってチャットの枠の色を変える
        switch (currenttalk)
        {
            case 0:
            case 2:
            case 3:
            case 5:
            case 7:
                chatcolor.color = new Color(1.0f, 1.0f, 1.0f); //白
                break;
            case 1:
            case 4:
            case 6:
            case 8:
                chatcolor.color = new Color(0.0f, 1.0f, 0.3f); //緑
                break;

            default:
                
                break;


        }
        // textを切り替える
        chatText.text = talk[currenttalk];
        currenttalk++;
       
        
        //content以下にchatBackを複製
        var element = GameObject.Instantiate<RectTransform>(chatBack);
        element.SetParent(content, false);
        element.SetAsLastSibling();
        element.gameObject.SetActive(true);

        
    }
}
