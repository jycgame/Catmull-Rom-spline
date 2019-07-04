using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	Vector3[] controlPoints = new[] { new Vector3(232.5356f,527.7886f,0f), new Vector3(271.4172f,552.1719f,0f), new Vector3(322.1609f,581.1683f,0f), new Vector3(383.4488f,607.5287f,0f), new Vector3(438.8055f,629.276f,0f), new Vector3(517.8867f,654.3184f,0f), new Vector3(568.6304f,670.1346f,0f), new Vector3(643.7574f,685.2917f,0f), new Vector3(741.2911f,695.8359f,0f), new Vector3(835.5294f,692.5408f,0f), new Vector3(870.4569f,686.6097f,0f), new Vector3(895.4993f,679.3606f,0f), new Vector3(925.8137f,661.5674f,0f), new Vector3(955.5096f,643.9139f,0f), new Vector3(970.0485f,624.4731f,0f), new Vector3(979.7225f,600.2214f,0f), new Vector3(980.858f,575.6234f,0f), new Vector3(976.6263f,555.1798f,0f), new Vector3(966.9241f,528.5471f,0f), new Vector3(954.3204f,503.7983f,0f), new Vector3(935.9276f,480.187f,0f), new Vector3(912.8449f,459.381f,0f), new Vector3(888.4437f,442.1952f,0f), new Vector3(861.6976f,426.0916f,0f), new Vector3(830.2996f,410.4667f,0f), new Vector3(801.7729f,399.3142f,0f), new Vector3(777.47f,388.9719f,0f), new Vector3(742.6355f,374.953f,0f), new Vector3(696.5507f,359.6576f,0f), new Vector3(642.3289f,342.063f,0f), new Vector3(586.726f,326.8171f,0f), new Vector3(535.6072f,316.0553f,0f), new Vector3(492.5599f,307.9839f,0f), new Vector3(435.1633f,302.603f,0f), new Vector3(388.5287f,299.0157f,0f), new Vector3(351.759f,298.1189f,0f), new Vector3(294.3625f,301.7061f,0f), new Vector3(234.2755f,315.1584f,0f), new Vector3(187.6409f,332.1981f,0f), new Vector3(167.014f,343.8567f,0f), new Vector3(152.6649f,355.5154f,0f), new Vector3(139.2126f,369.8645f,0f), new Vector3(130.2443f,395.8723f,0f), new Vector3(132.9348f,420.0865f,0f), new Vector3(141.903f,441.6102f,0f), new Vector3(152.6649f,459.5466f,0f), new Vector3(167.014f,477.483f,0f), new Vector3(186.744f,494.5226f,0f), new Vector3(208.2677f,515.1494f,0f), new Vector3(228.8946f,528.6017f,0f) };

	// Use this for initialization
	CurvePath curvePath;

	void Start () {

		curvePath = new CurvePath ();
		curvePath.SetControlPoints (controlPoints);

		Vector3[] points = curvePath.GetResultPoints ();

		for (int i = 0; i < points.Length; ++i) {
			GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			sphere.transform.position = points [i];
			sphere.transform.localScale = new Vector3 (2, 2, 2);
			sphere.GetComponent<Renderer> ().material.color = Random.ColorHSV ();
		}
	}

	// Update is called once per frame
	void Update () {

	}

	void OnDrawGizmos() {
		if (curvePath == null)
			return;

		Vector3[] points = curvePath.GetResultPoints ();
		//
		//		for (int i = 0; i < points.Length; ++i) {
		//			Gizmos.DrawSphere (points [i], 0.2f);
		//		}
	}
}
