using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraOnPlayer : MonoBehaviour
{
    public Transform target; // Ссылка на объект игрока
    public float smoothSpeed = 0.125f; // Скорость плавного следования к цели
    public Vector2 offset; // Смещение камеры относительно цели

    void Update()
    {
        // Рассчитываем позицию, к которой должна двигаться камера
        Vector3 desiredPosition = target.position.ConvertTo<Vector2>() + offset;
        Vector3 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        smoothedPosition.z = -10;

        // Обновляем позицию камеры
        transform.position = smoothedPosition;
    }
}
