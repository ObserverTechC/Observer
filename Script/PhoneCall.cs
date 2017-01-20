using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;


public class PhoneCall : MonoBehaviour {
    public stickset st;

    public AudioSource[] audioSource = new AudioSource[2];    // AudioSorceコンポーネント格納用

    public Image[] button = new Image[2];
   
    public int hantei = 0;  //電話に出たか拒否したか無視したかの判定
    bool a = true;
    
    public Text timetext; //電話の待機時間のテキスト
    int secound; //電話の待機時の経過時間
    float time; //電話の待機時間

	// Use this for initialization
	void Start () {
       
        OnUnPause();

        st.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        //ジョイスティックの位置を固定
        CrossPlatformInputManager.SetAxis("Horizontal", 0);
        CrossPlatformInputManager.SetAxis("Vertical", 0);

        if (Input.GetKeyDown("p"))
        {
                OnPause();            
        }
        if (hantei == 2)
        {
            time += Time.deltaTime;
            if (time >= 1)
            {
                secound++;
                time = 0;
            }
            if (secound < 10)
            {
                timetext.text = "00" + "：" + "0" + secound.ToString();
            }
            else
            {
                timetext.text = "00" + "：" + secound.ToString();
            }
        }
	}

    //ボタンタップ
    public void OnClick(int num)
    {
        //ボタンをタップしていなければ処理
        if (hantei == 0)
        {


            switch (num)
            {
                case 1: //応答
                    hantei = 1;
                    
                    st.enabled = true;
                    OnUnPause();
                    
                    break;
                case 2: //拒否
                    button[0].enabled = false;
                    button[1].enabled = false;
                    audioSource[1].Play();
                    st.enabled = true;
                    hantei = 2;
                    StartCoroutine("deetaa");
                    break;
                default:

                    break;
            }
        }

        
    }

    //Canvasを表示し、sticksetを無効
    public void OnPause()
    {
        if (a)
        {
            
            StartCoroutine("Loop");
            a = false;
        }


        button[0].enabled = true;
        button[1].enabled = true;
       
        this.GetComponent<Canvas>().enabled = true;

        st.enabled = false;
        
    }


    //Canvasを非表示し、sticksetを有効
    public void OnUnPause()
    {

        st.enabled = true;
        button[0].enabled = false;
        button[1].enabled = false;
        this.GetComponent<Canvas>().enabled = false;
        timetext.enabled = false;
        a = true;
                          
    }


    IEnumerator Loop()
    {


        for (int i = 0; i < 4; i++)
        {
            if (hantei == 0)
            {
                Handheld.Vibrate();//バイブレーションを起こす
                audioSource[0].Play();
            }
            yield return new WaitForSeconds(2.0f);
        }
        if (hantei == 0)
        {
            OnUnPause();
        }
    }
    IEnumerator deetaa()
    {
        timetext.enabled = true;       
        yield return new WaitForSeconds(18f);
        OnUnPause();
    }

   

}
