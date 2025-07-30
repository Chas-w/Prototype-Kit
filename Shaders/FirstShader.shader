Shader"Unlit/FirstShader"
{
    Properties //basically allows us to define public variables within unity
    {
        _Color("Test Color", color) = (1,1,1,1)  //no semicolon to end property declarations
    }

    SubShader //contains instructions on how to set up the renderer and instruction to the GPU
    {
        Tags { "RenderType"="Opaque" } //different types of rendering properties
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert //declaring vertex function (runs on every vert)
            #pragma fragment frag //declaring fragment function (runs on every pixel)

            #include "UnityCG.cginc" 

            struct appdata //object data or mesh data (all the data coming from the object/mesh)
            {
                float4 vertex : POSITION;
            };

            struct v2f //passes data from vertex to fragment
            {
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v) //Vertex function is executed first: 
                                 //it takes the shape of the model and potentially modifies it. 
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target //Fragment Function: 
                                            //applies color to the shape output by the vert function
            {
                // sample the texture
                half2 someValue = half2(1, 1);
                fixed4 col = 1;
                return col;
            }
            ENDCG
        }
    }
}
