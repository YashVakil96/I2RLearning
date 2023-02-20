#include <Packages/com.blendernodesgraph.core/Editor/Includes/Importers.hlsl>

void _4DNoise_float(float3 _POS, float3 _PVS, float3 _PWS, float3 _NOS, float3 _NVS, float3 _NWS, float3 _NTS, float3 _TWS, float3 _BTWS, float3 _UV, float3 _SP, float3 _VVS, float3 _VWS, Texture2D image_541994, Texture2D gradient_541984, Texture2D image_541978, out float4 Color, out float3 Normal, out float Smoothness, out float4 Emission, out float AmbientOcculusion, out float Metallic, out float4 Specular)
{
	
	float4 _Mapping_541980 = float4(mapping_point(float3(0, 0, 0), float3(0, 0, 0), float3(0, 0, 0), float3(1, 1, 1)), 0);
	float4 _ImageTexture_541978 = node_image_texture(image_541978, _Mapping_541980, 0);
	float4 _ImageTexture_541994 = node_image_texture(image_541994, _Mapping_541980, 0);
	float _SeparateXYZ_541986_x = separate_x(_ImageTexture_541994);
	float _SeparateXYZ_541986_y = separate_y(_ImageTexture_541994);
	float _Math_541990 = math_subtract(1, _SeparateXYZ_541986_y, 0.5);
	float _SeparateXYZ_541986_z = separate_z(_ImageTexture_541994);
	float4 _CombineXYZ_541988 = float4(combine_xyz(_SeparateXYZ_541986_x, _Math_541990, _SeparateXYZ_541986_z), 0);
	float4 _NormalMap_541992; node_normal_map(_CombineXYZ_541988, 1, _NormalMap_541992);

	Color = _ImageTexture_541978;
	Normal = _NormalMap_541992;
	Smoothness = 0.0;
	Emission = float4(0.0, 0.0, 0.0, 0.0);
	AmbientOcculusion = 0.0;
	Metallic = 0.0;
	Specular = float4(0.0, 0.0, 0.0, 0.0);
}