using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShader : MonoBehaviour
{
    public Material ShaderTexture;
    private void OnRenderImage(RenderTexture cameraView, RenderTexture shaderView)
    {
        Graphics.Blit(cameraView, shaderView, ShaderTexture);
    }
}
