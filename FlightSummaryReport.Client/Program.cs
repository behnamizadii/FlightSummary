using System;
using System.Collections.Generic;
using System.IO;
using FlightSummaryReport.Client.Helpers;
using FlightSummaryReport.Client.Utilities;

namespace FlightSummaryReport.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assumption is Program should run infinitely with all the exception handled
            //Unless user closes the console application
            while (true)
            {
                try
                {
                    Console.WriteLine("Please key in the path to the input file\n");
                    Console.Write(":>");
                    var path = Console.ReadLine();
                    if (string.IsNullOrEmpty(path))
                    {
                        throw new FileNotFoundException();
                    }

                    StreamReader streamReader = new StreamReader(path);
                    List<string> inputList = new List<string>();
                    var inputLine = streamReader.ReadLine();
                    while (inputLine != null)
                    {
                        inputList.Add(inputLine);
                        inputLine = streamReader.ReadLine();
                    }

                    var inputRefactor = new InputRefactor(new InputValidator());
                    var result = inputRefactor.InputValidator(inputList);
                    if (result) ServiceProvider.GenerateFlightAsync(inputRefactor.input).Wait();
                }

                #region Exception Handlers

                catch (FileNotFoundException)
                {
                    Console.WriteLine("Incorrect File format or wrong path! please retry!\n");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("wrong path! please retry!\n");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Access to the path is denied! please retry!\n");
                }
                catch (Exception e)
                {
                    LogGenerator.GenerateLog(e);
                }

                #endregion
            }
        }
        
    }
}

