using UnityEngine;
using TMPro;
using System.Diagnostics;

public class FadeTextWhenFar : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Transform coachingCard; // Reference to the coaching card's transform
    public float fadeDistance = 3f; // Distance threshold to start fading
    public float fadeSpeed = 1f; // Speed of fading

    private TextMeshProUGUI textMesh; // Reference to the TextMeshPro component
    private float currentAlpha = 1f; // Current alpha value of the text

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>(); // Get the TextMeshPro component
    }

    void Update()
    {
        // Check if both player and coachingCard references are assigned
        if (player != null && coachingCard != null)
        {
            // Calculate the distance between the player and the coaching card
            float distance = Vector3.Distance(player.position, coachingCard.position);

            // Calculate the target alpha value based on the distance
            float targetAlpha = Mathf.Clamp01(1 - (distance - fadeDistance) / fadeSpeed);

            // Smoothly fade the alpha value
            currentAlpha = Mathf.Lerp(currentAlpha, targetAlpha, Time.deltaTime * fadeSpeed);

            // Set the alpha value of the text
            Color newColor = textMesh.color;
            newColor.a = currentAlpha;
            textMesh.color = newColor;
        }
        else
        {
            UnityEngine.Debug.LogWarning("Player or coaching card reference is not assigned!");
        }
    }
}
