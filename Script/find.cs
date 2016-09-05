using UnityEngine;
using System.Collections;

public class find : MonoBehaviour
{
    GameObject enemy;
    public bool sikakuhantei = true;
    public bool sound =false;
    public bool Findbool=false;//発見状態かの判断
    // Use this for initialization
    void Start()
    {
        GameObject enemy = transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }
    //GameObject TragetObject = GameObject.FindGameObjectWithTag ("Player");
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Findbool = false;//発見状態
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(sikakuhantei){
            if (col.tag == "Player")
            {
                GameObject player = GameObject.Find("RigidBodyFPSController");
                GameObject enemy = gameObject.transform.parent.gameObject;
                RaycastHit hit;
                // ターゲットオブジェクトとの差分を求め
                Vector3 temp = player.transform.position - enemy.transform.position;
                // 正規化して方向ベクトルを求める
                Vector3 normal = temp.normalized;
                if (Physics.Raycast(transform.position, normal, out hit))
                {
                    print(hit.collider.tag);
                    if (hit.collider.tag == "Player")
                    {
                        // TargetObjectを見つけた
                        print("Found TargetObject");
                        Findbool = true;//発見状態
                        if (!sound)
                        {
                            sound = true;
                            player.GetComponents<AudioSource>()[0].Play();
                        }
                    }
                    else
                    {
                        Findbool = false;//発見状態
                    }
                }
            }
        }
    }
}
