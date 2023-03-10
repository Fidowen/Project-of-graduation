using UnityEngine;
using System.Collections;

namespace Valve.VR
{
	public class SteamVR_CameraHelper : MonoBehaviour
	{
		void Start()
		{
#if OPENVR_XR_API && UNITY_LEGACY_INPUT_HELPERS
			if (this.gameObject.GetComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>() == null)
			{
				UnityEngine.SpatialTracking.TrackedPoseDriver a = this.gameObject.AddComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>();
				a.trackingType = UnityEngine.SpatialTracking.TrackedPoseDriver.TrackingType.PositionOnly;

			}
#endif
		}
	}
}