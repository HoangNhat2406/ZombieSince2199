using UnityEngine;

public class HealEnemy : Enemy
{
    [SerializeField] private float healValue = 20f; // Số máu hồi cho quái khi chết
    
    // Giả sử enterDamage và stayDamage đã có ở class cha (Enemy)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 2. Lấy component Player trực tiếp từ vật va chạm
            Player p = collision.GetComponent<Player>();
            if (p != null)
            {
                p.TakeDamage(enterDamage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player p = collision.GetComponent<Player>();
            if (p != null)
            {
                // Lưu ý: Bạn nên thêm một cooldown timer ở đây 
                // để tránh việc trừ máu liên tục 60 lần/giây.
                p.TakeDamage(stayDamage * Time.deltaTime); 
            }
        }
    }

    protected override void Die()
    {
        // Khi quái chết, nó sẽ hồi máu cho player
       HealPlayer();
        
        // Gọi base.Die() để thực hiện các logic chết ở class cha (như cộng điểm, xóa quái)
        base.Die();
    }

    private void HealPlayer()
    {

        if (player != null)
        {
            player.Heal(healValue);
        }
    }
}