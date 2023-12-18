using UnityEngine;

namespace Internal.Codebase.Runtime.Camera
{
    [CreateAssetMenu(menuName = "StaticData/Create CameraConfig", fileName = "CameraConfig", order = 3)]
    public class CameraConfig : ScriptableObject
    {
        [field: SerializeField] public UnityEngine.Camera Camera { get; private set; }
    }
}