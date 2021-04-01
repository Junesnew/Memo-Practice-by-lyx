//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Custom/HSVShader" {
Properties {
_MainTex ("Sprite Texture", 2D) = "white" { }
[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
_HueShift ("HueShift", Float) = 0
_Sat ("Saturation", Float) = 1
_Val ("Value", Float) = 1
_Alpha ("Alpha", Range(0, 1)) = 1
}
SubShader {
 Tags { "CanUseSpriteAtlas" = "true" "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
 Pass {
  Tags { "CanUseSpriteAtlas" = "true" "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
  ZWrite Off
  Cull Off
  GpuProgramID 10144
Program "vp" {
SubProgram "gles hw_tier00 " {
Keywords { "PIXELSNAP_ON" }
"#ifdef VERTEX
#version 100

uniform 	vec4 _ScreenParams;
uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
uniform 	vec4 _MainTex_ST;
attribute highp vec4 in_POSITION0;
attribute highp vec2 in_TEXCOORD0;
attribute mediump vec4 in_COLOR0;
varying highp vec2 vs_TEXCOORD0;
varying mediump vec4 vs_COLOR0;
vec4 u_xlat0;
vec4 u_xlat1;
float roundEven(float x) { float y = floor(x + 0.5); return (y - x == 0.5) ? floor(0.5*y) * 2.0 : y; }
vec2 roundEven(vec2 a) { a.x = roundEven(a.x); a.y = roundEven(a.y); return a; }
vec3 roundEven(vec3 a) { a.x = roundEven(a.x); a.y = roundEven(a.y); a.z = roundEven(a.z); return a; }
vec4 roundEven(vec4 a) { a.x = roundEven(a.x); a.y = roundEven(a.y); a.z = roundEven(a.z); a.w = roundEven(a.w); return a; }

void main()
{
    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
    u_xlat0.xy = u_xlat0.xy / u_xlat0.ww;
    u_xlat1.xy = _ScreenParams.xy * vec2(0.5, 0.5);
    u_xlat0.xy = u_xlat0.xy * u_xlat1.xy;
    u_xlat0.xy = roundEven(u_xlat0.xy);
    u_xlat0.xy = u_xlat0.xy / u_xlat1.xy;
    gl_Position.xy = u_xlat0.ww * u_xlat0.xy;
    gl_Position.zw = u_xlat0.zw;
    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    vs_COLOR0 = in_COLOR0;
    return;
}

#endif
#ifdef FRAGMENT
#version 100

#ifdef GL_FRAGMENT_PRECISION_HIGH
    precision highp float;
#else
    precision mediump float;
#endif
precision highp int;
uniform 	float _HueShift;
uniform 	float _Sat;
uniform 	float _Val;
uniform 	float _Alpha;
uniform lowp sampler2D _MainTex;
varying highp vec2 vs_TEXCOORD0;
varying mediump vec4 vs_COLOR0;
#define SV_Target0 gl_FragData[0]
float u_xlat0;
mediump vec4 u_xlat16_0;
lowp vec4 u_xlat10_0;
vec4 u_xlat1;
mediump vec3 u_xlat16_2;
vec4 u_xlat3;
vec4 u_xlat4;
vec2 u_xlat5;
float u_xlat10;
float u_xlat15;
void main()
{
    u_xlat10_0 = texture2D(_MainTex, vs_TEXCOORD0.xy);
    u_xlat16_0 = u_xlat10_0 * vs_COLOR0;
    u_xlat1.w = u_xlat16_0.w * _Alpha;
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat1.www;
    u_xlat0 = _HueShift * 0.0174532942;
    u_xlat3.x = cos(u_xlat0);
    u_xlat0 = sin(u_xlat0);
    u_xlat5.x = _Sat * _Val;
    u_xlat10 = u_xlat3.x * u_xlat5.x;
    u_xlat0 = u_xlat0 * u_xlat5.x;
    u_xlat3 = vec4(u_xlat10) * vec4(0.412999988, 0.300000012, 0.588, 0.885999978);
    u_xlat4 = vec4(u_xlat10) * vec4(0.700999975, 0.587000012, 0.114, 0.298999995);
    u_xlat5.xy = vec2(vec2(_Val, _Val)) * vec2(0.298999995, 0.587000012) + (-u_xlat3.yz);
    u_xlat3.xy = vec2(vec2(_Val, _Val)) * vec2(0.587000012, 0.114) + u_xlat3.xw;
    u_xlat5.x = u_xlat0 * 1.25 + u_xlat5.x;
    u_xlat10 = (-u_xlat0) * 1.04999995 + u_xlat5.y;
    u_xlat10 = u_xlat16_2.y * u_xlat10;
    u_xlat5.x = u_xlat5.x * u_xlat16_2.x + u_xlat10;
    u_xlat10 = (-u_xlat0) * 0.202999994 + u_xlat3.y;
    u_xlat15 = u_xlat0 * 0.0350000001 + u_xlat3.x;
    u_xlat1.z = u_xlat10 * u_xlat16_2.z + u_xlat5.x;
    u_xlat5.x = _Val * 0.298999995 + u_xlat4.x;
    u_xlat3.xyz = vec3(vec3(_Val, _Val, _Val)) * vec3(0.587000012, 0.114, 0.298999995) + (-u_xlat4.yzw);
    u_xlat5.x = u_xlat0 * 0.167999998 + u_xlat5.x;
    u_xlat10 = u_xlat0 * 0.330000013 + u_xlat3.x;
    u_xlat10 = u_xlat16_2.y * u_xlat10;
    u_xlat5.x = u_xlat5.x * u_xlat16_2.x + u_xlat10;
    u_xlat3.xz = (-vec2(u_xlat0)) * vec2(0.497000009, 0.328000009) + u_xlat3.yz;
    u_xlat0 = u_xlat0 * 0.291999996 + u_xlat3.y;
    u_xlat1.x = u_xlat3.x * u_xlat16_2.z + u_xlat5.x;
    u_xlat5.x = u_xlat16_2.x * u_xlat3.z;
    u_xlat5.x = u_xlat15 * u_xlat16_2.y + u_xlat5.x;
    u_xlat1.y = u_xlat0 * u_xlat16_2.z + u_xlat5.x;
    SV_Target0 = u_xlat1;
    return;
}

#endif
"
}
SubProgram "gles hw_tier01 " {
Keywords { "PIXELSNAP_ON" }
"#ifdef VERTEX
#version 100

uniform 	vec4 _ScreenParams;
uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
uniform 	vec4 _MainTex_ST;
attribute highp vec4 in_POSITION0;
attribute highp vec2 in_TEXCOORD0;
attribute mediump vec4 in_COLOR0;
varying highp vec2 vs_TEXCOORD0;
varying mediump vec4 vs_COLOR0;
vec4 u_xlat0;
vec4 u_xlat1;
float roundEven(float x) { float y = floor(x + 0.5); return (y - x == 0.5) ? floor(0.5*y) * 2.0 : y; }
vec2 roundEven(vec2 a) { a.x = roundEven(a.x); a.y = roundEven(a.y); return a; }
vec3 roundEven(vec3 a) { a.x = roundEven(a.x); a.y = roundEven(a.y); a.z = roundEven(a.z); return a; }
vec4 roundEven(vec4 a) { a.x = roundEven(a.x); a.y = roundEven(a.y); a.z = roundEven(a.z); a.w = roundEven(a.w); return a; }

void main()
{
    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
    u_xlat0.xy = u_xlat0.xy / u_xlat0.ww;
    u_xlat1.xy = _ScreenParams.xy * vec2(0.5, 0.5);
    u_xlat0.xy = u_xlat0.xy * u_xlat1.xy;
    u_xlat0.xy = roundEven(u_xlat0.xy);
    u_xlat0.xy = u_xlat0.xy / u_xlat1.xy;
    gl_Position.xy = u_xlat0.ww * u_xlat0.xy;
    gl_Position.zw = u_xlat0.zw;
    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    vs_COLOR0 = in_COLOR0;
    return;
}

#endif
#ifdef FRAGMENT
#version 100

#ifdef GL_FRAGMENT_PRECISION_HIGH
    precision highp float;
#else
    precision mediump float;
#endif
precision highp int;
uniform 	float _HueShift;
uniform 	float _Sat;
uniform 	float _Val;
uniform 	float _Alpha;
uniform lowp sampler2D _MainTex;
varying highp vec2 vs_TEXCOORD0;
varying mediump vec4 vs_COLOR0;
#define SV_Target0 gl_FragData[0]
float u_xlat0;
mediump vec4 u_xlat16_0;
lowp vec4 u_xlat10_0;
vec4 u_xlat1;
mediump vec3 u_xlat16_2;
vec4 u_xlat3;
vec4 u_xlat4;
vec2 u_xlat5;
float u_xlat10;
float u_xlat15;
void main()
{
    u_xlat10_0 = texture2D(_MainTex, vs_TEXCOORD0.xy);
    u_xlat16_0 = u_xlat10_0 * vs_COLOR0;
    u_xlat1.w = u_xlat16_0.w * _Alpha;
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat1.www;
    u_xlat0 = _HueShift * 0.0174532942;
    u_xlat3.x = cos(u_xlat0);
    u_xlat0 = sin(u_xlat0);
    u_xlat5.x = _Sat * _Val;
    u_xlat10 = u_xlat3.x * u_xlat5.x;
    u_xlat0 = u_xlat0 * u_xlat5.x;
    u_xlat3 = vec4(u_xlat10) * vec4(0.412999988, 0.300000012, 0.588, 0.885999978);
    u_xlat4 = vec4(u_xlat10) * vec4(0.700999975, 0.587000012, 0.114, 0.298999995);
    u_xlat5.xy = vec2(vec2(_Val, _Val)) * vec2(0.298999995, 0.587000012) + (-u_xlat3.yz);
    u_xlat3.xy = vec2(vec2(_Val, _Val)) * vec2(0.587000012, 0.114) + u_xlat3.xw;
    u_xlat5.x = u_xlat0 * 1.25 + u_xlat5.x;
    u_xlat10 = (-u_xlat0) * 1.04999995 + u_xlat5.y;
    u_xlat10 = u_xlat16_2.y * u_xlat10;
    u_xlat5.x = u_xlat5.x * u_xlat16_2.x + u_xlat10;
    u_xlat10 = (-u_xlat0) * 0.202999994 + u_xlat3.y;
    u_xlat15 = u_xlat0 * 0.0350000001 + u_xlat3.x;
    u_xlat1.z = u_xlat10 * u_xlat16_2.z + u_xlat5.x;
    u_xlat5.x = _Val * 0.298999995 + u_xlat4.x;
    u_xlat3.xyz = vec3(vec3(_Val, _Val, _Val)) * vec3(0.587000012, 0.114, 0.298999995) + (-u_xlat4.yzw);
    u_xlat5.x = u_xlat0 * 0.167999998 + u_xlat5.x;
    u_xlat10 = u_xlat0 * 0.330000013 + u_xlat3.x;
    u_xlat10 = u_xlat16_2.y * u_xlat10;
    u_xlat5.x = u_xlat5.x * u_xlat16_2.x + u_xlat10;
    u_xlat3.xz = (-vec2(u_xlat0)) * vec2(0.497000009, 0.328000009) + u_xlat3.yz;
    u_xlat0 = u_xlat0 * 0.291999996 + u_xlat3.y;
    u_xlat1.x = u_xlat3.x * u_xlat16_2.z + u_xlat5.x;
    u_xlat5.x = u_xlat16_2.x * u_xlat3.z;
    u_xlat5.x = u_xlat15 * u_xlat16_2.y + u_xlat5.x;
    u_xlat1.y = u_xlat0 * u_xlat16_2.z + u_xlat5.x;
    SV_Target0 = u_xlat1;
    return;
}

#endif
"
}
SubProgram "gles hw_tier02 " {
Keywords { "PIXELSNAP_ON" }
"#ifdef VERTEX
#version 100

uniform 	vec4 _ScreenParams;
uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
uniform 	vec4 _MainTex_ST;
attribute highp vec4 in_POSITION0;
attribute highp vec2 in_TEXCOORD0;
attribute mediump vec4 in_COLOR0;
varying highp vec2 vs_TEXCOORD0;
varying mediump vec4 vs_COLOR0;
vec4 u_xlat0;
vec4 u_xlat1;
float roundEven(float x) { float y = floor(x + 0.5); return (y - x == 0.5) ? floor(0.5*y) * 2.0 : y; }
vec2 roundEven(vec2 a) { a.x = roundEven(a.x); a.y = roundEven(a.y); return a; }
vec3 roundEven(vec3 a) { a.x = roundEven(a.x); a.y = roundEven(a.y); a.z = roundEven(a.z); return a; }
vec4 roundEven(vec4 a) { a.x = roundEven(a.x); a.y = roundEven(a.y); a.z = roundEven(a.z); a.w = roundEven(a.w); return a; }

void main()
{
    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
    u_xlat0.xy = u_xlat0.xy / u_xlat0.ww;
    u_xlat1.xy = _ScreenParams.xy * vec2(0.5, 0.5);
    u_xlat0.xy = u_xlat0.xy * u_xlat1.xy;
    u_xlat0.xy = roundEven(u_xlat0.xy);
    u_xlat0.xy = u_xlat0.xy / u_xlat1.xy;
    gl_Position.xy = u_xlat0.ww * u_xlat0.xy;
    gl_Position.zw = u_xlat0.zw;
    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    vs_COLOR0 = in_COLOR0;
    return;
}

#endif
#ifdef FRAGMENT
#version 100

#ifdef GL_FRAGMENT_PRECISION_HIGH
    precision highp float;
#else
    precision mediump float;
#endif
precision highp int;
uniform 	float _HueShift;
uniform 	float _Sat;
uniform 	float _Val;
uniform 	float _Alpha;
uniform lowp sampler2D _MainTex;
varying highp vec2 vs_TEXCOORD0;
varying mediump vec4 vs_COLOR0;
#define SV_Target0 gl_FragData[0]
float u_xlat0;
mediump vec4 u_xlat16_0;
lowp vec4 u_xlat10_0;
vec4 u_xlat1;
mediump vec3 u_xlat16_2;
vec4 u_xlat3;
vec4 u_xlat4;
vec2 u_xlat5;
float u_xlat10;
float u_xlat15;
void main()
{
    u_xlat10_0 = texture2D(_MainTex, vs_TEXCOORD0.xy);
    u_xlat16_0 = u_xlat10_0 * vs_COLOR0;
    u_xlat1.w = u_xlat16_0.w * _Alpha;
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat1.www;
    u_xlat0 = _HueShift * 0.0174532942;
    u_xlat3.x = cos(u_xlat0);
    u_xlat0 = sin(u_xlat0);
    u_xlat5.x = _Sat * _Val;
    u_xlat10 = u_xlat3.x * u_xlat5.x;
    u_xlat0 = u_xlat0 * u_xlat5.x;
    u_xlat3 = vec4(u_xlat10) * vec4(0.412999988, 0.300000012, 0.588, 0.885999978);
    u_xlat4 = vec4(u_xlat10) * vec4(0.700999975, 0.587000012, 0.114, 0.298999995);
    u_xlat5.xy = vec2(vec2(_Val, _Val)) * vec2(0.298999995, 0.587000012) + (-u_xlat3.yz);
    u_xlat3.xy = vec2(vec2(_Val, _Val)) * vec2(0.587000012, 0.114) + u_xlat3.xw;
    u_xlat5.x = u_xlat0 * 1.25 + u_xlat5.x;
    u_xlat10 = (-u_xlat0) * 1.04999995 + u_xlat5.y;
    u_xlat10 = u_xlat16_2.y * u_xlat10;
    u_xlat5.x = u_xlat5.x * u_xlat16_2.x + u_xlat10;
    u_xlat10 = (-u_xlat0) * 0.202999994 + u_xlat3.y;
    u_xlat15 = u_xlat0 * 0.0350000001 + u_xlat3.x;
    u_xlat1.z = u_xlat10 * u_xlat16_2.z + u_xlat5.x;
    u_xlat5.x = _Val * 0.298999995 + u_xlat4.x;
    u_xlat3.xyz = vec3(vec3(_Val, _Val, _Val)) * vec3(0.587000012, 0.114, 0.298999995) + (-u_xlat4.yzw);
    u_xlat5.x = u_xlat0 * 0.167999998 + u_xlat5.x;
    u_xlat10 = u_xlat0 * 0.330000013 + u_xlat3.x;
    u_xlat10 = u_xlat16_2.y * u_xlat10;
    u_xlat5.x = u_xlat5.x * u_xlat16_2.x + u_xlat10;
    u_xlat3.xz = (-vec2(u_xlat0)) * vec2(0.497000009, 0.328000009) + u_xlat3.yz;
    u_xlat0 = u_xlat0 * 0.291999996 + u_xlat3.y;
    u_xlat1.x = u_xlat3.x * u_xlat16_2.z + u_xlat5.x;
    u_xlat5.x = u_xlat16_2.x * u_xlat3.z;
    u_xlat5.x = u_xlat15 * u_xlat16_2.y + u_xlat5.x;
    u_xlat1.y = u_xlat0 * u_xlat16_2.z + u_xlat5.x;
    SV_Target0 = u_xlat1;
    return;
}

#endif
"
}
SubProgram "gles3 hw_tier00 " {
Keywords { "PIXELSNAP_ON" }
"#ifdef VERTEX
#version 300 es

uniform 	vec4 _ScreenParams;
uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
uniform 	vec4 _MainTex_ST;
in highp vec4 in_POSITION0;
in highp vec2 in_TEXCOORD0;
in mediump vec4 in_COLOR0;
out highp vec2 vs_TEXCOORD0;
out mediump vec4 vs_COLOR0;
vec4 u_xlat0;
vec4 u_xlat1;
void main()
{
    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
    u_xlat0.xy = u_xlat0.xy / u_xlat0.ww;
    u_xlat1.xy = _ScreenParams.xy * vec2(0.5, 0.5);
    u_xlat0.xy = u_xlat0.xy * u_xlat1.xy;
    u_xlat0.xy = roundEven(u_xlat0.xy);
    u_xlat0.xy = u_xlat0.xy / u_xlat1.xy;
    gl_Position.xy = u_xlat0.ww * u_xlat0.xy;
    gl_Position.zw = u_xlat0.zw;
    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    vs_COLOR0 = in_COLOR0;
    return;
}

#endif
#ifdef FRAGMENT
#version 300 es

precision highp float;
precision highp int;
uniform 	float _HueShift;
uniform 	float _Sat;
uniform 	float _Val;
uniform 	float _Alpha;
uniform mediump sampler2D _MainTex;
in highp vec2 vs_TEXCOORD0;
in mediump vec4 vs_COLOR0;
layout(location = 0) out mediump vec4 SV_Target0;
float u_xlat0;
mediump vec4 u_xlat16_0;
vec4 u_xlat1;
mediump vec3 u_xlat16_2;
vec4 u_xlat3;
vec4 u_xlat4;
vec2 u_xlat5;
float u_xlat10;
float u_xlat15;
void main()
{
    u_xlat16_0 = texture(_MainTex, vs_TEXCOORD0.xy);
    u_xlat16_0 = u_xlat16_0 * vs_COLOR0;
    u_xlat1.w = u_xlat16_0.w * _Alpha;
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat1.www;
    u_xlat0 = _HueShift * 0.0174532942;
    u_xlat3.x = cos(u_xlat0);
    u_xlat0 = sin(u_xlat0);
    u_xlat5.x = _Sat * _Val;
    u_xlat10 = u_xlat3.x * u_xlat5.x;
    u_xlat0 = u_xlat0 * u_xlat5.x;
    u_xlat3 = vec4(u_xlat10) * vec4(0.412999988, 0.300000012, 0.588, 0.885999978);
    u_xlat4 = vec4(u_xlat10) * vec4(0.700999975, 0.587000012, 0.114, 0.298999995);
    u_xlat5.xy = vec2(vec2(_Val, _Val)) * vec2(0.298999995, 0.587000012) + (-u_xlat3.yz);
    u_xlat3.xy = vec2(vec2(_Val, _Val)) * vec2(0.587000012, 0.114) + u_xlat3.xw;
    u_xlat5.x = u_xlat0 * 1.25 + u_xlat5.x;
    u_xlat10 = (-u_xlat0) * 1.04999995 + u_xlat5.y;
    u_xlat10 = u_xlat16_2.y * u_xlat10;
    u_xlat5.x = u_xlat5.x * u_xlat16_2.x + u_xlat10;
    u_xlat10 = (-u_xlat0) * 0.202999994 + u_xlat3.y;
    u_xlat15 = u_xlat0 * 0.0350000001 + u_xlat3.x;
    u_xlat1.z = u_xlat10 * u_xlat16_2.z + u_xlat5.x;
    u_xlat5.x = _Val * 0.298999995 + u_xlat4.x;
    u_xlat3.xyz = vec3(vec3(_Val, _Val, _Val)) * vec3(0.587000012, 0.114, 0.298999995) + (-u_xlat4.yzw);
    u_xlat5.x = u_xlat0 * 0.167999998 + u_xlat5.x;
    u_xlat10 = u_xlat0 * 0.330000013 + u_xlat3.x;
    u_xlat10 = u_xlat16_2.y * u_xlat10;
    u_xlat5.x = u_xlat5.x * u_xlat16_2.x + u_xlat10;
    u_xlat3.xz = (-vec2(u_xlat0)) * vec2(0.497000009, 0.328000009) + u_xlat3.yz;
    u_xlat0 = u_xlat0 * 0.291999996 + u_xlat3.y;
    u_xlat1.x = u_xlat3.x * u_xlat16_2.z + u_xlat5.x;
    u_xlat5.x = u_xlat16_2.x * u_xlat3.z;
    u_xlat5.x = u_xlat15 * u_xlat16_2.y + u_xlat5.x;
    u_xlat1.y = u_xlat0 * u_xlat16_2.z + u_xlat5.x;
    SV_Target0 = u_xlat1;
    return;
}

#endif
"
}
SubProgram "gles3 hw_tier01 " {
Keywords { "PIXELSNAP_ON" }
"#ifdef VERTEX
#version 300 es

uniform 	vec4 _ScreenParams;
uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
uniform 	vec4 _MainTex_ST;
in highp vec4 in_POSITION0;
in highp vec2 in_TEXCOORD0;
in mediump vec4 in_COLOR0;
out highp vec2 vs_TEXCOORD0;
out mediump vec4 vs_COLOR0;
vec4 u_xlat0;
vec4 u_xlat1;
void main()
{
    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
    u_xlat0.xy = u_xlat0.xy / u_xlat0.ww;
    u_xlat1.xy = _ScreenParams.xy * vec2(0.5, 0.5);
    u_xlat0.xy = u_xlat0.xy * u_xlat1.xy;
    u_xlat0.xy = roundEven(u_xlat0.xy);
    u_xlat0.xy = u_xlat0.xy / u_xlat1.xy;
    gl_Position.xy = u_xlat0.ww * u_xlat0.xy;
    gl_Position.zw = u_xlat0.zw;
    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    vs_COLOR0 = in_COLOR0;
    return;
}

#endif
#ifdef FRAGMENT
#version 300 es

precision highp float;
precision highp int;
uniform 	float _HueShift;
uniform 	float _Sat;
uniform 	float _Val;
uniform 	float _Alpha;
uniform mediump sampler2D _MainTex;
in highp vec2 vs_TEXCOORD0;
in mediump vec4 vs_COLOR0;
layout(location = 0) out mediump vec4 SV_Target0;
float u_xlat0;
mediump vec4 u_xlat16_0;
vec4 u_xlat1;
mediump vec3 u_xlat16_2;
vec4 u_xlat3;
vec4 u_xlat4;
vec2 u_xlat5;
float u_xlat10;
float u_xlat15;
void main()
{
    u_xlat16_0 = texture(_MainTex, vs_TEXCOORD0.xy);
    u_xlat16_0 = u_xlat16_0 * vs_COLOR0;
    u_xlat1.w = u_xlat16_0.w * _Alpha;
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat1.www;
    u_xlat0 = _HueShift * 0.0174532942;
    u_xlat3.x = cos(u_xlat0);
    u_xlat0 = sin(u_xlat0);
    u_xlat5.x = _Sat * _Val;
    u_xlat10 = u_xlat3.x * u_xlat5.x;
    u_xlat0 = u_xlat0 * u_xlat5.x;
    u_xlat3 = vec4(u_xlat10) * vec4(0.412999988, 0.300000012, 0.588, 0.885999978);
    u_xlat4 = vec4(u_xlat10) * vec4(0.700999975, 0.587000012, 0.114, 0.298999995);
    u_xlat5.xy = vec2(vec2(_Val, _Val)) * vec2(0.298999995, 0.587000012) + (-u_xlat3.yz);
    u_xlat3.xy = vec2(vec2(_Val, _Val)) * vec2(0.587000012, 0.114) + u_xlat3.xw;
    u_xlat5.x = u_xlat0 * 1.25 + u_xlat5.x;
    u_xlat10 = (-u_xlat0) * 1.04999995 + u_xlat5.y;
    u_xlat10 = u_xlat16_2.y * u_xlat10;
    u_xlat5.x = u_xlat5.x * u_xlat16_2.x + u_xlat10;
    u_xlat10 = (-u_xlat0) * 0.202999994 + u_xlat3.y;
    u_xlat15 = u_xlat0 * 0.0350000001 + u_xlat3.x;
    u_xlat1.z = u_xlat10 * u_xlat16_2.z + u_xlat5.x;
    u_xlat5.x = _Val * 0.298999995 + u_xlat4.x;
    u_xlat3.xyz = vec3(vec3(_Val, _Val, _Val)) * vec3(0.587000012, 0.114, 0.298999995) + (-u_xlat4.yzw);
    u_xlat5.x = u_xlat0 * 0.167999998 + u_xlat5.x;
    u_xlat10 = u_xlat0 * 0.330000013 + u_xlat3.x;
    u_xlat10 = u_xlat16_2.y * u_xlat10;
    u_xlat5.x = u_xlat5.x * u_xlat16_2.x + u_xlat10;
    u_xlat3.xz = (-vec2(u_xlat0)) * vec2(0.497000009, 0.328000009) + u_xlat3.yz;
    u_xlat0 = u_xlat0 * 0.291999996 + u_xlat3.y;
    u_xlat1.x = u_xlat3.x * u_xlat16_2.z + u_xlat5.x;
    u_xlat5.x = u_xlat16_2.x * u_xlat3.z;
    u_xlat5.x = u_xlat15 * u_xlat16_2.y + u_xlat5.x;
    u_xlat1.y = u_xlat0 * u_xlat16_2.z + u_xlat5.x;
    SV_Target0 = u_xlat1;
    return;
}

#endif
"
}
SubProgram "gles3 hw_tier02 " {
Keywords { "PIXELSNAP_ON" }
"#ifdef VERTEX
#version 300 es

uniform 	vec4 _ScreenParams;
uniform 	vec4 hlslcc_mtx4x4unity_ObjectToWorld[4];
uniform 	vec4 hlslcc_mtx4x4unity_MatrixVP[4];
uniform 	vec4 _MainTex_ST;
in highp vec4 in_POSITION0;
in highp vec2 in_TEXCOORD0;
in mediump vec4 in_COLOR0;
out highp vec2 vs_TEXCOORD0;
out mediump vec4 vs_COLOR0;
vec4 u_xlat0;
vec4 u_xlat1;
void main()
{
    u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
    u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
    u_xlat0 = u_xlat0 + hlslcc_mtx4x4unity_ObjectToWorld[3];
    u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_MatrixVP[1];
    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
    u_xlat1 = hlslcc_mtx4x4unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
    u_xlat0 = hlslcc_mtx4x4unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
    u_xlat0.xy = u_xlat0.xy / u_xlat0.ww;
    u_xlat1.xy = _ScreenParams.xy * vec2(0.5, 0.5);
    u_xlat0.xy = u_xlat0.xy * u_xlat1.xy;
    u_xlat0.xy = roundEven(u_xlat0.xy);
    u_xlat0.xy = u_xlat0.xy / u_xlat1.xy;
    gl_Position.xy = u_xlat0.ww * u_xlat0.xy;
    gl_Position.zw = u_xlat0.zw;
    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
    vs_COLOR0 = in_COLOR0;
    return;
}

#endif
#ifdef FRAGMENT
#version 300 es

precision highp float;
precision highp int;
uniform 	float _HueShift;
uniform 	float _Sat;
uniform 	float _Val;
uniform 	float _Alpha;
uniform mediump sampler2D _MainTex;
in highp vec2 vs_TEXCOORD0;
in mediump vec4 vs_COLOR0;
layout(location = 0) out mediump vec4 SV_Target0;
float u_xlat0;
mediump vec4 u_xlat16_0;
vec4 u_xlat1;
mediump vec3 u_xlat16_2;
vec4 u_xlat3;
vec4 u_xlat4;
vec2 u_xlat5;
float u_xlat10;
float u_xlat15;
void main()
{
    u_xlat16_0 = texture(_MainTex, vs_TEXCOORD0.xy);
    u_xlat16_0 = u_xlat16_0 * vs_COLOR0;
    u_xlat1.w = u_xlat16_0.w * _Alpha;
    u_xlat16_2.xyz = u_xlat16_0.xyz * u_xlat1.www;
    u_xlat0 = _HueShift * 0.0174532942;
    u_xlat3.x = cos(u_xlat0);
    u_xlat0 = sin(u_xlat0);
    u_xlat5.x = _Sat * _Val;
    u_xlat10 = u_xlat3.x * u_xlat5.x;
    u_xlat0 = u_xlat0 * u_xlat5.x;
    u_xlat3 = vec4(u_xlat10) * vec4(0.412999988, 0.300000012, 0.588, 0.885999978);
    u_xlat4 = vec4(u_xlat10) * vec4(0.700999975, 0.587000012, 0.114, 0.298999995);
    u_xlat5.xy = vec2(vec2(_Val, _Val)) * vec2(0.298999995, 0.587000012) + (-u_xlat3.yz);
    u_xlat3.xy = vec2(vec2(_Val, _Val)) * vec2(0.587000012, 0.114) + u_xlat3.xw;
    u_xlat5.x = u_xlat0 * 1.25 + u_xlat5.x;
    u_xlat10 = (-u_xlat0) * 1.04999995 + u_xlat5.y;
    u_xlat10 = u_xlat16_2.y * u_xlat10;
    u_xlat5.x = u_xlat5.x * u_xlat16_2.x + u_xlat10;
    u_xlat10 = (-u_xlat0) * 0.202999994 + u_xlat3.y;
    u_xlat15 = u_xlat0 * 0.0350000001 + u_xlat3.x;
    u_xlat1.z = u_xlat10 * u_xlat16_2.z + u_xlat5.x;
    u_xlat5.x = _Val * 0.298999995 + u_xlat4.x;
    u_xlat3.xyz = vec3(vec3(_Val, _Val, _Val)) * vec3(0.587000012, 0.114, 0.298999995) + (-u_xlat4.yzw);
    u_xlat5.x = u_xlat0 * 0.167999998 + u_xlat5.x;
    u_xlat10 = u_xlat0 * 0.330000013 + u_xlat3.x;
    u_xlat10 = u_xlat16_2.y * u_xlat10;
    u_xlat5.x = u_xlat5.x * u_xlat16_2.x + u_xlat10;
    u_xlat3.xz = (-vec2(u_xlat0)) * vec2(0.497000009, 0.328000009) + u_xlat3.yz;
    u_xlat0 = u_xlat0 * 0.291999996 + u_xlat3.y;
    u_xlat1.x = u_xlat3.x * u_xlat16_2.z + u_xlat5.x;
    u_xlat5.x = u_xlat16_2.x * u_xlat3.z;
    u_xlat5.x = u_xlat15 * u_xlat16_2.y + u_xlat5.x;
    u_xlat1.y = u_xlat0 * u_xlat16_2.z + u_xlat5.x;
    SV_Target0 = u_xlat1;
    return;
}

#endif
"
}
}
Program "fp" {
SubProgram "gles hw_tier00 " {
Keywords { "PIXELSNAP_ON" }
""
}
SubProgram "gles hw_tier01 " {
Keywords { "PIXELSNAP_ON" }
""
}
SubProgram "gles hw_tier02 " {
Keywords { "PIXELSNAP_ON" }
""
}
SubProgram "gles3 hw_tier00 " {
Keywords { "PIXELSNAP_ON" }
""
}
SubProgram "gles3 hw_tier01 " {
Keywords { "PIXELSNAP_ON" }
""
}
SubProgram "gles3 hw_tier02 " {
Keywords { "PIXELSNAP_ON" }
""
}
}
}
}
Fallback "Diffuse"
}