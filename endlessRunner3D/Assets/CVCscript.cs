using UnityEngine;
using Cinemachine;

public class LockCameraZ : CinemachineExtension
{
    [Tooltip("Lock the camera's Z position to this value")]
    public float m_ZPosition = -14f;
    public float m_YPosition = 7.5f;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.z = m_ZPosition;
            state.RawPosition = pos;
        }
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.y = m_YPosition;
            state.RawPosition = pos;
        }
    }
}
