using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] private float maxHP = 100f;
    private float currentHP; 
    [SerializeField] private Image hpBar;
    [SerializeField] private LoseMenu loseMenu;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        currentHP = maxHP;
        UpdateHpBar();
    }
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 playerInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        rb.linearVelocity = playerInput.normalized * moveSpeed;
        if (playerInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (playerInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (playerInput != Vector2.zero)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }
    public void TakeDamage( float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Max(currentHP, 0);
        UpdateHpBar();
        if(currentHP <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        if (loseMenu != null)
        {
            loseMenu.ShowLoseMenu(); 
        }
        gameObject.SetActive(false);
    }
    private void UpdateHpBar()
    {
        if(hpBar != null)
        {
            hpBar.fillAmount = currentHP / maxHP;
        }
    }

    public void Heal(float healAmount)
    {
        if( currentHP < maxHP)
        {
            currentHP += healAmount;
            currentHP = Mathf.Min(currentHP, maxHP);
            UpdateHpBar();
        }
    }
}