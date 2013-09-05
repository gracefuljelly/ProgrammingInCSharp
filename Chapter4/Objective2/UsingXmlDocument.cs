﻿using System;
using System.ComponentModel;
using System.Xml;
using Startup;

namespace Chapter4.Objective2
{
    [Description("Listing 4-45 Using XmlDocument.")]
    internal class UsingXmlDocument : ISample
    {
        public void Run()
        {
            string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                <people>
                  <person firstname=""john"" lastname=""doe"">
                    <contactdetails>
                      <emailaddress>john@unknown.com</emailaddress>
                    </contactdetails>
                  </person>
                  <person firstname=""jane"" lastname=""doe"">
                    <contactdetails>
                      <emailaddress>jane@unknown.com</emailaddress>
                      <phonenumber>001122334455</phonenumber>
                    </contactdetails>
                  </person>
                </people>";

            var doc = new XmlDocument();

            doc.LoadXml(xml);
            XmlNodeList nodes = doc.GetElementsByTagName("Person");

            // Output the names of the people in the document
            foreach (XmlNode node in nodes)
            {
                string firstName = node.Attributes["firstName"].Value;
                string lastName = node.Attributes["lastName"].Value;
                Console.WriteLine("Name: {0} {1}", firstName, lastName);
            }

            // Start creating a new node
            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "Person", "");

            XmlAttribute firstNameAttribute = doc.CreateAttribute("firstName");
            firstNameAttribute.Value = "Foo";

            XmlAttribute lastNameAttribute = doc.CreateAttribute("lastName");
            lastNameAttribute.Value = "Bar";

            newNode.Attributes.Append(firstNameAttribute);
            newNode.Attributes.Append(lastNameAttribute);

            doc.DocumentElement.AppendChild(newNode);
            Console.WriteLine("Modified xml...");
            doc.Save(Console.Out);
        }
    }
}