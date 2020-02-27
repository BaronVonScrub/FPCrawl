Shader "Custom/GridShader"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_BumpMap("Normal", 2D) = "bump" {}
		_NormalStrength("Normal Strength",Float) = 1.0
		_GridSpacing("Grid spacing", float) = 5
		_GridThickness("Grid line thickness", float) = 0.1
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma surface surf Standard fullforwardshadows

			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0

			sampler2D _MainTex;
			sampler2D _BumpMap;

			struct Input
			{
				float2 uv_MainTex;
				float3 worldPos;
			};

			half _Glossiness;
			half _Metallic;
			fixed4 _Color;
			float _GridSpacing;
			float _GridThickness;
			float _NormalStrength;

			// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
			// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
			// #pragma instancing_options assumeuniformscaling
			UNITY_INSTANCING_BUFFER_START(Props)
				// put more per-instance properties here
			UNITY_INSTANCING_BUFFER_END(Props)

			float NFMod(float a, float b) {
				return a - b * floor(a / b);
			}

			void surf(Input IN, inout SurfaceOutputStandard o)
			{
				//Grid stuff
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = c.rgb;
				float isGrid = max(sign(_GridThickness - (NFMod(IN.worldPos.x,_GridSpacing))), 0);
				isGrid += max(sign(_GridThickness - (NFMod(IN.worldPos.z, _GridSpacing))), 0);
				isGrid = min(1, isGrid);
				o.Albedo *= max(1, 2 * isGrid);

				//Normal stuff
				o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));
				o.Normal.xy *= _NormalStrength;

				// Metallic and smoothness come from slider variables
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Alpha = c.a;
			}
			ENDCG
		}
			FallBack "Diffuse"
}