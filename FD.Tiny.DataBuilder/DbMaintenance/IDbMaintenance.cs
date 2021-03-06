///////////////////////////////////////////////////////////
//  IDbMaintenance.cs
//  Implementation of the Interface IDbMaintenance
//  Generated by Enterprise Architect
//  Created on:      14-6月-2018 10:35:34
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.DataBuilder.Data;
namespace FD.Tiny.DataBuilder {
	public interface IDbMaintenance  {

        DbClient Context { get; set; }

        #region DML        

        List<DbTable> GetTableInfoList();

        List<DbColumn> GetColumnInfosByTableName(string tableName);

        #endregion  

        #region DDL
        /// <summary>
        /// 创建数据库表
        /// </summary>
        /// <param name="dbTable"></param>
        bool CreateTable(DbTable dbTable);

		/// <summary>
		/// 卸载数据库表
		/// </summary>
		/// <param name="tableName"></param>
		bool DropTable(string tableName);

		/// <summary>
		/// 为表添加列
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="column"></param>
		bool AddColumn(string tableName, DbColumn column);

		/// <summary>
		/// 为表修改列
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="column"></param>
		bool AlterColumn(string tableName, DbColumn column);

		/// 
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		bool DropColumn(string tableName, string columnName);

		/// 
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		bool AddPrimaryKey(string tableName, string columnName);

		/// 
		/// <param name="tableName"></param>
		/// <param name="constraintName"></param>
		bool DropConstraint(string tableName, string constraintName);

		/// 
		/// <param name="seqName"></param>
		bool CreateSequence(string seqName);

		/// 
		/// <param name="seqName"></param>
		bool DropSequence(string seqName);
        #endregion

        #region Check
        /// 
        /// <param name="tableName"></param>
        bool IsAnyTable(string tableName);

		/// 
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		bool IsAnyColumn(string tableName, string columnName);

		/// 
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		bool IsPrimaryKey(string tableName, string columnName);
        #endregion
    }//end IDbMaintenance

}//end namespace FD.Tiny.DataBuilder