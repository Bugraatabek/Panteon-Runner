using UnityEngine;

namespace Runner.Obstacles
{
    public class ShiningObstacle : MonoBehaviour, ISpecialObstacle
    {
        [SerializeField] ParticleSystemRenderer particleSystemRenderer; // Reference to the ParticleSystemRenderer component
        private Color[] colors = new Color[4]; // Array to store the available colors
        private int _currentColorIndex; // Current color index

        private void Awake() 
        {
            _currentColorIndex = 0; // Initialize the color index to 0
            colors[0] = Color.yellow; // Set the first color to yellow
            colors[1] = Color.blue; // Set the second color to blue
            colors[2] = Color.red; // Set the third color to red
            colors[3] = Color.cyan; // Set the fourth color to cyan
        }

        //ISpecialObstacle
        public void OnCollision(Rigidbody competitorRB, Vector3 contactPoint)
        {
            Color randomColor = colors[_currentColorIndex]; // Get the color based on the current color index
            particleSystemRenderer.material.color = randomColor; // Set the color of the particle system's material
            _currentColorIndex += 1; // Increment the color index
            if (_currentColorIndex == colors.Length) 
            {
                _currentColorIndex = 0; // Reset the color index to 0 if it reaches the end of the colors array
            }
        }
    }
}
