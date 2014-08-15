using UnityEngine;
using System.Collections;

//
// 元ネタ：http://detail.chiebukuro.yahoo.co.jp/qa/question_detail/q11128560141   .
//
public class ObjectRotateClamp : MonoBehaviour {
	
	public float maxAngleH = 60; // 最大回転角度.
	public float minAngleH = -60; // 最小回転角度.

	public float maxAngleV = 60; // 最大回転角度.
	public float minAngleV = -60; // 最小回転角度.

	public float speed = 0.5f; // 回転スピード.

	void Start () {
	}
	
	void Update () {
		// 入力情報.
		float turnH = Input.GetAxis("Horizontal");
		// 現在の回転角度を0～360から-180～180に変換.
		float rotateY = (transform.eulerAngles.y > 180) ? transform.eulerAngles.y - 360 : transform.eulerAngles.y;
		// 現在の回転角度に入力(turn)を加味した回転角度をMathf.Clamp()を使いminAngleからMaxAngle内に収まるようにする.
		float angleY = Mathf.Clamp(rotateY + turnH * speed, minAngleH, maxAngleH);
		// 回転角度を-180～180から0～360に変換.
		angleY = (angleY < 0) ? angleY + 360 : angleY;

		// 入力情報.
		float turnV = Input.GetAxis("Vertical");
		// 現在の回転角度を0～360から-180～180に変換.
		float rotateX = (transform.eulerAngles.x > 180) ? transform.eulerAngles.x - 360 : transform.eulerAngles.x;
		// 現在の回転角度に入力(turn)を加味した回転角度をMathf.Clamp()を使いminAngleからMaxAngle内に収まるようにする.
		float angleX = Mathf.Clamp(rotateX + turnV * speed, minAngleV, maxAngleV);
		// 回転角度を-180～180から0～360に変換.
		angleX = (angleX < 0) ? angleX + 360 : angleX;

		// 回転角度をオブジェクトに適用.
		transform.rotation = Quaternion.Euler(angleX, angleY, 0);
	}
}
