using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerformanceMode : MonoBehaviour
{
    //Written by Edwin Aguirre
    //Changes the game's material to an unlit shader and should give better results for performance

    [SerializeField]
    private Material highlightMaterial;
    [SerializeField]
    private Material defaultMaterial;

    [SerializeField]
    private Toggle toggle;

    private Shader standardShader;
    private Shader unlitShader;
    private Shader mobileShader;

    // Start is called before the first frame update
    void Start()
    {
        standardShader = Shader.Find("Standard");
        unlitShader = Shader.Find("Unlit/Texture");
        mobileShader = Shader.Find("Mobile/Diffuse");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePerformanceMode()
    {
        if(toggle.isOn == true)
        {
            highlightMaterial.shader = unlitShader;
            defaultMaterial.shader = unlitShader;
        }
        else if(toggle.isOn == false)
        {
            highlightMaterial.shader = mobileShader;
            defaultMaterial.shader = standardShader;
        }
    }
}
