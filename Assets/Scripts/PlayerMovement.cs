using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 180f;

    private PlayerInput playerInput;

    private Rigidbody playerRigidbody;
    private Animator playerAnimator;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Rotate();
        Move();

        // �Է°��� ���� �ִϸ������� Move �Ķ���Ͱ� ����
        playerAnimator.SetFloat("Move", playerInput.move);
    }

    private void Move()
    {
        // ��������� �̉��� �Ÿ� ���
        Vector3 moveDistance = 
            playerInput.move * transform.forward * moveSpeed * Time.deltaTime;

        // ������ٵ� �̿��� ���� ������Ʈ ��ġ ����
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }

    private void Rotate()
    {
        // ��������� ȸ���� ��ġ ���
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;

        // ������ٵ� �̿��� ���� ������Ʈ ȸ�� ����
        playerRigidbody.rotation =
            playerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);
    }
}
