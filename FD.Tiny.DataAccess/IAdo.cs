///////////////////////////////////////////////////////////
//  IAdo.cs
//  Implementation of the Interface IAdo
//  Generated by Enterprise Architect
//  Created on:      05-6��-2018 16:02:30
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Reflection;

namespace FD.Tiny.DataAccess {
	public interface IAdo  {

        string SqlParameterKeyWord { get; }
        IDbConnection Connection { get; set; }
        IDbTransaction Transaction { get; set; }

        CommandType CommandType { get; set; }
        bool IsEnableLogEvent { get; set; }

        bool IsClearParameters { get; set; }
        int CommandTimeOut { get; set; }


        IDataAdapter GetAdapter();

        IDbCommand GetCommand(string sql, params SugarParameter[] parameters);

        void SetCommandToAdapter(IDataAdapter adapter, IDbCommand command);

        void Dispose();

        /// 
        /// <param name="obj"></param>
        SugarParameter[] GetParameters(object parameters, PropertyInfo[] propertyInfo = null);

        DataSet GetDataSetAll(string sql, object parameters);
        DataSet GetDataSetAll(string sql, params SugarParameter[] parameters);


        DataTable GetDataTable(string sql, object parameters);
        /// 
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        DataTable GetDataTable(string sql, params SugarParameter[] parameters);

        int ExecuteCommand(string sql, object parameters);

        /// 
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        int ExecuteCommand(string sql, params SugarParameter[] parameters);

		void Open();

		void Close();

		void CheckConnection();

		void BeginTran();

        void Rollback();

		void Commit();

        IAdo UseStoredProcedure();

    }//end IAdo

}//end namespace FD.Tiny.DataAccess