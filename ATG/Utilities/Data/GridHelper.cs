using System;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;

namespace ATG.Utilities.Data
{
    public class GridHelper
    {
        private GridHelper() { }

        public static DataTable BO_Array_ConvertToDataTable(Object[] array)
        {
            PropertyInfo[] properties = array.GetType().GetElementType().GetProperties();
            DataTable dt = CreateDataTable(properties);

            if (array.Length != 0)
            {
                foreach(object o in array)
                        FillData(properties, dt, o);
            }
            
            return dt;
        }

        public static Type GetNonNullableType( Type inType )
        {
            if ( inType != null )
            {
                if ( inType.FullName.StartsWith( "System.Nullable`1[[" ) )
                {
                    string typeName = inType.FullName.Replace( "System.Nullable`1[[", "" ).Replace( "]]", "" );
                    return Type.GetType(typeName);
                }
            }

            return inType;
        }

        //Business Objects are created with properties that are collections of child Business Objects
        //so these are filtered out by property name. 
        //SMM - Todo - Modify to determine if it is a collection with check other than name and add
        //methods for creating a dataset that populates several tables.
        private static DataTable CreateDataTable(PropertyInfo[] properties)
        {
                DataTable dt = new DataTable();
                DataColumn dc = null;


                foreach(PropertyInfo pi in properties)
                {
                    if ( !pi.PropertyType.BaseType.Name.Contains( "Collection" ) )
                    {
                        dc = new DataColumn();
                        dc.ColumnName = pi.Name;
                        dc.DataType = GetNonNullableType( pi.PropertyType );

                        dt.Columns.Add( dc );
                    }
                }


                return dt;
        }

        private static void FillData(PropertyInfo[] properties, DataTable dt, Object o)
        {
                DataRow dr = dt.NewRow();

                foreach ( PropertyInfo pi in properties )
                {
                    if ( !pi.PropertyType.BaseType.Name.Contains( "Collection" ) )
                    {
                        if ( null != pi.GetValue( o, null ) )
                            dr[pi.Name] = pi.GetValue( o, null );
                        else
                            dr[pi.Name] = DBNull.Value;
                    }
                }

                dt.Rows.Add(dr);        
        }

    }
}
