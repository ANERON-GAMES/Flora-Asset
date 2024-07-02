using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class KeepFrameFeature : ScriptableRendererFeature
{
    class CopyFramePass : ScriptableRenderPass
    {
        private RenderTargetIdentifier m_Source;
        private RTHandle m_Destination;
        public void Setup(RenderTargetIdentifier source, RTHandle destination)
        {
            m_Source = source;
            m_Destination = destination;
        }
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (renderingData.cameraData.camera.cameraType != CameraType.Game)
                return;

            CommandBuffer cmd = CommandBufferPool.Get("CopyFramePass");

            string destinationIdentifier = m_Destination.name; 

            cmd.Blit(m_Source, destinationIdentifier);
            context.ExecuteCommandBuffer(cmd);

            CommandBufferPool.Release(cmd);
        }
        public override void OnCameraCleanup(CommandBuffer cmd)
        {
            cmd.ReleaseTemporaryRT(m_Destination.GetInstanceID());
        }
    }
    class DrawOldFramePass : ScriptableRenderPass
    {
        private Material m_DrawOldFrameMaterial;
        private RTHandle m_Handle;
        private string m_TextureName;
        public void Setup(Material drawOldFrameMaterial, RTHandle handle, string textureName)
        {
            m_DrawOldFrameMaterial = drawOldFrameMaterial;
            m_Handle = handle;
            m_TextureName = textureName;
        }
        public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
        {
            RenderTextureDescriptor descriptor = cameraTextureDescriptor;
            descriptor.msaaSamples = 1;
            descriptor.depthBufferBits = 0;
            cmd.GetTemporaryRT(m_Handle.GetInstanceID(), descriptor, FilterMode.Bilinear);
        }
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            if (m_DrawOldFrameMaterial != null)
            {
                CommandBuffer cmd = CommandBufferPool.Get("DrawOldFramePass");
                cmd.SetGlobalTexture(m_TextureName, m_Handle.GetInstanceID());
                cmd.SetViewProjectionMatrices(Matrix4x4.identity, Matrix4x4.identity);
                cmd.DrawMesh(RenderingUtils.fullscreenMesh, Matrix4x4.identity, m_DrawOldFrameMaterial, 0, 0);
                cmd.SetViewProjectionMatrices(renderingData.cameraData.camera.worldToCameraMatrix, renderingData.cameraData.camera.projectionMatrix);
                context.ExecuteCommandBuffer(cmd);
                CommandBufferPool.Release(cmd);
            }
        }
    }
    [Serializable]
    public class Settings
    {
        public Material displayMaterial;
        public string textureName;
    }
    private CopyFramePass m_CopyFrame;
    private DrawOldFramePass m_DrawOldFrame;
    private RTHandle m_OldFrameHandle;
    public Settings settings = new Settings();
    public override void Create()
    {
        m_CopyFrame = new CopyFramePass
        {
            renderPassEvent = RenderPassEvent.AfterRenderingTransparents
        };

        m_DrawOldFrame = new DrawOldFramePass
        {
            renderPassEvent = RenderPassEvent.BeforeRenderingOpaques
        };
    }
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(m_DrawOldFrame);
    }
}