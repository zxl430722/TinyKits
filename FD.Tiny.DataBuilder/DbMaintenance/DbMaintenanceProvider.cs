///////////////////////////////////////////////////////////
//  DbMaintenacneProvider.cs
//  Implementation of the Class DbMaintenacneProvider
//  Generated by Enterprise Architect
//  Created on:      14-6��-2018 10:35:34
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.DataBuilder.Data;
using FD.Tiny.DataBuilder;
using FD.Tiny.DataAccess;
using System.Linq;

namespace FD.Tiny.DataBuilder {
	public abstract class DbMaintenanceProvider : IDbMaintenance {
             
        public DbClient Context { get; set; }

        public DbMaintenanceProvider(){

		}


        public virtual List<DbTable> GetTableInfoList()
        {
            var result = new List<DbTable>();
            result = this.Context.Ado.SqlQuery<DbTable>(this.GetTableInfoListSql);
            return result;
        }

        public List<DbColumn> GetColumnInfosByTableName(string tableName)
        {
            var sql = string.Format(this.GetColumnInfosByTableNameSql, tableName);
            return this.Context.Ado.SqlQuery<DbColumn>(sql).GroupBy(it => it.name).Select(it => it.First()).ToList();
        }

        /// 
        /// <param name="dbTable"></param>
        public bool CreateTable(DbTable dbTable){
            var sql = GetCreateTableSql(dbTable.name, dbTable.columns.ToList());
            this.Context.Ado.ExecuteCommand(sql);
			return true;
		}

		/// 
		/// <param name="tableName"></param>
		public bool DropTable(string tableName){

            var sql = string.Format(this.DropTableSql, tableName);
            this.Context.Ado.ExecuteCommand(sql);
            return true;
        }

		/// 
		/// <param name="tableName"></param>
		/// <param name="column"></param>
		public bool AddColumn(string tableName, DbColumn column){

            var sql = GetAddColumnSql(tableName, column);
            this.Context.Ado.ExecuteCommand(sql);
            return true;
        }

		/// 
		/// <param name="tableName"></param>
		/// <param name="column"></param>
		public bool AlterColumn(string tableName, DbColumn column){
            var sql = GetAlterColumnSql(tableName, column);
            this.Context.Ado.ExecuteCommand(sql);
            return true;
        }

		/// 
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		public bool DropColumn(string tableName, string columnName){

            var sql = string.Format(this.DropColumnToTableSql, tableName, columnName);
            this.Context.Ado.ExecuteCommand(sql);
            return true;
        }

		/// 
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		public bool AddPrimaryKey(string tableName, string columnName){
            var sql = string.Format(this.AddPrimaryKeySql, tableName, string.Format("PK_{0}_{1}", tableName, columnName),
                         columnName);
            this.Context.Ado.ExecuteCommand(sql);
            return true;
        }

		/// 
		/// <param name="seqName"></param>
		public bool CreateSequence(string seqName){
            var seq = new DbSequence(seqName);
            var sql = string.Format(this.CreateSequenceSql, seq.name, seq.min_value, seq.max_value, seq.start_with,
                seq.increment_by, seq.cache);
            this.Context.Ado.ExecuteCommand(sql);
            return true;
        }

		/// 
		/// <param name="tableName"></param>
		/// <param name="constraintName"></param>
		public bool DropConstraint(string tableName, string constraintName){
            var sql = string.Format(this.DropConstraintSql, tableName, constraintName);
            this.Context.Ado.ExecuteCommand(sql);
            return true;
        }

		/// 
		/// <param name="seqName"></param>
		public bool DropSequence(string seqName){
            var sql = string.Format(this.DropSequenceSql, seqName);
            this.Context.Ado.ExecuteCommand(sql);
            return true;
        }

        /// 
        /// <param name="tableName"></param>
        public virtual bool IsAnyTable(string tableName)
        {
            var tables = GetTableInfoList();
            if (tables == null)
            {
                return false;
            }
            return tables.Any(t => t.name.Equals(tableName, StringComparison.CurrentCultureIgnoreCase));
        }

