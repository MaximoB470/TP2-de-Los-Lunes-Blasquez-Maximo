using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody2D rb;
    private SpriteRenderer sp;
    public Camera cam;
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRadius;
    [SerializeField] private LayerMask interactionLayer;
    public GameObject Weapon;

    public Transform weaPoint;
    private GameObject currentWeapon;

    Vector2 movimiento;
    Vector2 posMouse;

    private Collider2D[] interactables = new Collider2D[4];

    private HealthHandler healthHandler;

    public int points = 0;

    private bool canDash = true;
    private bool isDashing;
    public bool ApplyDash = false;
    private float dashPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    public int HPTracker;
    [SerializeField] private TrailRenderer tr;
     private GameManager gameManager;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
       EquipWeapon(Weapon);

        healthHandler = gameObject.AddComponent<HealthHandler>();
        healthHandler.maxHp = 5; 
        healthHandler.Awake();

        HPTracker = healthHandler.Life;
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }

    }
    private void Update()
    {
        HPTracker = healthHandler.Life;
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");

        posMouse = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }

        if (ApplyDash  && Input.GetKeyDown(KeyCode.Space) && canDash && !isDashing)
        {
            StartCoroutine(Dash());
        }

        if(healthHandler.Life <= 0) 
        {
            HandleDeath();
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            HandlePause();
        }

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movimiento * speed * Time.fixedDeltaTime);

        Vector2 Dir = posMouse - rb.position;
        float angulo = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angulo;
    }

    private void TryInteract()
    {
        Debug.Log("tried inteaction");
        int elements = Physics2D.OverlapCircleNonAlloc(interactionPoint.position, interactionRadius, interactables, interactionLayer);
        if (elements == 0)
        {
            Debug.Log("No interactables found");
            return;
        }

        for (int i = 0; i < elements; i++)
        {
            var interactable = interactables[i];
            var interactableComponent = interactable.GetComponent<Iinteractable>();
            if (interactableComponent != null)
            {
                interactableComponent.interaction();
            }
        }
    }
    public void EquipWeapon(GameObject weapon)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon); 
        }
        currentWeapon = Instantiate(weapon, weaPoint.position, weaPoint.rotation, weaPoint);
    }
    private IEnumerator Dash()
    {
        canDash = false; 
        isDashing = true;

        
        Vector2 dashDirection = movimiento.normalized;

       
        Vector2 originalVelocity = rb.velocity;

        
        rb.velocity = dashDirection * dashPower;

        
        tr.emitting = true;

        
        yield return new WaitForSeconds(dashingTime);

        
        rb.velocity = originalVelocity;
        tr.emitting = false;

        isDashing = false; 

       
        yield return new WaitForSeconds(dashingCooldown);

        canDash = true; 
    }

    public void UnlockDash()
    {
        ApplyDash = true;
        Debug.Log("Dash unlocked!");
    }

    private void HandlePause() 
    {
        gameManager.ChangeState(new PausedState(gameManager));
    }

    private void HandleDeath()
    {
        gameManager.ChangeState(new DefeatState(gameManager));
    }

}
