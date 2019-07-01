using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace ProjetoAutomacaoBDD.Helpers
{
    public class ExcelReaderHelper
    {

        /// <summary>
        /// Execute the query in the file to retreive the specified data
        /// </summary>
        /// <param name="excelFilePath">Path to the excel file</param>
        /// <param name="queryCommand">The query to be executed in the sheet</param>
        /// <returns>The result dataset</returns>
        public static DataSet QueryFromSheet(string excelFilePath, string queryCommand)
        {
            return SheetReader(excelFilePath, "default", queryCommand);
        }

        /// <summary>
        /// Read the specified file
        /// </summary>
        /// <param name="excelFilePath">Path to the excek file</param>
        /// <param name="sheetName">Name of the sheet to be read</param>
        /// <param name="queryCommand">The query to be executed in the sheet</param>
        /// <returns>The result dataset</returns>
        public static DataSet SheetReader(string excelFilePath, string sheetName, string queryCommand)
        {
            DataSet dataSet;
            dataSet = new DataSet();

            if (!File.Exists(excelFilePath))
                throw new Exception(string.Format("Arquivo não encontrado: {0}", excelFilePath), new FileNotFoundException());

            string connectionString =
            string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";", excelFilePath);

            using (var connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var command = new OleDbCommand(queryCommand, connection);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    adapter.Fill(dataSet, sheetName);
                    if (adapter == null)
                        throw new Exception(string.Format("Nenhum dado retornado do arquivo: {0}", excelFilePath));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return dataSet;
        }
    }
}