        #region DML        
        protected abstract string GetTableInfoListSql { get; }
        protected abstract string GetColumnInfosByTableNameSql { get; }
        #endregion

        protected abstract string AddColumnToTableSql{
			get;
		}

		protected abstract string CreateTableSql{
			get;
		}

		/// 
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		public bool IsAnyColumn(string tableName, string columnName){

			return false;
		}

		protected abstract string AlterColumnToTableSql{
			get;
		}

		protected abstract string CreateTableColumnSql{
			get;
		}

		/// 
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		public bool IsPrimaryKey(string tableName, string columnName){

			return false;
		}

		protected abstract string DropTableSql{
			get;
		}

		protected abstract string DropColumnToTableSql{
			get;
		}

		protected abstract string AddPrimaryKeySql{
			get;
		}

		protected abstract string CreateTableNull{
			get;
		}

		protected abstract string CreateTableNotNull{
			get;
		}

		protected abstract string CreateTablePrimaryKey{
			get;
		}

		protected abstract string CreateTableIdentity{
			get;
		}

        /// 
        /// <param name="tableName"></param>
        /// <param name="columns"></param>
        private string GetCreateTableSql(string tableName, IList<DbColumn> columns)
        {
            List<string> columnArray = new List<string>();
            //check
            foreach (var column in columns)
            {
                var columnName = column.name;
                var dataType = column.data_type;
                var dataSize = column.length > 0 ? string.Format("({0})", column.length) : null;

                if (column.precision > 0)
                    dataSize = string.Format("({0},{1})", column.length, column.precision);

                var nullType = column.is_nullable ? this.CreateTableNull : this.CreateTableNotNull;
                string primaryKey = column.is_primary ? this.CreateTablePrimaryKey : null;
                string identity = "";
                string addColumns = string.Format(this.CreateTableColumnSql, columnName, dataType, dataSize,
                    nullType, primaryKey, identity);
                columnArray.Add(addColumns);
            }
            string tableString = string.Format(this.CreateTableSql, tableName, string.Join(",", columnArray));
            return tableString;
        }

        /// 
        /// <param name="tableName"></param>
        /// <param name="column"></param>
        private string GetAddColumnSql(string tableName, DbColumn column)
        {
            var columnName = column.name;
            var dataType = column.data_type;
            var dataSize = column.length > 0 ? string.Format("({0})", column.length) : null;
            if (column.precision > 0)
                dataSize = string.Format("({0},{1})", column.precision, column.scale);
            var nullType = column.is_nullable ? this.CreateTableNull : this.CreateTableNotNull;
            string primaryKey = column.is_primary ? this.CreateTablePrimaryKey : null;
            string identity = "";
            var addColumnString = string.Format(this.AddColumnToTableSql, tableName, columnName, dataType, dataSize,
                nullType, primaryKey, identity);
            return addColumnString;
        }

        /// 
        /// <param name="tableName"></param>
        /// <param name="column"></param>
        private string GetAlterColumnSql(string tableName, DbColumn column)
        {
            var columnName = column.name;
            var dataType = column.data_type;
            var dataSize = column.length > 0 ? string.Format("({0})", column.length) : null;
            if (column.precision > 0)
                dataSize = string.Format("({0},{1})", column.precision, column.scale);
            var nullType = column.is_nullable ? this.CreateTableNull : this.CreateTableNotNull;
            string primaryKey = column.is_primary ? this.CreateTablePrimaryKey : null;
            string identity = "";
            var alterColumnString = string.Format(this.AlterColumnToTableSql, tableName, columnName, dataType, dataSize,
                nullType,
                primaryKey, identity);
            return alterColumnString;
        }     

        protected abstract string DropConstraintSql{
			get;
		}

		protected abstract string CreateSequenceSql{
			get;
		}

		protected abstract string DropSequenceSql{
			get;
		}
        
    }//end DbMaintenacneProvider

}//end namespace FD.Tiny.DataBuilder