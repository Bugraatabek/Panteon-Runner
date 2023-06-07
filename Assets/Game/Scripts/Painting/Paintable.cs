using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Painting
{
    public class Paintable : MonoBehaviour, IPaintable
    {
        MeshRenderer meshRenderer;
        Color startColor;
        public static event Action onPaint;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>(); // Get the MeshRenderer component
            startColor = meshRenderer.material.color; // Store the initial color of the material
        }


        //IPaintable
        public bool IHaveBeenPainted()
        {
            // Check if the current color of the material is different from the initial color
            return meshRenderer.material.color != startColor;
        }

        public void PaintMe(Color color)
        {
            if (onPaint != null)
            {
                onPaint(); // Invoke the onPaint event
            }
            meshRenderer.material.color = color; // Set the color of the material to the specified color
        }
    }
}
