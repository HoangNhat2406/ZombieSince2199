using UnityEngine;

public class EnergyEnemy : Enemy
{
    // 1. Sửa chữ S viết hoa
    [SerializeField] private GameObject energyObject;
    
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
        // Kiểm tra energyObject trước khi Instantiate
        if (energyObject != null)
        {
            GameObject energy = Instantiate(energyObject, transform.position, Quaternion.identity);
            Destroy(energy, 5f);
        }
        
        // Gọi base.Die() để thực hiện các logic chết ở class cha (như cộng điểm, xóa quái)
        base.Die();
    }
}