using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody _rb;
    private Animator _anim;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _dir;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if (_rb != null) _rb.freezeRotation = true;
    }

    private void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0)) return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _dir = new Vector3(h, 0f, v).normalized;

        // Mise à jour de l'état "IsMoving"
        bool isMoving = _dir != Vector3.zero;
        _anim.SetBool("IsMoving", isMoving);

        if (isMoving)
        {
            _anim.SetFloat("MoveX", h);
            _anim.SetFloat("MoveY", v);
            
            // Inversion visuelle pour la droite
            if (h != 0) _spriteRenderer.flipX = h > 0;
            
            // On s'assure que l'animation joue à vitesse normale
            _anim.speed = 1f;
        }
        else
        {
            // Astuce : On fige l'animation sur la dernière image de marche
            _anim.speed = 0f; 
        }
    }

    private void FixedUpdate()
    {
        if (_rb != null && _dir != Vector3.zero)
            _rb.MovePosition(transform.position + _dir * (speed * Time.fixedDeltaTime));
    }
}