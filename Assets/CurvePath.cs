using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvePath {

	// how many points interpolated between 2 control points
	public int resolution = 20;

	private List<Vector3> result;

	public void SetControlPoints (Vector3[] pts) {

		if (pts.Length < 4) {
			throw new UnityException ("Catmull-Rom curve need 4 points at least.");
		}

		result = new List<Vector3>();

		//first line segment
		Vector3 P0 = pts [0]; // use Vector3 P0 = pts[pts.length - 1]; if loop
		Vector3 P1 = pts [0];
		Vector3 P2 = pts [1];
		Vector3 P3 = pts [2];
		ProcessSegment (P0, P1, P2, P3);

		//line segment between first and last
		for (int i = 0; i < pts.Length - 3; i++) {
			P0 = pts [i];
			P1 = pts [i + 1];
			P2 = pts [i + 2];
			P3 = pts [i + 3];

			ProcessSegment (P0, P1, P2, P3);
		}

		//last line segment
		P0 = pts [pts.Length - 3];
		P1 = pts [pts.Length - 2];
		P2 = pts [pts.Length - 1];
		P3 = pts [pts.Length - 1]; //use P3 = pts [0]; if loop

		ProcessSegment (P0, P1, P2, P3);
	}

	public Vector3[] GetResultPoints() {
		return result.ToArray();
	}

	private void ProcessSegment(Vector3 P0, Vector3 P1, Vector3 P2, Vector3 P3) {
		for (int step = 0; step < resolution; ++step) {
			float t = (float) step / (float) resolution;
			float t2 = t * t;
			float t3 = t2 * t;
			Vector3 point = 0.5f * ((2 * P1) + (-P0 + P2) * t + (2 * P0 - 5 * P1 + 4 * P2 - P3) * t2 + (-P0 + 3 * P1 - 3 * P2 + P3) * t3);
			result.Add (point);
		}
	}
}
