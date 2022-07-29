using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera = default;
    private CinemachineBasicMultiChannelPerlin _cineMachineNoise;
    private float _noiseAmplitude;
    private float _noiseFrequency;

    private void Awake()
    {
        _cineMachineNoise = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cineMachineNoise.m_AmplitudeGain = 0;
        _cineMachineNoise.m_FrequencyGain = 0;
    }

    public void CreateShake(CameraShakeValues cameraShakeValues)
    {
        _noiseAmplitude = cameraShakeValues.NoiseAmplitude;
        _noiseFrequency = cameraShakeValues.NoiseFrequency;
    }

    private void Update()
    {
        if (_noiseAmplitude > 0)
        {
            _cineMachineNoise.m_AmplitudeGain = _noiseAmplitude;
            _noiseAmplitude -= Time.deltaTime;
        }
        else
        {
            _cineMachineNoise.m_AmplitudeGain = 0;
        }

        if (_noiseFrequency > 0)
        {
            _cineMachineNoise.m_FrequencyGain = _noiseFrequency;
            _noiseFrequency -= Time.deltaTime;
        }
        else
        {
            _cineMachineNoise.m_FrequencyGain = 0;
        }
    }
}
