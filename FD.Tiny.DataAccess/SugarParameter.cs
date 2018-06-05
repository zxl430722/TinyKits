///////////////////////////////////////////////////////////
//  SugarParameter.cs
//  Implementation of the Class SugarParameter
//  Generated by Enterprise Architect
//  Created on:      05-6��-2018 16:02:53
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.Common;
using System.Data;

namespace FD.Tiny.DataAccess {
	public class SugarParameter : DbParameter {

		public int _Size;

		public SugarParameter(){

		}

		/// 
		/// <param name="name"></param>
		/// <param name="value"></param>
		public SugarParameter(string name, object value){

			this.Value = value;
			this.ParameterName = name;
			if (value != null)
			{
			    SettingDataType(value.GetType());
			}
		}

		/// 
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <param name="type"></param>
		public SugarParameter(string name, object value, Type type){

			this.Value = value;
			this.ParameterName = name;
			SettingDataType(type);
		}

		/// 
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <param name="type"></param>
		/// <param name="direction"></param>
		public SugarParameter(string name, object value, Type type, ParameterDirection direction){

			this.Value = value;
			this.ParameterName = name;
			this.Direction = direction;
			SettingDataType(type);
		}

		/// 
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <param name="type"></param>
		/// <param name="direction"></param>
		/// <param name="size"></param>
		public SugarParameter(string name, object value, Type type, ParameterDirection direction, int size){

			this.Value = value;
			this.ParameterName = name;
			this.Direction = direction;
			this.Size = size;
			SettingDataType(type);
		}

		/// 
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <param name="isOutput"></param>
		public SugarParameter(string name, object value, bool isOutput){

			this.Value = value;
			this.ParameterName = name;
			if (isOutput)
			{
			    this.Direction = ParameterDirection.Output;
			}
		}

		public bool IsRefCursor{
			get; set;
		}

		/// 
		/// <param name="type"></param>
		private void SettingDataType(Type type){

			if (type == UtilConstants.ByteArrayType)
			{
			    this.DbType = System.Data.DbType.Binary;
			}
			else if (type == UtilConstants.GuidType)
			{
			    this.DbType = System.Data.DbType.Guid;
			}
			else if (type == UtilConstants.IntType)
			{
			    this.DbType = System.Data.DbType.Int32;
			}
			else if (type == UtilConstants.ShortType)
			{
			    this.DbType = System.Data.DbType.Int16;
			}
			else if (type == UtilConstants.LongType)
			{
			    this.DbType = System.Data.DbType.Int64;
			}
			else if (type == UtilConstants.DateType)
			{
			    this.DbType = System.Data.DbType.DateTime;
			}
			else if (type == UtilConstants.DobType)
			{
			    this.DbType = System.Data.DbType.Double;
			}
			else if (type == UtilConstants.DecType)
			{
			    this.DbType = System.Data.DbType.Decimal;
			}
			else if (type == UtilConstants.ByteType)
			{
			    this.DbType = System.Data.DbType.Byte;
			}
			else if (type == UtilConstants.FloatType)
			{
			    this.DbType = System.Data.DbType.Single;
			}
			else if (type == UtilConstants.BoolType)
			{
			    this.DbType = System.Data.DbType.Boolean;
			}
			else if (type == UtilConstants.StringType)
			{
			    this.DbType = System.Data.DbType.String;
			}
		}

		public override System.Data.DbType DbType{
			get; set;
		}

		public override ParameterDirection Direction{
			get; set;
		}

		public override bool IsNullable{
			get; set;
		}

		public override string ParameterName{
			get; set;
		}

		public override int Size{
			get
						            {
						                if (_Size == 0 && Value != null)
						                {
						                    var isByteArray = Value.GetType() == UtilConstants.ByteArrayType;
						                    if (isByteArray)
						                        _Size = -1;
						                    else
						                    {
						                        var length = Value.ToString().Length;
						                        _Size = length < 4000 ? 4000 : -1;
		
						                    }
						                }
						                if (_Size == 0)
						                    _Size = 4000;
						                return _Size;
						            }
						            set
						            {
						                _Size = value;
						            }
		}

		public override string SourceColumn{
			get; set;
		}

		public override bool SourceColumnNullMapping{
			get; set;
		}

		public string UdtTypeName{
			get;
						            set;
		}

		public override object Value{
			get; set;
		}

		public Dictionary<string, object> TempDate{
			get; set;
		}

		public override void ResetDbType(){

			this.DbType = System.Data.DbType.String;
		}
	 

	}//end SugarParameter

}//end namespace FD.Tiny.DataAccess