using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTableExt;

namespace Game
{
    internal class Table
    {
        public Table(string[] args)
        {
            List<string> tableDataColumn = Columns(args);
            List<object> tableDataRow = Rows(args);
            
            ConsoleTableBuilder
                .From(tableDataRow)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .WithColumn(tableDataColumn)
                
                .ExportAndWriteLine();
            return;
        }

        static List<object> Rows(string[] args)
        {
            List<object> tableDataRow = new List<object>();
            tableDataRow.AddRange(args);
            return tableDataRow;
        }
        static List<string> Columns(string[] args)
        {
            List<string> tableDataColumn = new List<string>();
            tableDataColumn.Add("PC / User");
            tableDataColumn.AddRange(args);
            return tableDataColumn;
        }
    }
}