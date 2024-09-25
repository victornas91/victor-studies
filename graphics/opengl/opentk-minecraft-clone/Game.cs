using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace opentk_minecraft_clone
{
    internal class Game : GameWindow
    {


        float[] vertices = 
        {
            0f, 0.5f, 0f, // vertice do topo
            -0.5f, -0.5f, 0f, // vertice da esquerda
            0.5f, -0.5f, 0f // vertice da direita
        };

        int vao;

        int shaderProgram;

        int width;
      
        int height;

        public Game(int width,  int height) : base(GameWindowSettings.Default, NativeWindowSettings.Default) 
        {
            this.width = width;

            this.height = height;
            
            CenterWindow(new Vector2i(width, height));

        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);

            this.width = e.Width;

            this.height = e.Height;
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            vao = GL.GenVertexArray();

            int vbo = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            GL.BindVertexArray(vao);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.EnableVertexArrayAttrib(vao, 0);
                
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.BindVertexArray(0);
        }

        protected override void OnUnload()
        
        {
            base.OnUnload(); 
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.ClearColor(0.6f, 0.3f, 1f, 1f);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            Context.SwapBuffers();

            base.OnRenderFrame(args);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }
    }
}
