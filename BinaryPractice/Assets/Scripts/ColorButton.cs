using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    private Light2D globalLight;
    private Camera cam;

    public void ChooseTextColor()
    {
        globalLight = FindFirstObjectByType<Light2D>();
        globalLight.color = GetComponent<Image>().color;
    }
    public void ChooseBackgroundColor()
    {
        cam = Camera.main;
        cam.backgroundColor = GetComponent<Image>().color;
    }
}
