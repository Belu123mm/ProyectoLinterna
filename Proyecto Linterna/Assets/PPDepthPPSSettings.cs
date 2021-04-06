// Amplify Shader Editor - Visual Shader Editing Tool
// Copyright (c) Amplify Creations, Lda <info@amplify.pt>
#if UNITY_POST_PROCESSING_STACK_V2
using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PPDepthPPSRenderer), PostProcessEvent.AfterStack, "PPDepth", true)]
public sealed class PPDepthPPSSettings : PostProcessEffectSettings
{
    [Tooltip("Radius")]
    public FloatParameter _Radius = new FloatParameter { value = 6f };
    [Tooltip("FallOff")]
    public FloatParameter _FallOff = new FloatParameter { value = 1f };
    [Tooltip("Fog Color")]
    public ColorParameter _FogColor = new ColorParameter { value = new Color(1, 1, 1, 0f) };
}

public sealed class PPDepthPPSRenderer : PostProcessEffectRenderer<PPDepthPPSSettings>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Clase11/PP Depth"));
        sheet.properties.SetFloat("_Radius", settings._Radius);
        sheet.properties.SetFloat("_FallOff", settings._FallOff);
        sheet.properties.SetColor("_FogColor", settings._FogColor);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}
#endif
