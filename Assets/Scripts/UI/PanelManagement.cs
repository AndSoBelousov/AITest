using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class PanelManagement : MonoBehaviour, IPointerDownHandler
{
    private RectTransform panelTransform; // Ссылка на компонент RectTransform панели
    private Vector2 initialPosition; // Исходная позиция панели
    private Vector2 targetPosition;
    private Vector2 startLocation;

    private bool isMoving = false; // Флаг для отслеживания состояния перемещения
    [SerializeField]
    private GameObject _panel;

    public Vector2 moveDistance = new Vector2(0, -100); // Расстояние, на которое нужно переместить панель

    private void Start()
    {
        panelTransform = _panel.GetComponent<RectTransform>(); // Получаем компонент RectTransform панели
        initialPosition = panelTransform.anchoredPosition; // Запоминаем исходную позицию панели
    }

    
    // Метод вызывается при нажатии на панель
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isMoving) // Проверяем, что панель не перемещается в данный момент
        {
            StartCoroutine(MovePanelSmoothly()); // Запускаем корутину для плавного перемещения
        }
    }

    private IEnumerator MovePanelSmoothly()
    {
        isMoving = true; // Устанавливаем флаг перемещения в true
        targetPosition = panelTransform.anchoredPosition == initialPosition ? initialPosition + moveDistance : initialPosition;
        float duration = 1.0f; // Длительность анимации в секундах (задайте желаемое значение)

        float elapsedTime = 0f;
        startLocation = panelTransform.anchoredPosition;
        // Плавное перемещение панели от исходной позиции к целевой
        while (elapsedTime < duration)
        {
            // Интерполяция между исходной и целевой позицией с учетом времени
            panelTransform.anchoredPosition = Vector2.Lerp(startLocation, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime; // Увеличиваем прошедшее время
            yield return null; // Переходим к следующему кадру
        }

        panelTransform.anchoredPosition = targetPosition; // Устанавливаем окончательную позицию панели
        isMoving = false; // Сбрасываем флаг перемещения в false
    }

}
