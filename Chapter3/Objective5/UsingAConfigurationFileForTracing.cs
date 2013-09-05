﻿using System;
using System.ComponentModel;
using Startup;

namespace Chapter3.Objective5
{
    [Description("Listing 3-48 Using a configuration file for tracing.")]
    internal class UsingAConfigurationFileForTracing : ISample
    {
        public void Run()
        {
            Console.WriteLine(@"<?xml version=""1.0"" encoding=""utf-8"" ?>
<configuration>
  <system.diagnostics>
    <sources>
      <source name=""myTraceSource"" switchName=""defaultSwitch"">
        <listeners>
          <add initializeData=""output.txt"" 
               type=""System.Diagnostics.TextWriterTraceListeer""            
               name=""myLocalListener"">
               <filter type=""System.Diagnostics.EventTypeFilter""
                initializeData=""Warning""/>
          </add>
          <add name=""consoleListener"" />
          <remove name=""Default""/>
        </listeners>
      </source>
    </sources>
    <sharedListeners>
      <add initializeData=""output.xml"" type=""System.Diagnostics.XmlWriterTraceListener""
         name=""xmlListener"" traceOutputOptions=""None"" />
      <add type=""System.Diagnostics.ConsoleTraceListener"" name=""consoleListener""
          traceOutputOptions=""None"" />
    </sharedListeners>
    <switches>
      <add name=""defaultSwitch"" value=""All"" />
    </switches>
  </system.diagnostics>
</configuration>    ");
        }
    }
}