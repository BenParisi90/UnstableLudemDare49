// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Horse"
{
	Properties
	{
		_Texture("Texture", 2D) = "white" {}
		_Pulse("Pulse", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Texture;
		uniform sampler2D _Pulse;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float mulTime11 = _Time.y * 0.06666667;
			float2 temp_cast_0 = (mulTime11).xx;
			float2 uv_TexCoord2 = i.uv_texcoord * float2( 1,1 ) + temp_cast_0;
			float mulTime29 = _Time.y * -0.06666667;
			float2 temp_cast_1 = (mulTime29).xx;
			float2 uv_TexCoord30 = i.uv_texcoord * float2( 1,1 ) + temp_cast_1;
			float4 blendOpSrc16 = tex2D( _Texture, uv_TexCoord2 );
			float4 blendOpDest16 = tex2D( _Pulse, uv_TexCoord30 );
			o.Emission = ( saturate( abs( blendOpSrc16 - blendOpDest16 ) )).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18912
230.6667;293.3333;2015.333;823.6667;-870.2345;29.74158;1;True;True
Node;AmplifyShaderEditor.RangedFloatNode;27;751.8542,455.8942;Inherit;False;Constant;_Float1;Float 0;1;0;Create;True;0;0;0;False;0;False;-0.06666667;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;15;777.438,133.3214;Inherit;False;Constant;_Float0;Float 0;1;0;Create;True;0;0;0;False;0;False;0.06666667;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;29;933.4262,458.366;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;28;960.7372,282.9572;Inherit;False;Constant;_Vector1;Vector 0;1;0;Create;True;0;0;0;False;0;False;1,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleTimeNode;11;959.01,135.7932;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;3;986.321,-39.61563;Inherit;False;Constant;_Vector0;Vector 0;1;0;Create;True;0;0;0;False;0;False;1,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;30;1165.438,374.1621;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;2;1191.022,51.5893;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;1537.495,156.1779;Inherit;True;Property;_Texture;Texture;0;0;Create;True;0;0;0;False;0;False;-1;eb499b6c8d3794f4fb6b857a71f5c559;461697a585432cd458403ec2848d8f9d;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;17;1521.624,376.5605;Inherit;True;Property;_Pulse;Pulse;1;0;Create;True;0;0;0;False;0;False;-1;02c943f71d998024294d42260dc5829c;02c943f71d998024294d42260dc5829c;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;25;1826.982,574.6323;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.BlendOpsNode;16;2026.974,219.7765;Inherit;True;Difference;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;1;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;26;1651.999,634.8267;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;24;1500.626,631.3357;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SinOpNode;23;1336.843,643.9343;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;22;1161.861,639.7346;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;21;915.4857,648.1335;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;2365.62,163.801;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Horse;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;18;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;29;0;27;0
WireConnection;11;0;15;0
WireConnection;30;0;28;0
WireConnection;30;1;29;0
WireConnection;2;0;3;0
WireConnection;2;1;11;0
WireConnection;1;1;2;0
WireConnection;17;1;30;0
WireConnection;25;1;26;0
WireConnection;16;0;1;0
WireConnection;16;1;17;0
WireConnection;26;0;24;0
WireConnection;24;0;23;0
WireConnection;23;0;22;0
WireConnection;22;0;21;0
WireConnection;0;2;16;0
ASEEND*/
//CHKSM=7733EC2ED9196674C4B42A8D40911E972BE91A0E