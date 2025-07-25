﻿using EventMgrLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;
using VM.Start.Common.Helper;
using VM.Start.Events;

namespace VM.Start.DataAccess
{
    /// <summary>
    /// SQLite数据库帮助类
    /// </summary>
    public class SQLiteHelper
    {
        private static SQLiteHelper _instance;
        private static readonly object _lockObj = new object();
        private SQLiteConnection _connection;
        private SQLiteCommand _command;
        private DbDataReader _dataReader;

        public static SQLiteHelper Ins
        {
            get
            {
                //最外层判断防止已经初始化过后，再次访问对象时依旧会造成lock的调用避免性能损耗。
                if (_instance == null)
                {
                    lock (_lockObj)
                    {
                        if (_instance == null)
                        {
                            _instance = new SQLiteHelper();
                        }
                    }
                }
                return _instance;
            }
        }

        private SQLiteHelper()
        {
            EventMgr.Ins.GetEvent<SoftwareExitEvent>().Subscribe(CloseConnection);
        }

        public void Init()
        {
            try
            {
                _connection = new SQLiteConnection($"data source={FilePaths.ConfigFilePath}VMDatabase.db");
                _connection.Open();
            }
            catch (Exception e)
            {
            }
        }
        public DataTable GetQueryDatas(string queryString)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SQLiteDataAdapter Adapter = new SQLiteDataAdapter(queryString, _connection);
                Adapter.Fill(dataTable);
            }
            catch (Exception e)
            {
            }
            return dataTable;
        }
        /// <summary>
        /// 执行Sql命令
        /// </summary>
        /// <returns>The query.</returns>
        /// <param name="queryString">Sql命令字符串</param>
        public async Task<DbDataReader> ExecuteQuery(string queryString)
        {
            try
            {
                _command = _connection.CreateCommand();
                _command.CommandText = queryString;
                _dataReader = await _command.ExecuteReaderAsync();
            }
            catch (Exception e)
            {
            }
            return _dataReader;
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void CloseConnection()
        {
            //销毁Commend
            if (_command != null)
            {
                _command.Cancel();
            }
            _command = null;
            //销毁Reader
            if (_dataReader != null)
            {
                _dataReader.Close();
            }
            _dataReader = null;
            //销毁Connection
            if (_connection != null)
            {
                _connection.Close();
            }
            _connection = null;
        }

        /// <summary>
        /// 读取整张数据表
        /// </summary>
        /// <returns>The full table.</returns>
        /// <param name="tableName">数据表名称</param>
        public async Task<DbDataReader> ReadFullTable(string tableName)
        {
            string queryString = $"SELECT * FROM { tableName }";
            return await ExecuteQuery(queryString);
        }

        public async Task InsertValueRange(string tableName, List<string[]> values)
        {
            var transaction = _connection.BeginTransaction();
            foreach (var value in values)
            {
                await InsertValues(tableName, value);
            }
            transaction.Commit();
        }

        /// <summary>
        /// 向指定数据表中插入数据
        /// </summary>
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="values">插入的数值</param>
        public async Task<DbDataReader> InsertValues(string tableName, string[] values)
        {
            try
            {
                //获取数据表中字段数目
                var reader = await ReadFullTable(tableName);
                int fieldCount = reader.FieldCount;
                //当插入的数据长度不等于字段数目时引发异常
                if (values.Length != fieldCount)
                {
                    throw new SQLiteException("values.Length!=fieldCount");
                }
                string queryString = "INSERT INTO " + tableName + " VALUES (" + "'" + values[0] + "'";
                var queryStr = new StringBuilder();
                queryStr.Append(queryString);
                for (int i = 1; i < values.Length; i++)
                {
                    queryStr.Append(", " + "'" + values[i] + "'");
                }
                queryStr.Append(" )");
                return await ExecuteQuery(queryStr.ToString());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 更新指定数据表内的数据
        /// </summary>
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colValues">字段名对应的数据</param>
        /// <param name="key">关键字</param>
        /// <param name="value">关键字对应的值</param>
        /// <param name="operation">运算符：=,<,>,...，默认“=”</param>
        public async Task<DbDataReader> UpdateValues(string tableName, string[] colNames, string[] colValues, string key, string value, string operation = "=")
        {
            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length)
            {
                throw new SQLiteException("colNames.Length!=colValues.Length");
            }
            string queryString = $"UPDATE { tableName } SET  { colNames[0] } = '{ colValues[0] }' ";
            var updateStr = new StringBuilder();
            updateStr.Append(queryString);
            for (int i = 1; i < colValues.Length; i++)
            {
                updateStr.Append($", { colNames[i] } = '{ colValues[i] }'");
            }
            updateStr.Append($"WHERE { key } { operation } '{value}'");
            return await ExecuteQuery(updateStr.ToString());
        }

        /// <summary>
        /// 删除指定数据表内的数据
        /// </summary>
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colValues">字段名对应的数据</param>
        public async Task<DbDataReader> DeleteValuesOR(string tableName, string[] colNames, string[] colValues, string[] operations)
        {
            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length || operations.Length != colNames.Length || operations.Length != colValues.Length)
            {
                throw new SQLiteException("colNames.Length!=colValues.Length || operations.Length!=colNames.Length || operations.Length!=colValues.Length");
            }
            var queryStr = new StringBuilder();
            queryStr.Append("DELETE FROM " + tableName + " WHERE " + colNames[0] + operations[0] + "'" + colValues[0] + "'");
            for (int i = 1; i < colValues.Length; i++)
            {
                queryStr.Append("OR " + colNames[i] + operations[0] + "'" + colValues[i] + "'");
            }
            return await ExecuteQuery(queryStr.ToString());
        }

        /// <summary>
        /// 删除指定数据表内的数据
        /// </summary>
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colValues">字段名对应的数据</param>
        public async Task<DbDataReader> DeleteValuesAND(string tableName, string[] colNames, string[] colValues, string[] operations)
        {
            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length || operations.Length != colNames.Length || operations.Length != colValues.Length)
            {
                throw new SQLiteException("colNames.Length!=colValues.Length || operations.Length!=colNames.Length || operations.Length!=colValues.Length");
            }
            var queryStr = new StringBuilder();
            queryStr.Append("DELETE FROM " + tableName + " WHERE " + colNames[0] + operations[0] + "'" + colValues[0] + "'");
            for (int i = 1; i < colValues.Length; i++)
            {
                queryStr.Append(" AND " + colNames[i] + operations[i] + "'" + colValues[i] + "'");
            }
            return await ExecuteQuery(queryStr.ToString());
        }
    }


}
