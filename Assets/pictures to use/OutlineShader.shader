Shader "Custom/OutlineUnlitShader" {
    Properties {
        _OutlineColor ("Outline Color", Color) = (1,1,0,1) // Yellow
        _OutlineWidth ("Outline Width", Float) = 0.1
    }
    SubShader {
        Tags { "Queue" = "Overlay" }
        Pass {
            ZWrite Off
            ColorMask RGB
            Offset 1, 1
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f {
                float4 pos : SV_POSITION;
            };

            fixed4 _OutlineColor;
            float _OutlineWidth;

            v2f vert(appdata v) {
                v2f o;
                float3 offset = v.normal * _OutlineWidth;
                v.vertex.xyz += offset;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                return _OutlineColor;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
