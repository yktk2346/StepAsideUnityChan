using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

    //例:通り過ぎたアイテムを自動削除するため、カメラの位置を入れる箱
    //public GameObject myCamera;



	// Use this for initialization
	void Start () {

        //例:アイテムを削除するため、カメラの位置を取得
        //myCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

        //アイテムを削除するため、カメラの位置を取得し（Camera.main）、比較し、小さければ削除
        if (gameObject.transform.position.z < Camera.main.transform.position.z) {
            Destroy(gameObject);
        }
	}
}
