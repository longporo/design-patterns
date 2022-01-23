using System;
using System.Collections;
using System.Collections.Generic;

namespace srp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Single Responsibility Principle (SRP)
            // a class should have only one job
            Console.WriteLine("Hello World!");
        }
    }
    
    // The ExcelService contain the GeneratePdf method which has nothing to do within itself
    class ExcelService
    {
        IList ImportExcelData(string excelFilePath)
        {
            /* code to read data from excel file */
            return new ArrayList();
        }

        // the generate pdf method has nothing to do within the ExcelService class
        // it should be assign to a new class PdfService
        void GeneratePdf(IList dataList)
        {
            /* code to generate a pdf file by data list */
        }
    }
    
    // Apply the SRP: extract the generating pdf method, make sure that a class should have only one job
    class ExcelService_In_SRP
    {
        IList ImportExcelData(string excelFilePath)
        {
            /* code to read data from excel file */
            return new ArrayList();
        }
    }
    
    class PdfService_In_SRP
    {
        void GeneratePdf(IList dataList)
        {
            /* code to generate a pdf file by data list */
        }
    }
}