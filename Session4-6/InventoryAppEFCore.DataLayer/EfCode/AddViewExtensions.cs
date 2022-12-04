using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryAppEFCore.DataLayer.EfCode
{
    public static class AddViewExtensions
    {
        public static void AddViewViaSql<TView>(                  
            this MigrationBuilder migrationBuilder,               
            string viewName,                                      
            string tableName,                                     
            string whereSql)                                      
            where TView : class                                   
        {
            if (!migrationBuilder.IsSqlServer())                  
                throw new NotImplementedException("This command only works for SQL Server");

            var selectNamesString = string.Join(", ",             
                typeof(TView).GetProperties()                     
                .Select(x => x.Name));                            

            var viewSql =
                $"CREATE OR ALTER VIEW {viewName} AS " +          
                $"SELECT {selectNamesString} FROM {tableName} " + 
                $"WHERE {whereSql}";                              

            migrationBuilder.Sql(viewSql);                        
        }
    }
}
