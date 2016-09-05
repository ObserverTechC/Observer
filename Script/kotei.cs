using UnityEngine;
using System.Collections;

public class kotei : MonoBehaviour {
    /// <summary>
    /// 主人公のモデルが傾かないようにするためのスクリプト
    /// </summary>

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.rotation = Quaternion.Euler(0, gameObject.transform.rotation.y,0 );
    }
}
