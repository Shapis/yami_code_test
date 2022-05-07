using System;
using UnityEngine;
using System.Linq;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject[] m_Players;
    Vector2 screenBounds;
    Vector2 screenOrigin;

    private float _gameObjectSize = 1f;

    private void Update()
    {
        UpdateScreenBounds();
        AdjustCamera();
    }

    private void UpdateScreenBounds()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        screenOrigin = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }

    private bool IsOutOfBounds(Vector3 pos)
    {
        bool _isOutOfBounds = false;

        if ((pos.x + (_gameObjectSize / 2)) > screenBounds.x || (pos.x - (_gameObjectSize / 2)) < screenOrigin.x)
        {
            _isOutOfBounds = true;
        }
        else if (pos.y + (_gameObjectSize / 2) > screenBounds.y || pos.y - ((_gameObjectSize / 2)) < screenOrigin.y)
        {
            _isOutOfBounds = true;
        }
        return _isOutOfBounds;
    }

    private void AdjustCamera()
    {
        if (IsTheFarthestObjectOutOfBounds())
        {
            while (IsTheFarthestObjectOutOfBounds())
            {
                Camera.main.orthographicSize += 0.001f;
                UpdateScreenBounds();
            }
        }
        else if (Camera.main.orthographicSize > 5f)
        {
            while (!IsTheFarthestObjectOutOfBounds())
            {
                Camera.main.orthographicSize -= 0.001f;
                UpdateScreenBounds();
            }
            Camera.main.orthographicSize += 0.001f;
        }
        else if (Camera.main.orthographicSize < 5f)
        {
            Camera.main.orthographicSize = 5f;
        }
    }

    private bool IsTheFarthestObjectOutOfBounds()
    {
        float _maxX = m_Players.Max(x => x.transform.position.x);
        float _minX = m_Players.Min(x => x.transform.position.x);
        float _maxY = m_Players.Max(y => y.transform.position.y);
        float _minY = m_Players.Min(y => y.transform.position.y);
        return IsOutOfBounds(new Vector3(_maxX, _maxY, 0)) || IsOutOfBounds(new Vector3(_minX, _minY, 0));
    }
}