using System;
using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.Components
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class LayerSwitchComponent : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private int startSortingOrder;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out SpriteRenderer spriteRenderer))
            {
                if (transform.position.y <= other.transform.position.y)
                {
                    while (spriteRenderer.sortingOrder >= this.spriteRenderer.sortingOrder)
                        this.spriteRenderer.sortingOrder++;
                }
                
                else
                {
                    while (spriteRenderer.sortingOrder <= this.spriteRenderer.sortingOrder)
                        this.spriteRenderer.sortingOrder--;
                }
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out SpriteRenderer spriteRenderer))
            {
                if (transform.position.y <= other.transform.position.y)
                {
                    while (spriteRenderer.sortingOrder >= this.spriteRenderer.sortingOrder)
                        this.spriteRenderer.sortingOrder++;
                }
                
                else
                {
                    while (spriteRenderer.sortingOrder <= this.spriteRenderer.sortingOrder)
                        this.spriteRenderer.sortingOrder--;
                }
            } 
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            spriteRenderer.sortingOrder = startSortingOrder;
        }
    }
}