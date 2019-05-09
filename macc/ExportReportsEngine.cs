using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace macc
{
    class ExportReportsEngine
    {

        public ExportReportsEngine()
        { }
        public void ExportExcel()
        {
            try
            {
                DataTable table = new DataTable("Donors");
                table.Columns.Add("cname");
                table.Columns.Add("Blood Groups");
                table.Rows.Add("Manoj", "A+");
                table.Rows.Add("Adidev", "B+");


                using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
                {
                    string folderPath = "d:/Excel/";
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    wb.Worksheets.Add(table, "Donors");
                    wb.Worksheet(1).Cells("A1:C1").Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.Green;
                    for (int i = 1; i <= table.Rows.Count; i++)
                    {
                        string cellRange = string.Format("A{0}:C{0}", i + 1);
                        if (i % 2 != 0)
                        {
                            wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.GreenYellow;
                        }
                        else
                        {
                            wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.Yellow;
                        }
                    }
                    //Adjust widths of Columns.
                    wb.Worksheet(1).Columns().AdjustToContents();

                    //Save the Excel file.
                    wb.SaveAs(folderPath + "SampleExport.xlsx");

                }
            }
            catch (Exception ee)
            {

            }
        }
        //public void CreateExcelFile()
        //{
        //    try
        //    {

        //        var app = new Microsoft.Office.Interop.Excel.Application();
        //        if (app == null)
        //        {
        //            Console.WriteLine("Excel is not installed in the system...");
        //            return;
        //        }
        //        object misValue = System.Reflection.Missing.Value;
        //        var workbook = new Workbook();
        //        workbook = app.Application.Workbooks.Add(misValue);
        //        var xlWorkSheet = workbook.Worksheets.get_Item(1);
        //        xlWorkSheet.Cells[1, 1] = "ID";
        //        xlWorkSheet.Cells[1, 2] = "Name";
        //        xlWorkSheet.Cells[2, 1] = "1001";
        //        xlWorkSheet.Cells[2, 2] = "Ramakrishna";
        //        xlWorkSheet.Cells[3, 1] = "1002";
        //        xlWorkSheet.Cells[3, 2] = "Praveenkumar";
        //        workbook.SaveAs("D:/myxl.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue,
        //        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

        //        workbook.Close();

        //        app.Quit();



        //        Console.BackgroundColor = ConsoleColor.DarkBlue;
        //        Console.WriteLine("Excel file created successfully...");
        //        Console.BackgroundColor = ConsoleColor.Black;
        //    }
        //    catch (Exception e)
        //    {

        //        MessageBox.Show(e.Message.ToString());
        //    }
        //}
        public void ExcelExport(string filename, ListView list)
        {

            try
            {
                DataTable table = new DataTable("report");
                using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
                {
                    if (list.Items.Count > 0)
                    {
                        string folderPath = "d:/Excel/";
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        //Collecting Columns
                        foreach (System.Windows.Forms.ColumnHeader colheader in list.Columns)
                        {
                            if (colheader.Text.Trim().Length>=1 )
                            {
                                table.Columns.Add(colheader.Text.ToString());
                            }
                        }
                        //adding rows
                        foreach (var x in table.Columns)
                        {
                            Console.WriteLine(x.ToString());
                        }
                        List<string> rowvalues = new List<string>();
                        foreach (ListViewItem it in list.Items)
                        {

                            rowvalues.Clear();
                            for (int j = 1; j <= table.Columns.Count  ; j++)
                            {
                                rowvalues.Add(it.SubItems[j].Text.ToString());

                            }
                            table.Rows.Add(rowvalues.ToArray());
                        }

                        //Export

                        wb.Worksheets.Add(table, "report");
                        wb.Worksheet(1).Cells("A1:g1").Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.Green;
                        //wb.Worksheet(1).Range("A1:C2").SetAutoFilter();
                        for (int i = 1; i <= table.Rows.Count; i++)
                        {
                            string cellRange = string.Format("A{0}:g{0}", i + 1);
                            if (i % 2 != 0)
                            {
                                wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.GreenYellow;
                            }
                            else
                            {
                                wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.Yellow;
                            }
                        }

                        //Adjust widths of Columns.
                        wb.Worksheet(1).Columns().AdjustToContents();

                        //Save the Excel file.
                        wb.SaveAs(folderPath + filename.Trim());
                        MessageBox.Show("Report Exported to D:/Excel");

                    }
                    else
                    {
                        MessageBox.Show("Nothing to Export");
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }
    }
}
