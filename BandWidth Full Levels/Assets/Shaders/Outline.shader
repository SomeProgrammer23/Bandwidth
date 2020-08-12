Shader "Custom/Outline"  //Taught by Morgan James
{
    Properties // Variables
    {
        _MainTex("Main Texture (RGB)", 2D) = "white" {} // Texture Property
        _Color("Colour", Color) = (1,1,1,1) // Colour Property
        _OutlineTex("Outline Texture", 2D) = "white" {} // Outline Texture Property
        _OutlineColor("Outline Colour", Color) = (1,1,1,1) // Outline Colour Property
        _OutlineWidth("Outline Width", Range(1.0, 10.0)) = 1.1 // Outline Width Property
    }
    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
        }

        Pass
        {
            Name "OUTLINE"

            Zwrite Off

            CGPROGRAM
            //Funtions
            #pragma vertex vert // Gets shape info and tells how to build shape

            #pragma fragment frag// Colour Grading

            //Inludes

            #include "UnityCG.cginc"

            //Structures

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            //Imports

            float4 _OutlineColor;
            sampler2D _OutlineTex;
            float _OutlineWidth;

            //Vertex Funct

            v2f vert(appdata IN)
            {
                IN.vertex.xyz *= _OutlineWidth;
                v2f OUT;
                OUT.pos = UnityObjectToClipPos(IN.vertex);
                OUT.uv = IN.uv;

                return OUT;
            }

            //Frag Funct

            fixed4 frag(v2f IN) : SV_Target
            {
                float4 texColor = tex2D(_OutlineTex, IN.uv);
                return texColor * _OutlineColor;
            }
            ENDCG
        }
        Pass
        {
            Name "OBJECT"
            CGPROGRAM
            //Funtions
            #pragma vertex vert // Gets shape info and tells how to build shape

            #pragma fragment frag// Colour Grading

            //Inludes

            #include "UnityCG.cginc"

            //Structures

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            //Imports

            float4 _Color;
            sampler2D _MainTex;

            //Vertex Funct

            v2f vert(appdata IN)
            {
                v2f OUT;
                OUT.pos = UnityObjectToClipPos(IN.vertex);
                OUT.uv = IN.uv;

                return OUT;
            }

            //Frag Funct

            fixed4 frag(v2f IN) : SV_Target
            {
                float4 texColor = tex2D(_MainTex, IN.uv);
                return texColor * _Color;
            }
            ENDCG
        }
    }

}
