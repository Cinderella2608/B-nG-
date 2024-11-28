using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public float Speed;
    private float MvInput;
    private bool IsFacingRight = true;

    public Rigidbody2D rg;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MvInput = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector2.right * MvInput * Speed * Time.deltaTime);

        if (MvInput > 0 && !IsFacingRight)
        {
            Flip();
        }
        else if (MvInput < 0 && IsFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 Scale = transform.localScale; // Lấy scale hiện tại
        Scale.x *= -1; // Đảo chiều x
        transform.localScale = Scale; // Áp dụng scale mới
    }
}
