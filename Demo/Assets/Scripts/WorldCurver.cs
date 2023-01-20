using UnityEngine;

[ExecuteInEditMode]
public class WorldCurver : MonoBehaviour
{
	[Range(-0.01f, 0.01f)]
	public float curveStrengthY = 0.01f;
	[Range(-0.01f, 0.01f)]
	public float curveStrengthX = 0.01f;
	int Y_CurveStrengthID;
	int X_CurveStrengthID;

    private void OnEnable()
    {
        Y_CurveStrengthID = Shader.PropertyToID("_CurveStrengthY");
		X_CurveStrengthID = Shader.PropertyToID("_CurveStrengthX");
	}

	void Update()
	{
		Shader.SetGlobalFloat(Y_CurveStrengthID, curveStrengthY);
		Shader.SetGlobalFloat(X_CurveStrengthID, curveStrengthX);
	}
}
