///////////////////////////////////////////////////////////
//  UtilConstants.cs
//  Implementation of the Class UtilConstants
//  Generated by Enterprise Architect
//  Created on:      05-6��-2018 16:03:05
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Dynamic;

namespace FD.Tiny.DataAccess {
	internal static class UtilConstants {

		public const string Dot = ".";
		public const char DotChar = '.';
		internal const string Space = " ";
		internal const char SpaceChar = ' ';
		internal static Type IntType = typeof(int);
		internal static Type LongType = typeof(long);
		internal static Type GuidType = typeof(Guid);
		internal static Type BoolType = typeof(bool);
		internal static Type ByteType = typeof(Byte);
		internal static Type ObjType = typeof(object);
		internal static Type DobType = typeof(double);
		internal static Type FloatType = typeof(float);
		internal static Type ShortType = typeof(short);
		internal static Type DecType = typeof(decimal);
		internal static Type StringType = typeof(string);
		internal static Type DateType = typeof(DateTime);
		internal static Type ByteArrayType = typeof(byte[]);
		internal static Type DynamicType = typeof(ExpandoObject);
		internal static Type Dicii = typeof(KeyValuePair<int, int>);
		internal static Type DicIS = typeof(KeyValuePair<int, string>);
		internal static Type DicSi = typeof(KeyValuePair<string, int>);
		internal static Type DicSS = typeof(KeyValuePair<string, string>);
		internal static Type DicOO = typeof(KeyValuePair<object, object>);
		internal static Type DicSo = typeof(KeyValuePair<string, object>);
		internal static Type DicArraySS = typeof(Dictionary<string, string>);
		internal static Type DicArraySO = typeof(Dictionary<string, object>);

	 
	}//end UtilConstants

}//end namespace FD.Tiny.DataAccess