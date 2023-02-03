// See https://aka.ms/new-console-template for more information
using UnitTestAutomation;

Console.WriteLine("Welcome to UnitTests Generator!");
var filePath = "D:\\Development\\LSAC\\Backend\\Dev_7713UpdateVendorProgramProductWB\\AriadneAPI\\Controllers\\VendorController.cs";
UnitTestGenerator utG = new UnitTestGenerator();
utG.GenerateUnitTests(filePath);
