using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemBox.Spreadsheet;

namespace InvoiceGenerator
{
    class Template
    {

        public void setTemplateFormat(int whatTemplate, ref ExcelFile workbook)
        {
            if (whatTemplate == 1)
            {               
                // Row 1 Text/Cell Size and boldness
                workbook.Worksheets[0].Rows[0].Height = (workbook.Worksheets[0].Rows[0].Height) + 2000;
                workbook.Worksheets[0].Columns[0].Width = (workbook.Worksheets[0].Columns[0].Width) + 500;
                workbook.Worksheets[0].Rows[0].Style.Font.Size = 560;
                workbook.Worksheets[0].Rows[0].Style.Font.Weight = ExcelFont.BoldWeight;
                workbook.Worksheets[0].Columns[3].Width = (workbook.Worksheets[0].Columns[0].Width) + 500;
                
                // Alignments
                workbook.Worksheets[0].Columns[0].Style.HorizontalAlignment = HorizontalAlignmentStyle.Left;
                workbook.Worksheets[0].Cells[0, 0].Style.VerticalAlignment = VerticalAlignmentStyle.Center;
                workbook.Worksheets[0].Columns[6].Style.HorizontalAlignment = HorizontalAlignmentStyle.Right;
                workbook.Worksheets[0].Cells.GetSubrange("A20:G29").Style.VerticalAlignment = VerticalAlignmentStyle.Center;
                workbook.Worksheets[0].Cells.GetSubrange("A20:F28").Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;   
                workbook.Worksheets[0].Cells["F29"].Style.HorizontalAlignment = HorizontalAlignmentStyle.Right;
               
                
                // Invoice details text left side
                workbook.Worksheets[0].Cells[2, 0].Value = "ABN:";
                workbook.Worksheets[0].Cells[2, 0].Style.Font.Weight = ExcelFont.BoldWeight;
                workbook.Worksheets[0].Cells[4, 0].Value = "Email:";
                workbook.Worksheets[0].Cells[4, 0].Style.Font.Weight = ExcelFont.BoldWeight;
                workbook.Worksheets[0].Cells[6, 0].Value = "Contact No:";
                workbook.Worksheets[0].Cells[6, 0].Style.Font.Weight = ExcelFont.BoldWeight;
                workbook.Worksheets[0].Cells[8, 0].Value = "Address:";
                workbook.Worksheets[0].Cells[8, 0].Style.Font.Weight = ExcelFont.BoldWeight;
                workbook.Worksheets[0].Cells[13, 0].Value = "Bank BSB:";
                workbook.Worksheets[0].Cells[13, 0].Style.Font.Weight = ExcelFont.BoldWeight;
                workbook.Worksheets[0].Cells[14, 0].Value = "Account No:";
                workbook.Worksheets[0].Cells[14, 0].Style.Font.Weight = ExcelFont.BoldWeight;

                // Invoice details text right side
                workbook.Worksheets[0].Cells[0, 6].Value = "Invoice";
                workbook.Worksheets[0].Cells[0, 6].Style.Font.Weight = ExcelFont.BoldWeight;
                workbook.Worksheets[0].Cells[2, 6].Value = "Date of Invoice:";
                workbook.Worksheets[0].Cells[2, 6].Style.Font.Weight = ExcelFont.BoldWeight;
                workbook.Worksheets[0].Cells[4, 6].Value = "Invoice No:";
                workbook.Worksheets[0].Cells[4, 6].Style.Font.Weight = ExcelFont.BoldWeight;
                workbook.Worksheets[0].Cells[7, 6].Value = "Invoice To:";
                workbook.Worksheets[0].Cells[7, 6].Style.Font.Weight = ExcelFont.BoldWeight;
                workbook.Worksheets[0].Cells[10, 6].Value = "Address:";
                workbook.Worksheets[0].Cells[10, 6].Style.Font.Weight = ExcelFont.BoldWeight;


                // Table Colum descriptions
                workbook.Worksheets[0].Cells.GetSubrange("A20:G20").Style.Font.Weight = ExcelFont.BoldWeight;
                workbook.Worksheets[0].Cells.GetSubrange("A20:C20").Merged = true;
                workbook.Worksheets[0].Cells.GetSubrange("G21:G29").Style.NumberFormat = "$#,##0.00";               
                workbook.Worksheets[0].Cells["A20"].Value = "Description";
                workbook.Worksheets[0].Cells["D20"].Value = "Date of Work";
                workbook.Worksheets[0].Cells["E20"].Value = "Price Per Unit";
                workbook.Worksheets[0].Cells["F20"].Value = "Quanitity";                
                workbook.Worksheets[0].Cells["G20"].Value = "Price";
                workbook.Worksheets[0].Cells["F29"].Value = "Total - ";


               // Job Item table formatting
                workbook.Worksheets[0].Rows[19].Height = 600;
                workbook.Worksheets[0].Rows[20].Height = 500;
                workbook.Worksheets[0].Rows[21].Height = 500;
                workbook.Worksheets[0].Rows[22].Height = 500;
                workbook.Worksheets[0].Rows[23].Height = 500;
                workbook.Worksheets[0].Rows[24].Height = 500;
                workbook.Worksheets[0].Rows[25].Height = 500;
                workbook.Worksheets[0].Rows[26].Height = 500;
                workbook.Worksheets[0].Rows[27].Height = 500;
                workbook.Worksheets[0].Rows[28].Height = 500;
                workbook.Worksheets[0].Rows[29].Height = 500;
                workbook.Worksheets[0].Columns[1].Width = (workbook.Worksheets[0].Columns[0].Width) + 500;
                workbook.Worksheets[0].Columns[2].Width = (workbook.Worksheets[0].Columns[0].Width) + 500;
                workbook.Worksheets[0].Columns[3].Width = (workbook.Worksheets[0].Columns[0].Width) + 500;
                workbook.Worksheets[0].Columns[4].Width = (workbook.Worksheets[0].Columns[0].Width) + 500;
                workbook.Worksheets[0].Columns[5].Width = (workbook.Worksheets[0].Columns[0].Width) + 500;
                workbook.Worksheets[0].Columns[6].Width = (workbook.Worksheets[0].Columns[0].Width) + 500;

                // Table fill and borders
                workbook.Worksheets[0].Cells.GetSubrange("A20:G20").Style.FillPattern.SetPattern(FillPatternStyle.Solid, SpreadsheetColor.FromArgb(252, 228, 214), SpreadsheetColor.FromArgb(252, 228, 214));
                workbook.Worksheets[0].Cells.GetSubrange("A22:G22").Style.FillPattern.SetPattern(FillPatternStyle.Solid, SpreadsheetColor.FromArgb(252, 228, 214), SpreadsheetColor.FromArgb(252, 228, 214));  
                workbook.Worksheets[0].Cells.GetSubrange("A24:G24").Style.FillPattern.SetPattern(FillPatternStyle.Solid, SpreadsheetColor.FromArgb(252, 228, 214), SpreadsheetColor.FromArgb(252, 228, 214));
                workbook.Worksheets[0].Cells.GetSubrange("A26:G26").Style.FillPattern.SetPattern(FillPatternStyle.Solid, SpreadsheetColor.FromArgb(252, 228, 214), SpreadsheetColor.FromArgb(252, 228, 214));     
                workbook.Worksheets[0].Cells.GetSubrange("A28:G28").Style.FillPattern.SetPattern(FillPatternStyle.Solid, SpreadsheetColor.FromArgb(252, 228, 214), SpreadsheetColor.FromArgb(252, 228, 214));
                workbook.Worksheets[0].Cells.GetSubrange("A20:G28").Style.Borders.SetBorders(MultipleBorders.InsideHorizontal, SpreadsheetColor.FromName(ColorName.Black), LineStyle.Thin);
                workbook.Worksheets[0].Cells.GetSubrange("A20:G28").Style.Borders.SetBorders(MultipleBorders.Outside, SpreadsheetColor.FromName(ColorName.Black), LineStyle.Thin);
                workbook.Worksheets[0].Cells.GetSubrange("D20:D28").Style.Borders.SetBorders(MultipleBorders.Outside, SpreadsheetColor.FromName(ColorName.Black), LineStyle.Thin);
                workbook.Worksheets[0].Cells.GetSubrange("F20:G28").Style.Borders.SetBorders(MultipleBorders.Outside, SpreadsheetColor.FromName(ColorName.Black), LineStyle.Thin);
                workbook.Worksheets[0].Cells.GetSubrange("G20:G29").Style.Borders.SetBorders(MultipleBorders.Outside, SpreadsheetColor.FromName(ColorName.Black), LineStyle.Thin);
                               
                // Paid Cell
                workbook.Worksheets[0].Cells["B32"].Style.Font.Color = SpreadsheetColor.FromName(ColorName.Red);
                workbook.Worksheets[0].Cells["B32"].Style.Font.Size = 1200;
            }
        }
    }
}
