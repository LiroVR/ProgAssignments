Shader "Custom/Raindrops"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _RaindropTex ("Raindrop Normal Map", 2D) = "bump" {}
        _Refraction ("Refraction", Range(0, 1)) = 0.5
        _Blur ("Blur", Range(0, 1)) = 0.1
        _Smoothness ("Smoothness", Range(0, 1)) = 0.5
        _NormalStrength ("Normal Map Strength", Range(0, 1)) = 1.0
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        GrabPass { "_GrabTexture" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
                float4 grabPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            sampler2D _RaindropTex;
            sampler2D _GrabTexture;
            float _Refraction;
            float _Blur;
            float _Smoothness;
            float _NormalStrength;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.grabPos = ComputeGrabScreenPos(o.pos);
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                float2 grabUV = i.grabPos.xy / i.grabPos.w;

                // Apply raindrop normal map for refraction
                half4 raindropNormal = tex2D(_RaindropTex, i.uv);
                grabUV += (raindropNormal.rg * 2.0 - 1.0) * _NormalStrength;

                half4 col = tex2D(_GrabTexture, grabUV);

                // Apply blur effect
                half4 blurCol = half4(0, 0, 0, 0);
                float2 blurOffsets[4] = { float2(-0.01, 0), float2(0.01, 0), float2(0, -0.01), float2(0, 0.01) };
                for (int j = 0; j < 4; j++)
                {
                    blurCol += tex2D(_GrabTexture, grabUV + blurOffsets[j]);
                }
                blurCol /= 4.0;
                col = lerp(col, blurCol, _Blur);

                // Apply smoothness
                half4 baseCol = tex2D(_MainTex, i.uv);
                col.rgb = lerp(col.rgb, baseCol.rgb, _Smoothness);

                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}