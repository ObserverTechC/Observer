using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// コイツは監視カメラの情報をしまったりぃ、
/// 監視カメラの切り替えの本題的な部分とかを担ってんだぁ
/// 過労死シンクロン的なスクリプトだっぺ
/// プレイヤーのリジットボデェのところになげて使うんだっぺ
/// </summary>
public class Camerakirikae : MonoBehaviour {
    public bool Playermode = true;
    public int cameracode = 0;
    public int maenocamer = 0;
    public Camera mainCamera;
    public GameObject[] cameras;
    jairon Jairon, Jaironhac;
    camerahac Camerahac;
    public GameObject main;
    public Image stick, back, next;
    public Camera HacCamera;
    public GameObject hac;
    public GameObject hacamera;
    public int changecode;
    public Image camerawaku;
    // Use this for initialization
    void Start () {
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToPortraitUpsideDown = false;
    }
	// Update is called once per frame
	void Update () {
        Jairon = main.GetComponent<jairon>();
        //新しい監視カメラの登録及び監視カメラの切り替えに使っている。
        //具体的にどう動いてるかわからないのは全部ドン・サウザントのせい。
        if (cameras[0] != null)
        {
            if (cameracode >= cameras.Length)
            {
                cameracode = 0;
            }
            else if (cameracode <= -1)
            {
                cameracode = cameras.Length - 1;
            }
            while (cameras[cameracode] == null)
            {
                cameracode += changecode;
                if (cameracode >= cameras.Length)
                {
                    cameracode = 0;
                }
                else if (cameracode <= -1)
                {
                    cameracode = cameras.Length - 1;
                }
            } 
            HacCamera = cameras[cameracode].transform.FindChild("hacCamera").gameObject.GetComponent<Camera>();
            hac = cameras[cameracode].transform.FindChild("hacCamera").gameObject;
            hacamera = cameras[cameracode].gameObject;
            //スマホが横持ちかどうかを検知してプレイヤーモードか、監視カメラモードか切り替える。
            if (Playermode)
            {
                playermode();
            }
            else
            {
                haccameramode();
            }
        }
	}

    void playermode() {
        //プレイヤーモード
        mainCamera.GetComponent<jairon>().enabled = true;
        mainCamera.enabled = true;
        stick.enabled = true;
        back.enabled = false;
        next.enabled = false;
        camerawaku.enabled = false;
        if (cameras[0] != null)
        {
            hacamera.GetComponent<jairon>().fast = true;
            hacamera.GetComponent<jairon>().enabled = false;
            HacCamera.enabled = false;
        }
    }
    void haccameramode(){
        //監視カメラモード
        hacamera.GetComponent<jairon>().enabled = true;
        HacCamera.enabled = true;
        back.enabled = true;
        next.enabled = true;
        mainCamera.GetComponent<jairon>().fast = true;
        mainCamera.GetComponent<jairon>().enabled = false;
        mainCamera.enabled = false;
        stick.enabled = false;
        camerawaku.enabled = true;
    }
}
