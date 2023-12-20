using UnityEngine;

namespace Internal.Codebase.Infrastructure.Services.CameraService
{
    public interface ICameraService
    {
        public void Init();

        public Camera GetCamera();
    }
}