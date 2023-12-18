using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.Components
{
    [DisallowMultipleComponent]
    public sealed class DragComponent : MonoBehaviour
    {
        [SerializeField] private float offset;
        
        private Vector2 difference = Vector2.zero;
        private UnityEngine.Camera camera;
        private Vector2 screenBounds;
        
        public void Constructor(UnityEngine.Camera camera)
        {
            this.camera = camera;
        }
        private void Start()
        {
            screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camera.transform.position.z));
        }

        private void OnMouseDown()
        {
            difference = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }

        private void OnMouseDrag()
        {
            transform.position = (Vector2)camera.ScreenToWorldPoint(Input.mousePosition) - difference;
            CheckBoundaries();
        }
        
        private void CheckBoundaries()
        {
            float x = Mathf.Clamp(transform.position.x, -screenBounds.x + offset, screenBounds.x - offset);
            float y = Mathf.Clamp(transform.position.y, -screenBounds.y + offset, screenBounds.y - offset);
            transform.position = new Vector3(x, y, 0);
        }
    }
}