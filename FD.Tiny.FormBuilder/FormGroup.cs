///////////////////////////////////////////////////////////
//  FormGroup.cs
//  Implementation of the Class FormGroup
//  Generated by Enterprise Architect
//  Created on:      20-9月-2018 10:13:55
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace FD.Tiny.FormBuilder {
	/// <summary>
	/// 表单分组类
	/// </summary>
	public class FormGroup {

		/// <summary>
		/// 分组名称
		/// </summary>
		public string group_name{
			get;  set;
		}

		/// <summary>
		/// 分组排序
		/// </summary>
		public int group_sort{
			get;  set;
		}

		/// <summary>
		/// 标签集合
		/// </summary>
		public IList<Label> label_list{
			get;  set;
		}

	}//end FormGroup

}//end namespace FD.Tiny.FormBuilder