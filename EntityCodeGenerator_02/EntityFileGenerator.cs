using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;

public class EntityFileGenerator
{
    public static string CreateEntityFile(string projectName, string server, string databaseName, string tableName, string outputPath)
                         {
        // Construct the connection string.
        string connectionString = $"Server={server};Database={databaseName};Integrated Security=True;";

        // Query to get the table columns from the database schema.
        string query = $@"
            SELECT COLUMN_NAME, DATA_TYPE
            FROM INFORMATION_SCHEMA.COLUMNS
            WHERE TABLE_NAME = '{tableName}'
            ORDER BY ORDINAL_POSITION;
        ";

        // Initialize StringBuilder to build the C# class content.
        StringBuilder classContent = new StringBuilder();
        classContent.AppendLine("using System;");
        classContent.AppendLine("using System.ComponentModel.DataAnnotations;");
        classContent.AppendLine("using System.ComponentModel.DataAnnotations.Schema;");
        classContent.AppendLine();
        classContent.AppendLine($"namespace {projectName}.Entities");
        classContent.AppendLine("{");
        classContent.AppendLine($"\tpublic class {tableName}");
        classContent.AppendLine("\t{");

        try
        {
            // Connect to the database and retrieve the column information.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string columnName = reader.GetString(0);
                        string dataType = reader.GetString(1);

                        // Create a C# property for each column.
                        string csharpType = MapSqlTypeToCSharpType(dataType);
                        classContent.AppendLine($"\t\tpublic {csharpType} {columnName} {{ get; set; }}");
                    }
                }
            }

            // Close the class definition.
            classContent.AppendLine("\t}");
            classContent.AppendLine("}");

            // Write the generated class to a file.
             File.WriteAllText(outputPath, classContent.ToString());
            Console.WriteLine($"Entity class generated successfully: {outputPath}");
            return classContent.ToString(); 
        }
        catch (Exception ex)
        {
            return ($"Error generating entity file: {ex.Message}");
            
        }
    }

    private static string MapSqlTypeToCSharpType(string sqlType)
    {
        switch (sqlType.ToLower())
        {
            case "int":
                return "int";
            case "varchar":
            case "nvarchar":
            case "text":
                return "string";
            case "datetime":
            case "date":
                return "DateTime";
            case "bit":
                return "bool";
            case "decimal":
            case "money":
            case "numeric":
                return "decimal";
            case "float":
                return "float";
            case "uniqueidentifier":
                return "Guid";
            default:
                return "string"; // Default to string for unsupported types
        }
    }
}
