
using UnityEngine;
using UnityEngine.UI;

public class androidmovescript : MonoBehaviour
{
    [Header("Camera")]
    public Camera targetCamera;

    [Header("Map Limits")]
    public float bottomY = -10f;
    public float topY = 10f;

    [Header("PC Controls")]
    public float scrollSpeed = 2f;

    [Header("Mobile Controls")]
    public Slider cameraSlider;

    void Start()
    {
        if (targetCamera == null)
            targetCamera = Camera.main;

        if (cameraSlider != null)
        {
            cameraSlider.minValue = 0f;
            cameraSlider.maxValue = 1f;

            UpdateSlider();
        }
    }

    void Update()
    {
        float scroll = Input.mouseScrollDelta.y;

        if (scroll != 0f)
        {
            float newY = targetCamera.transform.position.y
                         + scroll * scrollSpeed;

            SetCameraY(newY);
            UpdateSlider();
        }
    }

    public void OnSliderChanged(float value)
    {
        float newY = Mathf.Lerp(bottomY, topY, value);

        SetCameraY(newY);
    }

    void SetCameraY(float y)
    {
        Vector3 position = targetCamera.transform.position;

        position.y = Mathf.Clamp(y, bottomY, topY);

        targetCamera.transform.position = position;
    }

    void UpdateSlider()
    {
        if (cameraSlider == null)
            return;

        float y = targetCamera.transform.position.y;

        float value = Mathf.InverseLerp(bottomY, topY, y);

        cameraSlider.SetValueWithoutNotify(value);
    }
}
