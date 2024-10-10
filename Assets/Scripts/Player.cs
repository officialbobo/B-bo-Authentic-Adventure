using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度
    public float jumpForce = 10f; // ジャンプの力
    public Transform groundCheck; // 地面判定用のトランスフォーム
    public LayerMask groundLayer; // 地面を表すレイヤーマスク

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 水平方向の入力を取得
        float moveInput = Input.GetAxis("Horizontal");

        // プレイヤーを左右に移動
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // ジャンプ処理
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
