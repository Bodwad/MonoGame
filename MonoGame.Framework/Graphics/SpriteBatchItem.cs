using System;

namespace Microsoft.Xna.Framework.Graphics
{
	internal class SpriteBatchItem
	{
		public Texture2D Texture;
		public float Depth;

#if DIRECTX || OPENGL
        public VertexPositionColorTexture vertexTL;
        public VertexPositionColorTexture vertexTR;
        public VertexPositionColorTexture vertexBL;
        public VertexPositionColorTexture vertexBR;
#elif PSS
        public VertexPosition2ColorTexture vertexTL;
		public VertexPosition2ColorTexture vertexTR;
		public VertexPosition2ColorTexture vertexBL;
		public VertexPosition2ColorTexture vertexBR;
#endif
		public SpriteBatchItem ()
		{
#if DIRECTX || OPENGL
            vertexTL = new VertexPositionColorTexture();
            vertexTR = new VertexPositionColorTexture();
            vertexBL = new VertexPositionColorTexture();
            vertexBR = new VertexPositionColorTexture();   
#elif PSS
			vertexTL = new VertexPosition2ColorTexture();
            vertexTR = new VertexPosition2ColorTexture();
            vertexBL = new VertexPosition2ColorTexture();
            vertexBR = new VertexPosition2ColorTexture();            
#endif
		}
		
		public void Set ( float x, float y, float w, float h, Color color, Vector2 texCoordTL, Vector2 texCoordBR )
		{
			vertexTL.Position.X = x;
            vertexTL.Position.Y = y;
#if DIRECTX || OPENGL
			vertexTL.Color = color;
#elif PSS
            vertexTL.Color = color.PackedValue;
#endif
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;

			vertexTR.Position.X = x+w;
            vertexTR.Position.Y = y;
#if DIRECTX || OPENGL
            vertexTR.Color = color;
#elif PSS
            vertexTR.Color = color.PackedValue;
#endif
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

			vertexBL.Position.X = x;
            vertexBL.Position.Y = y+h;
#if DIRECTX || OPENGL
            vertexBL.Color = color;
#elif PSS
            vertexBL.Color = color.PackedValue;
#endif
			vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

			vertexBR.Position.X = x+w;
            vertexBR.Position.Y = y+h;
#if DIRECTX || OPENGL
            vertexBR.Color = color;
#elif PSS
            vertexBR.Color = color.PackedValue;
#endif
			vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
		}

		public void Set ( float x, float y, float dx, float dy, float w, float h, float sin, float cos, Color color, Vector2 texCoordTL, Vector2 texCoordBR )
		{
			vertexTL.Position.X = x+dx*cos-dy*sin;
            vertexTL.Position.Y = y+dx*sin+dy*cos;
#if DIRECTX || OPENGL
            vertexTL.Color = color;
#elif PSS
            vertexTL.Color = color.PackedValue;
#endif
            vertexTL.TextureCoordinate.X = texCoordTL.X;
            vertexTL.TextureCoordinate.Y = texCoordTL.Y;

			vertexTR.Position.X = x+(dx+w)*cos-dy*sin;
            vertexTR.Position.Y = y+(dx+w)*sin+dy*cos;
#if DIRECTX || OPENGL
            vertexTR.Color = color;
#elif PSS
            vertexTR.Color = color.PackedValue;
#endif
            vertexTR.TextureCoordinate.X = texCoordBR.X;
            vertexTR.TextureCoordinate.Y = texCoordTL.Y;

			vertexBL.Position.X = x+dx*cos-(dy+h)*sin;
            vertexBL.Position.Y = y+dx*sin+(dy+h)*cos;
#if DIRECTX || OPENGL
            vertexBL.Color = color;
#elif PSS
            vertexBL.Color = color.PackedValue;
#endif
            vertexBL.TextureCoordinate.X = texCoordTL.X;
            vertexBL.TextureCoordinate.Y = texCoordBR.Y;

			vertexBR.Position.X = x+(dx+w)*cos-(dy+h)*sin;
            vertexBR.Position.Y = y+(dx+w)*sin+(dy+h)*cos;
#if DIRECTX || OPENGL
            vertexBR.Color = color;
#elif PSS
            vertexBR.Color = color.PackedValue;
#endif
            vertexBR.TextureCoordinate.X = texCoordBR.X;
            vertexBR.TextureCoordinate.Y = texCoordBR.Y;
		}
	}
}

