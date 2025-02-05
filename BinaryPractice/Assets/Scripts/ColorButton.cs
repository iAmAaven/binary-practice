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

        float color_R = globalLight.color.r;
        float color_G = globalLight.color.g;
        float color_B = globalLight.color.b;
        float color_A = globalLight.color.a;

        PlayerPrefs.SetFloat("TextColor_R", color_R);
        PlayerPrefs.SetFloat("TextColor_G", color_G);
        PlayerPrefs.SetFloat("TextColor_B", color_B);
        PlayerPrefs.SetFloat("TextColor_A", color_A);
    }
    public void ChooseBackgroundColor()
    {
        cam = Camera.main;
        cam.backgroundColor = GetComponent<Image>().color;

        float color_R = cam.backgroundColor.r;
        float color_G = cam.backgroundColor.g;
        float color_B = cam.backgroundColor.b;
        float color_A = cam.backgroundColor.a;

        PlayerPrefs.SetFloat("Background_R", color_R);
        PlayerPrefs.SetFloat("Background_G", color_G);
        PlayerPrefs.SetFloat("Background_B", color_B);
        PlayerPrefs.SetFloat("Background_A", color_A);
    }
}
