Shader "Custom/UnityGlass"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _ChromaticAberration ("Chromatic Aberration", Range(0, 1)) = 0.1
        _Refraction ("Refraction", Range(0, 1)) = 0.5
        _Blur ("Blur", Range(0, 1)) = 0.1
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
            sampler2D _GrabTexture;
            float _ChromaticAberration;
            float _Refraction;
            float _Blur;

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
                grabUV += (grabUV - 0.5) * _Refraction;

                half4 col = tex2D(_GrabTexture, grabUV);
                col.rgb += _ChromaticAberration * (tex2D(_GrabTexture, grabUV + float2(0.01, 0)).rgb - tex2D(_GrabTexture, grabUV + float2(-0.01, 0)).rgb);
                col.rgb += _ChromaticAberration * (tex2D(_GrabTexture, grabUV + float2(0, 0.01)).rgb - tex2D(_GrabTexture, grabUV + float2(0, -0.01)).rgb);

                col = lerp(col, tex2D(_MainTex, i.uv), _Blur);

                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
