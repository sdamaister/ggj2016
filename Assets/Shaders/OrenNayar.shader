Shader "Custom/OrenNayar" {
	Properties {
		_Color ("Color", Color) = (1, 1, 1, 1)
		_RimColor ("Rim color", Color) = (1, 1, 1, 1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_BumpTex ("Bump", 2D) = "bump" {}
		_NormalIntensity("Intensity", Range(0,2)) = 1
		_Roughness ("Roughness", float) = 0.0
		_RimPower ("Rim power", Range(0.1, 3)) = 2
	}

	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Oren_Nayar
		#pragma target 3.0

		float _Roughness;

		inline float4 LightingOren_Nayar(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
		{
			float roughness = _Roughness;
			float roughnessSq = roughness * roughness;

			float2 oren_nayar_fraction = roughnessSq / (roughnessSq + float2(0.33, 0.09));
			float2 oren_nayar = float2(1.0, 0.0) + float2(-0.5, 0.45) * oren_nayar_fraction;

			float NdotL = dot(s.Normal, lightDir);
			float NdotV = dot(s.Normal, viewDir);

			float2 cos_theta = saturate(float2(NdotL, NdotV));
			float2 cos_thetaSq = cos_theta * cos_theta;

			float sin_theta = sqrt((1 - cos_theta.x) * (1 - cos_thetaSq.y));

			float light_plane = normalize(lightDir - cos_theta.x * s.Normal);
			float view_plane = normalize(viewDir - cos_theta.y * s.Normal);

			float cos_phi = saturate(dot(light_plane, view_plane));


			float diffuse_oren_nayar = (cos_phi * sin_theta) / max(cos_theta.x, cos_theta.y);
			float diffuse = cos_theta.x * (oren_nayar.x + oren_nayar.y * diffuse_oren_nayar);

			float4 color;
			color.rgb = s.Albedo * _LightColor0.rgb * (diffuse * atten);
			color.a = s.Alpha;

			return color;
		}

		sampler2D _MainTex;
		sampler2D _BumpTex;
		float4 _Color;
		float4 _RimColor;
		float _NormalIntensity;
		float _RimPower;

		struct Input {
			float2 uv_MainTex;
			float2 uv_BumpTex;
			float3 viewDir;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			half3 normal = UnpackNormal(tex2D(_BumpTex, IN.uv_BumpTex));
			normal = float3(normal.x * _NormalIntensity, normal.y * _NormalIntensity, normal.z);

			o.Albedo = c.rgb * rim * _RimColor;
			o.Normal = normal;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
