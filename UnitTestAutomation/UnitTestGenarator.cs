using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnitTestAutomation
{
    public class UnitTestGenerator
    {
        public void GenerateUnitTests(string filePath)
        {
            // Read the contents of the file
            var fileContents = File.ReadAllText(filePath);

            // Extract the methods and their logic
            var methodRegex =  new Regex(@"public\s+async\s+Task<IActionResult>\s+(?<methodName>\w+)\((?<arguments>.*)");
            var methods = methodRegex.Matches(fileContents);
            var unitTestsFilePath = "D:\\Development\\LSAC\\Backend\\UnitTests\\GeneratedUnitTests.cs";


            using (StreamWriter writer = new StreamWriter(unitTestsFilePath))
            {
                writer.WriteLine("using Xunit;");
                writer.WriteLine("namespace UnitTestGenerator");
                writer.WriteLine("{");
                writer.WriteLine("    public class TestMethods");
                writer.WriteLine("    {");
                // For each extracted method, write a corresponding test method
                foreach (Match method in methods)
                {
                var returnType = method.Groups["returnType"].Value;
                var methodName = method.Groups["methodName"].Value;
                var arguments = method.Groups["arguments"].Value;

                // Write the test method using the extracted information
                    writer.WriteLine("        [Fact]");
                    writer.WriteLine("        public void " + methodName + "Test()");
                    writer.WriteLine("        {");
                    writer.WriteLine("            // Arrange");

                    // TODO: Add code for arranging the test inputs
                    writer.WriteLine("            // Act");
                    writer.WriteLine("            " + returnType + " result = " + methodName + "(" + arguments + ");");

                    writer.WriteLine("            // Assert");
                    // TODO: Add code for asserting the expected results
                    writer.WriteLine("        }");
                    writer.WriteLine("    }");
                }
                writer.WriteLine("}");
                writer.WriteLine("\n");
            }
        }
    }
}
