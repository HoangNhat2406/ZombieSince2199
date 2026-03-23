using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorNormal; // Sửa lỗi chính tả Nomal -> Normal
    [SerializeField] private Texture2D cursorShoot;
    [SerializeField] private Texture2D cursorReload;

    // Hotspot nên là tâm của đầu ruồi súng (Crosshair)
    // Nếu ảnh là 32x32, tâm sẽ là (16, 16)
    [SerializeField] private Vector2 hotspot = new Vector2(16, 16);

    void Start()
    {
        SetCustomCursor(cursorNormal);
    }

    void Update()
    {
        // Sử dụng GetMouseButton thay vì Down/Up nếu bạn muốn logic chặt chẽ hơn
        if (Input.GetMouseButtonDown(0))
        {
            SetCustomCursor(cursorShoot);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            SetCustomCursor(cursorNormal);
        }

        if (Input.GetMouseButtonDown(1))
        {
            SetCustomCursor(cursorReload);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            SetCustomCursor(cursorNormal);
        }
    }

    private void SetCustomCursor(Texture2D tex)
    {
        if (tex != null)
        {
            // Dùng CursorMode.Auto hoặc ForceSoftware nếu trên Linux gặp lỗi hiển thị
            Cursor.SetCursor(tex, hotspot, CursorMode.Auto);
        }
    }
}