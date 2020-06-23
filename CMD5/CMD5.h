#pragma once

// 引入库
#include<msclr\marshal_cppstd.h>
#include<math.h>
#include<string>
#include<memory.h>
#include<cstdlib>

// define
#define UInt32 unsigned int
#define BIT_OF_BYTE  8
#define BIT_OF_GROUP 512
#define SRC_DATA_LEN 64


// 四个非线性函数宏定义
#define DEF_F(X, Y, Z ) ((( (X) & (Y) )|((~X)&(Z))))
#define DEF_G(X, Y, Z)  (((X)&(Z))|((Y)&(~Z)))
#define DEF_H(X, Y, Z)  ((X)^(Y)^(Z))
#define DEF_I(X, Y, Z)  ((Y)^((X)|(~Z)))


// 求链接数函数宏定义
#define FF(a, b, c, d, Mj, s, ti)  (a = b + CycleMoveLeft((a + DEF_F(b,c,d) + Mj + ti),s));
#define GG(a, b, c, d, Mj, s, ti)  (a = b + CycleMoveLeft((a + DEF_G(b,c,d) + Mj + ti),s));
#define HH(a, b, c, d, Mj, s, ti)  (a = b + CycleMoveLeft((a + DEF_H(b,c,d) + Mj + ti),s));
#define II(a, b, c, d, Mj, s, ti)  (a = b + CycleMoveLeft((a + DEF_I(b,c,d) + Mj + ti),s));

using namespace System;


namespace CMD5 {
	public struct ParamDynamic
	{
		UInt32 ua_;
		UInt32 ub_;
		UInt32 uc_;
		UInt32 ud_;
	};


	public ref class Md5Encode
	{
	public:
		// TODO: 在此处为此类添加方法。
		Md5Encode()
		{
		}
		static String^ Encode(String^ src_info);

	protected:
		static UInt32 CycleMoveLeft(UInt32 src_num, int bit_num_to_move);
		static UInt32 FillData(const char *in_data_ptr, int data_byte_len, char** out_data_ptr);
		static void RoundF(char *data_512_ptr, ParamDynamic & param);
		static void RoundG(char *data_512_ptr, ParamDynamic & param);
		static void RoundH(char *data_512_ptr, ParamDynamic & param);
		static void RoundI(char *data_512_ptr, ParamDynamic & param);
		static void RotationCalculate(char *data_512_ptr, ParamDynamic & param);
		static std::string GetHexStr(unsigned int num_str);

	private:
		// 幻数定义
		static const int kA = 0x67452301;
		static const int kB = 0xefcdab89;
		static const int kC = 0x98badcfe;
		static const int kD = 0x10325476;
		static const unsigned long long k_ti_num_integer = 4294967296;
	};
}
