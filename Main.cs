using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RevitAPITrainingRibbon
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "Revit API Training";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath = @"C:\RevitAPITrainig\";

            var panel = application.CreateRibbonPanel(tabName, "Стены");

            var button1 = new PushButtonData("Система", "Смена типа стен",
                Path.Combine(utilsFolderPath, "RevitAPIWallsType.dll"),
                "RevitAPIWallsType.Main");

            var button2 = new PushButtonData("Система", "Объем стен",
               Path.Combine(utilsFolderPath, "RevitAPITrainingCountUI.dll"),
               "RevitAPITrainingCountUI.Main");

            Uri uriImage1 = new Uri(@"C:\RevitAPITrainig\Images\01.png", UriKind.Absolute);
            BitmapImage largeImage1 = new BitmapImage(uriImage1);
            button1.LargeImage = largeImage1;

            Uri uriImage2 = new Uri(@"C:\RevitAPITrainig\Images\02.png", UriKind.Absolute);
            BitmapImage largeImage2 = new BitmapImage(uriImage2);
            button2.LargeImage = largeImage2;           
           
            panel.AddItem(button1);
            panel.AddItem(button2);


            return Result.Succeeded;
        }                
    }
}
