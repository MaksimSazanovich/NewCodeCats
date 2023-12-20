using System;
using Internal.Codebase.Infrastructure.Services.CameraService;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Runtime.Cat.Components
{
    [DisallowMultipleComponent]
    public sealed class CheckBoundariesComponent : MonoBehaviour
    {
        private Vector2 screenBounds;
        private ICameraService cameraService;
        [field: SerializeField] public float Offset { get; private set; }
        
        public void Constructor(ICameraService cameraService)
        {
            this.cameraService = cameraService;
        }
        private void Start()
        {
            screenBounds = cameraService.GetCamera().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                cameraService.GetCamera().transform.position.z));
        }

        private void Update()
        {
            CheckBoundaries();
        }

        private void OnMouseDrag()
        {
            CheckBoundaries();
        }

        public void CheckBoundaries()
        {
            var position = transform.position;
            float x = Mathf.Clamp(position.x, -screenBounds.x + Offset,
                screenBounds.x - Offset);
            float y = Mathf.Clamp(position.y, -screenBounds.y + Offset,
                screenBounds.y - Offset);
            position = new Vector3(x, y, 0);
            transform.position = position;
        }
    }
}