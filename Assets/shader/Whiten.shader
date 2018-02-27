Shader "Hidden/Whiten"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
        _WhitenRatio("WhitenRatio", Range(0,1)) = 0
        _FinalColor("FinalColor",Color) = (1,1,1,1)
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
            float _WhitenRatio;
            fixed4 _FinalColor;;

            fixed4 lerpColor(fixed4 left,fixed4 right,float ratio){
                return left * (1-ratio) + right*ratio;
            }

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				// just invert the colors
                // fixed4 white = fixed4(1,1,1,1);
                return lerpColor(col,_FinalColor,_WhitenRatio);
			}
			ENDCG
		}
	}
}
