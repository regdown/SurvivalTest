```csharp
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingSetup : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    public PostProcessProfile postProcessProfile;

    void Start()
    {
        SetupPostProcessing();
        SetupFog();
        CreateDirectionalLightIfMissing();
        EnableAntiAliasing();
    }

    private void SetupPostProcessing()
    {
        postProcessVolume = gameObject.AddComponent<PostProcessVolume>();
        postProcessProfile = ScriptableObject.CreateInstance<PostProcessProfile>();

        // Bloom
        var bloom = postProcessProfile.AddSettings<Bloom>();
        bloom.intensity.overrideState = true;
        bloom.intensity.value = 5.0f;

        // Ambient Occlusion
        var ambientOcclusion = postProcessProfile.AddSettings<AmbientOcclusion>();
        ambientOcclusion.intensity.overrideState = true;
        ambientOcclusion.intensity.value = 1.0f;

        // Vignette
        var vignette = postProcessProfile.AddSettings<Vignette>();
        vignette.intensity.overrideState = true;
        vignette.intensity.value = 0.45f;

        postProcessVolume.sharedProfile = postProcessProfile;
        postProcessVolume.isGlobal = true;
    }

    private void SetupFog()
    {
        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        RenderSettings.fogDensity = 0.01f;
        RenderSettings.fogColor = Color.gray;
    }

    private void CreateDirectionalLightIfMissing()
    {
        if (FindObjectOfType<Light>() == null)
        {
            GameObject lightGameObject = new GameObject("Directional Light");
            Light lightComp = lightGameObject.AddComponent<Light>();
            lightComp.type = LightType.Directional;
            lightComp.intensity = 1f;
        }
    }

    private void EnableAntiAliasing()
    {
        QualitySettings.antiAliasing = 4;
    }
}
```