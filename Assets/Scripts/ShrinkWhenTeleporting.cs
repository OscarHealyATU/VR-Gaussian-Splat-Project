// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;

// **
// public class EnvironmentShrinkOnTeleport : MonoBehaviour
// {
//     [Header("References")]
//     [Tooltip("The teleportation provider component")]
//     public TeleportationProvider teleportProvider;
    
//     [Tooltip("The environment parent object to shrink")]
//     public Transform environmentParent;
    
//     [Header("Shrink Settings")]
//     [Tooltip("Scale multiplier applied each teleport (e.g., 0.9 = 10% smaller)")]
//     [Range(0.1f, 0.99f)]
//     public float shrinkMultiplier = 0.9f;
    
//     [Tooltip("Minimum scale the environment can reach")]
//     [Range(0.01f, 1f)]
//     public float minScale = 0.1f;
    
//     [Tooltip("Duration of the shrink animation in seconds")]
//     public float shrinkDuration = 0.5f;
    
//     [Tooltip("Should the shrink be animated or instant?")]
//     public bool animateShrink = true;
    
//     private Vector3 targetScale;
//     private Vector3 currentScale;
//     private float shrinkProgress = 1f;
    
//     void Start()
//     {
//         // Find teleportation provider if not assigned
//         if (teleportProvider == null)
//         {
//             teleportProvider = FindObjectOfType<TeleportationProvider>();
//         }
        
//         // Subscribe to teleportation events
//         if (teleportProvider != null)
//         {
//             teleportProvider.endLocomotion += OnTeleportComplete;
//         }
//         else
//         {
//             Debug.LogError("TeleportationProvider not found! Please assign it in the inspector.");
//         }
        
//         // Initialize scale
//         if (environmentParent != null)
//         {
//             currentScale = environmentParent.localScale;
//             targetScale = currentScale;
//         }
//         else
//         {
//             Debug.LogError("Environment Parent not assigned! Please assign the environment object to shrink.");
//         }
//     }
    
//     void OnDestroy()
//     {
//         // Unsubscribe from events
//         if (teleportProvider != null)
//         {
//             teleportProvider.endLocomotion -= OnTeleportComplete;
//         }
//     }
    
//     void OnTeleportComplete(LocomotionSystem locomotionSystem)
//     {
//         if (environmentParent == null) return;
        
//         // Calculate new target scale
//         Vector3 newScale = environmentParent.localScale * shrinkMultiplier;
        
//         // Clamp to minimum scale
//         newScale.x = Mathf.Max(newScale.x, minScale);
//         newScale.y = Mathf.Max(newScale.y, minScale);
//         newScale.z = Mathf.Max(newScale.z, minScale);
        
//         // Set target and start animation
//         currentScale = environmentParent.localScale;
//         targetScale = newScale;
//         shrinkProgress = 0f;
        
//         if (!animateShrink)
//         {
//             environmentParent.localScale = targetScale;
//         }
//     }
    
//     void Update()
//     {
//         // Animate the shrink if enabled
//         if (animateShrink && shrinkProgress < 1f)
//         {
//             shrinkProgress += Time.deltaTime / shrinkDuration;
//             shrinkProgress = Mathf.Clamp01(shrinkProgress);
            
//             // Smooth interpolation
//             float t = Mathf.SmoothStep(0f, 1f, shrinkProgress);
//             environmentParent.localScale = Vector3.Lerp(currentScale, targetScale, t);
//         }
//     }
    
//     // Optional: Method to reset environment scale
//     public void ResetScale()
//     {
//         if (environmentParent != null)
//         {
//             environmentParent.localScale = Vector3.one;
//             currentScale = Vector3.one;
//             targetScale = Vector3.one;
//             shrinkProgress = 1f;
//         }
//     }
// }