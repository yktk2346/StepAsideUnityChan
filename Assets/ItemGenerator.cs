using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    


    /*
    // Use this for initialization
    void Start () {
        return;
                //一定の距離ごとにアイテムを生成
                for (int i = startPos; i < goalPos; i+=15) {
                        //どのアイテムを出すのかをランダムに設定(11枚のカードから一枚引く（0が含まれる）)
                        int num = Random.Range (0, 10);
            //適当に引いたカードが1以下だった場合とそれ以外
                        if (num <= 1) {
                //コーンをx軸方向に一直線に生成（等間隔でコーンを並べることを想定したコード）
                //等間隔＝コーン同士の被りや、狭い隙間ができないようにするためのもの
                 
                //↓ロジックを日本語化
                //「コーンを実体化しヒエラルキー上でも動かせるようにして、
                //コーンの配置は　zが15ｍごと、yはそのまま、
                //xは道路からはみ出ないよう「4」にしてコーンを等間隔にしたいため「j」をかける」
                
                //単純に「道路の幅　×　開けたい間隔」でよい。「左-1, 中0, 右1」は道路の幅にちょうど良い。数を増やすとコーンが道路外に出る
                //「0.4f」はコーンが生成される限界幅（個数に関係）、「4」はコーン同士の幅（広さに関係。小さい数だと重なる）
                for (float j = -1; j <= 1; j += 0.4f) {
                                        GameObject cone = Instantiate (conePrefab) as GameObject;
                                        cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, i);
                                }
                        } else {

                                //レーン（道路の3車線）ごとにアイテムを生成
                                //「-1 0 1」＝「左　中　右」、2（右に行きすぎ）、「j++」なので左（-2）に行きすぎることはない
                                for (int j = -1; j < 2; j++) {

                                        //アイテムの種類を決める、出現率（%）に使う
                                        //10種類（100%）の出現率を作りたいため、11未満（1, 11）で生成する
                                        //（1, 11）←第二引数は含まれない（11未満）
                                        int item = Random.Range (1, 11);
                                        //アイテムを置くZ座標のオフセット（基準点からの距離？）をランダムに設定、x軸用？
                                        //「15m」ごとに、そこから「-5～5」の感覚で生成する
                                        int offsetZ = Random.Range(-5, 6);
                                        //60%コイン配置:30%車配置:10%何もなし
                                        if (1 <= item && item <= 6) {
                                                //コインを生成
                                                //coinにcoinPrefabが代入される
                                                GameObject coin = Instantiate (coinPrefab) as GameObject;
                                                coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, i + offsetZ);
                                        } else if (7 <= item && item <= 9) {
                                                //車を生成
                                                GameObject car = Instantiate (carPrefab) as GameObject;
                                                car.transform.position = new Vector3 (posRange * j, car.transform.position.y, i + offsetZ);
                                        }
                                }
                        }
                }
        }
*/

    void ItemCreate()
    {
        //Unityちゃんのちょっと先（+50f先）の位置
        float nextPos = GameObject.Find("unitychan").transform.position.z + 50f;
        //どのアイテムを出すのかをランダムに設定(11枚のカードから一枚引く（0が含まれる）)
        int num = Random.Range(0, 10);


        //goalよりアイテムのz（nextPos）が小さかった場合、アイテム生成を終了する
        if (nextPos >= goalPos)
        {
            //リターンする。リターンするとここで関数の処理が終わる
            //「早期リターン」という。関数の冒頭で条件をチェックしreturnすること
            return;
        }

            //適当に引いたカードが1以下だった場合とそれ以外
            if (num <= 1)
            {
                //コーンをx軸方向に一直線に生成（等間隔でコーンを並べることを想定したコード）
                //等間隔＝コーン同士の被りや、狭い隙間ができないようにするためのもの

                //↓ロジックを日本語化
                //「コーンを実体化しヒエラルキー上でも動かせるようにして、
                //コーンの配置は　zが15ｍごと、yはそのまま、
                //xは道路からはみ出ないよう「4」にしてコーンを等間隔にしたいため「j」をかける」

                //単純に「道路の幅　×　開けたい間隔」でよい。「左-1, 中0, 右1」は道路の幅にちょうど良い。数を増やすとコーンが道路外に出る
                //「0.4f」はコーンが生成される限界幅（個数に関係）、「4」はコーン同士の幅（広さに関係。小さい数だと重なる）
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, nextPos);
                }
            }
            else
            {

                //レーン（道路の3車線）ごとにアイテムを生成
                //「-1 0 1」＝「左　中　右」、2（右に行きすぎ）、「j++」なので左（-2）に行きすぎることはない
                for (int j = -1; j < 2; j++)
                {

                    //アイテムの種類を決める、出現率（%）に使う
                    //10種類（100%）の出現率を作りたいため、11未満（1, 11）で生成する
                    //（1, 11）←第二引数は含まれない（11未満）
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセット（基準点からの距離？）をランダムに設定、x軸用？
                    //「15m」ごとに、そこから「-5～5」の感覚で生成する
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        //coinにcoinPrefabが代入される
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, nextPos + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, nextPos + offsetZ);
                    }
                }
            }
        }



    //時間計測用の変数
    private float _timeConter = 0;
    //何秒おきに関数を呼ぶかを決めるインターバルの秒数
    private float _intervalTime = 3f;

// Update is called once per frame
void Update () {
        /*
          60フレームでゲームが動いていた場合は 1/60秒 が加算される
         「deltaTime」は前フレームまでの時間と現在フレームまでの時間の差分のこと
         「deltaTime」=「1/60秒」、もしゲームが60フレームで動いてたら1秒に60回呼ばれ、計1秒となる（余談 1/60 = 0.016666667… とても小さい数）
         計1秒になると「_timeConter」が「1」になる
        */
        _timeConter += Time.deltaTime;

        //3秒たったら
        if (_timeConter >= _intervalTime) {
            ItemCreate();
            //繰り返しこの処理を行いたいので_timeConterをリセットする
            _timeConter = 0;
        }
    }
}