Shader "Custom/PortalShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white"{}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;  // Cambiado a float4
                float4 posPantalla : TEXCOORD0;  // Cambiado TEXCOORD0
                UNITY_FOG_COORDS(1)
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;

                o.vertex = UnityObjectToClipPos(v.vertex); // Convierte la posición del objeto a clip-space
                o.posPantalla = ComputeScreenPos(o.vertex); // Calcula la posición de pantalla
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Normaliza las coordenadas de pantalla para obtener coordenadas UV
                float2 uv = i.posPantalla.xy / i.posPantalla.w;
                
                // Aplica el mapeo de las coordenadas UV de la textura
                fixed4 col = tex2D(_MainTex, uv);

                // Aplica el efecto de niebla
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}