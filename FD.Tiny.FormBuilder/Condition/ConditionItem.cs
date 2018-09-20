///////////////////////////////////////////////////////////
//  ConditionItem.cs
//  Implementation of the Class ConditionItem
//  Generated by Enterprise Architect
//  Created on:      20-9��-2018 14:20:54
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	public class ConditionItem {

		/// <summary>
		/// ȡֵ��ʽ
		/// </summary>
		public ValueMethod value_method{
			get;  set;
		}

		/// <summary>
		/// �滻ֵ
		/// </summary>
		public string inner_value{
			get;  set;
		}

		/// <summary>
		/// ����Դ����
		/// </summary>
		public DataSource data_source_config{
			get;  set;
		}

		/// <summary>
		/// ���ݿ�����
		/// </summary>
		public FD.Tiny.FormBuilder.Database.DatabaseConfig data_base_config{
			get;  set;
		}

	}//end ConditionItem

}//end namespace FD.Tiny.FormBuilder