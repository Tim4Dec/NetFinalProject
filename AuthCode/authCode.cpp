#include"pch.h"
#include"authCode.h"
#include<iostream>



int Generate(int len, char* result)
{
	std::string buffer = "0123456789ABCDEFGHIJKLMNOPQRSEUVWSYZabcdefghijklmnopqrseuvwsyz";
	//std::string str;
	char* str = new char[len];
	int range = buffer.length();

	srand((unsigned)time(NULL));
	for (int i = 0; i < len; i++) {
		char ch = buffer[rand() % range];
		//std::string s = buffer.substr(rand() % range, 1);
		//str.append(s);
		str[i] = ch;
	}
	char attr[1024];
	memset(attr, 0, sizeof(attr));
	memcpy(attr, str, len);
	memcpy(result, attr, sizeof(attr));
	//const char* s = result;
	//return (char*)result;
	return 1;
}