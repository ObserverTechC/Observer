using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class camerahac : MonoBehaviour
{
    /// <summary>
    /// カメラをタッチしたかの判定のスクリプト
    /// </summary>
    GameObject target;
    public Camera activecamera;
    Camerakirikae camerakirikae;
    public float cameracode = 0;
    public GameObject obj2;
    Ray ray;
    string rayobj;
    void start()
    {

    }
    void Update()
    {
        camerakirikae = obj2.GetComponent<Camerakirikae>();
        if (Input.GetMouseButtonDown(0))
        {
            if (camerakirikae.Playermode)
            {
                //プレイヤーカメラからの判定取得
                ray = camerakirikae.mainCamera.ScreenPointToRay(Input.mousePosition);
            }
            else
            {
                //監視カメラからの判定取得
                ray = camerakirikae.HacCamera.ScreenPointToRay(Input.mousePosition);
            }
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject);
                rayobj = hit.collider.gameObject.ToString();
                GameObject obj = hit.collider.gameObject;
                if (obj == gameObject)
                {
                    if (cameracode == 0)
                    {
                        Light ligatgrean = transform.FindChild("Point light").gameObject.GetComponent<Light>() ;
                        ligatgrean.enabled = true;
                        //初めて自分がタッチされたとき
                        //カメラの向きによりカメラモードの変更を可能にする
                        Screen.autorotateToLandscapeRight = true;
                        Screen.autorotateToLandscapeLeft = true;
                        int i = 0;
                        while (camerakirikae.cameras[i] != null)
                        {
                            if (camerakirikae.cameras[i] == gameObject)
                            {
                                i = -1;
                                break;
                            }
                            i++;
                        }
                        if (i != -1)
                        {
                            //camerakirikaeのスクリプトに
                            //新しいカメラの情報を入れる
                            camerakirikae.cameras[i] = gameObject;
                        }
                    }
                }
            }
        }
    }
    void OnGUI()//確認用デバッグGUI
    {
        //GUI.Label(new Rect(20, 200, 100, 50), rayobj);

    }
}
