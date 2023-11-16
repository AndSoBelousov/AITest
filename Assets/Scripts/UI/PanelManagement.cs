using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class PanelManagement : MonoBehaviour, IPointerDownHandler
{
    private RectTransform panelTransform; // ������ �� ��������� RectTransform ������
    private Vector2 initialPosition; // �������� ������� ������
    private Vector2 targetPosition;
    private Vector2 startLocation;

    private bool isMoving = false; // ���� ��� ������������ ��������� �����������
    [SerializeField]
    private GameObject _panel;

    public Vector2 moveDistance = new Vector2(0, -100); // ����������, �� ������� ����� ����������� ������

    private void Start()
    {
        panelTransform = _panel.GetComponent<RectTransform>(); // �������� ��������� RectTransform ������
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
        float duration = 1.0f; // ������������ �������� � �������� (������� �������� ��������)

        float elapsedTime = 0f;
        startLocation = panelTransform.anchoredPosition;
        // ������� ����������� ������ �� �������� ������� � �������
        while (elapsedTime < duration)
        {
            // ������������ ����� �������� � ������� �������� � ������ �������
            panelTransform.anchoredPosition = Vector2.Lerp(startLocation, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime; // ����������� ��������� �����
            yield return null; // ��������� � ���������� �����
        }

        panelTransform.anchoredPosition = targetPosition; // ������������� ������������� ������� ������
        isMoving = false; // ���������� ���� ����������� � false
    }

}
