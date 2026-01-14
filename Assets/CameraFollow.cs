using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Cible à suivre (votre objet Player)
    [SerializeField] private Transform target;
    
    // Décalage entre la caméra et le joueur
    [SerializeField] private Vector3 offset = new Vector3(0f, 10f, -10f);
    
    // Vitesse de lissage du mouvement
    [SerializeField] private float smoothSpeed = 0.125f;

    private void LateUpdate()
    {
        if (target == null) return;

        // Calcul de la position souhaitée en fonction de la position du Player
        Vector3 desiredPosition = target.position + offset;
        
        // Interpolation fluide entre la position actuelle et la cible
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Mise à jour de la position de la caméra
        transform.position = smoothedPosition;
    }
}