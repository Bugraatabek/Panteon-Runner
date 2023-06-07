using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Runner.Control
{
    public class BrushController : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask; // Layer mask for raycasting
        [SerializeField] private Color _brushColor = Color.blue; // Color of the brush
        [SerializeField] private float _brushSize = 0; // Size of the brush
        [SerializeField] private bool _paintingPhase = false; // Flag to determine if it's the painting phase
        [SerializeField] Slider _mainSlider; // Reference to the brush size slider

        private void OnEnable() 
        {
            // Subscribe to the painting phase event
            Singleton.Instance.PhaseManager.onPaintingPhaseStart += StartPainting;
        }

        private void OnDisable() 
        {
            // Unsubscribe to the painting phase event
            Singleton.Instance.PhaseManager.onPaintingPhaseStart -= StartPainting;    
        }

        private void FixedUpdate() 
        {
            if (!_paintingPhase) return; // If it's not the painting phase, exit the method

            RaycastHit[] hits;
            Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (_mainSlider != null)
            {
                _brushSize = _mainSlider.value; // Update the brush size based on the slider value
            }

            hits = Physics.SphereCastAll(mousePosition, _brushSize, 50f, _layerMask); // Perform a spherecast

            foreach (RaycastHit hit in hits)
            {
                var paintable = hit.transform.GetComponent<IPaintable>();
                if (paintable != null)
                {
                    if (Input.GetMouseButton(0))
                    {
                        if (!paintable.IHaveBeenPainted()) // if paintable has been painted don't do anything
                        {
                            paintable.PaintMe(_brushColor); // Paint the object with the brush color
                        }
                    }
                }
            }
        }

        private void StartPainting()
        {
            _paintingPhase = true; // Enable the painting phase
        }
        
        public void SetBrushColor(string colorName)
        {
            if (colorName == "Yellow")
            {
                _brushColor = Color.yellow; // Set the brush color to yellow
            }
            if (colorName == "Red")
            {
                _brushColor = Color.red; // Set the brush color to red
            }
            if (colorName == "Blue")
            {
                _brushColor = Color.blue; // Set the brush color to blue
            }
        } 
    }
}
