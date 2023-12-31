﻿using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driving;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.Dtos;

namespace WinFormsAppMusicStoreAdmin.DrivingAdapters.Excel
{
    public class Excel : IExcelDriving
    {
        public async Task<GeneralAnswer<object>> ExportRegisters(List<Register> listRegisters, List<Store> stores, string path)
        {

            return await Task.Run(() => ShellCreateReportStore(MapToRegisterDisplay(listRegisters, stores), path));
        }

        private List<RegisterDisplay> MapToRegisterDisplay(List<Register> listRegisters, List<Store> stores)
        {
            return listRegisters.Select(x => new RegisterDisplay { storeCode = stores.Where(u => u.Id == x.StoreId).Select(u => u.Code).FirstOrDefault(), activity = x.Activity == 1 ? "Reproduciendo" : "Detenido", message = x.Message, creationDateTime = x.CreationDateTime }).ToList();
        }

        private static GeneralAnswer<object> ShellCreateReportStore(List<RegisterDisplay> listData, string path)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            ExcelPackage excel = new ExcelPackage();

            // name of the sheet
            var workSheet = excel.Workbook.Worksheets.Add("Registros");

            // setting the properties
            // of the work sheet 
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            // Setting the properties
            // of the first row
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            try
            {
                workSheet.Cells[1, 1].Value = "Tienda";
                workSheet.Cells[1, 2].Value = "Actividad";
                workSheet.Cells[1, 3].Value = "Operacion";
                workSheet.Cells[1, 4].Value = "Fecha";

                int col = 1;
                int row = 2;

                foreach (var item in listData)
                {
                    workSheet.Cells[row, col].Value = item.storeCode;
                    col++;
                    workSheet.Cells[row, col].Value = item.activity;
                    col++;
                    workSheet.Cells[row, col].Value = item.message;
                    col++;
                    workSheet.Cells[row, col].Value = item.creationDateTime.ToString("dd/MM/yyyy HH:mm");
                    col = 1;
                    row++;
                }

                for (int i = 1; i <= 3; i++)
                {
                    workSheet.Column(i).AutoFit();
                }

                if (File.Exists(path))
                    File.Delete(path);

                // Create excel file on physical disk 
                FileStream objFileStrm = File.Create(path);
                objFileStrm.Close();

                // Write content to excel file 
                File.WriteAllBytes(path, excel.GetAsByteArray());
                //Close Excel package
                excel.Dispose();

                return new GeneralAnswer<object>(true, "Archivo guardado con exito.", null);
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<object>(false, "Error, Excepcion: " + ex.Message.ToLower(), null);
            }
        }
    }
}
