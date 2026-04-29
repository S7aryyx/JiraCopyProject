using System;
using System.Data;
using System.Windows.Forms;

namespace JiraCopyProject.WinForms.Helpers
{
    public static class UIHelpers
    {
        public static DateTime? SafeToDateTime(object value)
        {
            if (value == null || value == DBNull.Value)
                return null;
            if (value is DateOnly dateOnly)
                return dateOnly.ToDateTime(TimeOnly.MinValue);
            if (value is DateTime dateTime)
                return dateTime;
            if (DateTime.TryParse(value.ToString(), out DateTime parsed))
                return parsed;
            return null;
        }
        public static string FormatDateString(object dateObj)
        {
            var dt = SafeToDateTime(dateObj);
            return dt.HasValue ? dt.Value.ToString("yyyy-MM-dd") : "—";
        }
        public static void SetDateColumnFormat(DataGridView dgv, string columnName)
        {
            if (dgv.Columns.Contains(columnName))
                dgv.Columns[columnName].DefaultCellStyle.Format = "yyyy-MM-dd";
        }
    }
}