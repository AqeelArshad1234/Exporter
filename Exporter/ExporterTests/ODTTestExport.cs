﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using ExportImplementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExporterTests
{

    public partial class ODTTests
    {
        [TestClass]
        public class TestExport
        {
            [TestMethod]
            public void TestWithPersonHeader()
            {
                
                var p = new Person {Name = "andrei", WebSite = "http://msprogrammer.serviciipeweb.ro/"};
                var export = new ExportODT<Person>();
                var data = export.ExportResultStringPart(new List<Person>() {p});
                var str = data;
                Assert.IsTrue(str.Contains(export.ExportHeader),"must contain the header");
            }
            [TestMethod]
            public void TestWithPersonData()
            {
                var p = new Person { Name = "Andrei Ignat", WebSite = "http://msprogrammer.serviciipeweb.ro/", CV = "http://serviciipeweb.ro/iafblog/content/binary/cv.doc" };
                var export = new ExportODT<Person>();
                var data = export.ExportResultStringPart(new List<Person>() { p});
                var str = data;
                Assert.IsTrue(str.Contains("http://serviciipeweb.ro/iafblog/content/binary/cv.doc"),"must contain the cv");

            }
            //[TestMethod]
            public void TestODT()
            {
                
                
                var p = new Person { Name = "Andrei Ignat", WebSite = "http://msprogrammer.serviciipeweb.ro/", CV = "http://serviciipeweb.ro/iafblog/content/binary/cv.doc" };                
                var export = new ExportODT<Person>();
                var data = export.ExportResult(new List<Person>() { p });                
                File.WriteAllBytes("a.odt",data);
                Process.Start("a.odt");

            }
        }
    }
}