﻿using System;
using System.ComponentModel;
using Startup;

namespace Chapter1.Objective5
{
    [Description("Listing 1-93 Inspecting an exception.")]
    internal class InspectingAnException : ISample
    {
        public void Run()
        {
            try
            {
                int i = ReadAndParse();
                Console.WriteLine("Parsed: {0}", i);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                Console.WriteLine("StackTrace: {0}", e.StackTrace);
                Console.WriteLine("HelpLink: {0}", e.HelpLink);
                Console.WriteLine("InnerException: {0}", e.InnerException);
                Console.WriteLine("TargetSite: {0}", e.TargetSite);
                Console.WriteLine("Source: {0}", e.Source);
            }
        }

        private static int ReadAndParse()
        {
            Console.WriteLine("Enter a number:");
            string s = Console.ReadLine();
            int i = int.Parse(s);
            return i;
        }
    }
}