using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PanelManagement : MonoBehaviour, IPointerDownHandler
{
    private RectTransform panelTransform; // ������ �� ��������� RectTransform ������
    private Vector2 initialPosition; // �������� ������� ������
    private Vector2 targetPosition;

    private bool isMoving = false; // ���� ��� ������������ ��������� �����������
    private bool panelOriginalPosition = true;

    public Vector2 moveDistance = new Vector2(0, -100); // ����������, �� ������� ����� ����������� ������

    private void Start()
    {
        panelTransform = GetComponent<RectTransform>(); // �������� ��������� RectTransform ������
        initialPosition = panelTransform.anchoredPosition; // ���������� �������� ������� ������
    }

    // ����� ���������� ��� ������� �� ������
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isMoving) // ���������, ��� ������ �� ������������ � ������ ������
        {
            StartCoroutine(MovePanelSmoothly()); // ��������� �������� ��� �������� �����������
        }
    }

    private IEnumerator MovePanelSmoothly()
    {
        isMoving = true; // ������������� ���� ����������� � true
        targetPosition = panelTransform.anchoredPosition == initialPosition ? initialPosition + moveDistance : initialPosition;
        //targetPosition = initialPosition + moveDistance; // ��������� ������� �������
        float duration = 1.0f; // ������������ �������� � �������� (������� �������� ��������)

        float elapsedTime = 0f;

        // ������� ����������� ������ �� �������� ������� � �������
        while (elapsedTime < duration)
        {
            // ������������ ����� �������� � ������� �������� � ������ �������
            panelTransform.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime; // ����������� ��������� �����
            yield return null; // ��������� � ���������� �����
        }

        panelTransform.anchoredPosition = targetPosition; // ������������� ������������� ������� ������
        panelOriginalPosition = false;
        isMoving = false; // ���������� ���� ����������� � false
    }

}
