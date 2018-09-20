///////////////////////////////////////////////////////////
//  ApiParameter.cs
//  Implementation of the Class ApiParameter
//  Generated by Enterprise Architect
//  Created on:      20-9��-2018 10:18:41
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace FD.Tiny.FormBuilder.Api {
	public class ApiParameter {

		public int parameter_id{
			get;  set;
		}

		public int api_id{
			get;  set;
		}

		public string paramater_name{
			get;  set;
		}

		public string paramater_name_chs{
			get;  set;
		}

		public string remark{
			get;  set;
		}

		public int data_type{
			get;  set;
		}

		public bool is_required{
			get;  set;
		}

	}//end ApiParameter

}//end namespace Api