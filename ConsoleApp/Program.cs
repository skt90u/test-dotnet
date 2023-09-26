using CommandLine.Text;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Security.Application;
using System.Data.Entity;
using System.Data.SqlClient;
using TestEntityFramework;

namespace ConsoleApp
{
    partial class Program
    {
        public class Options
        {
            [Option('f', "file", Required = true, HelpText = "�ݭn?�z�����C")]
            public IEnumerable<string> Files { get; set; }

            [Option('o', "override", Required = false, HelpText = "�O�_��?�즳���C")]
            public bool Override { get; set; }
        }

        static void Main(string[] args)
        {
            for(var i=0; i<10; i++)
            {
                var a = 1;
                var b = 2;
                var c = a + b;
                Console.WriteLine(c);
            }
            
            //EntityFrameworkProfilerBootstrapper.PreStart();
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();

            var sb = new SqlConnectionStringBuilder();

            sb.DataSource = "DESKTOP-VQEUHM2\\SQLEXPRESS";
            sb.InitialCatalog = "AdventureWorks2022";
            sb.IntegratedSecurity = true;
            var connStr = sb.ToString();

            //using (var db = new MyDbContext(connStr))
            //{
            //    var count = db.Person.Count();
            //    Console.WriteLine(count);
            //}

            using (var db = new AdventureWorks2022(connStr))
            {
                var count = db.Sales_SpecialOffers.Count();
                Console.WriteLine(count);
            }

            // Parser.Default.ParseArguments<Options>(args).WithParsed(Run);
        }

        private static void Run(Options option)
        {
            // �ϥθѪR�Z���R�O��???��ާ@�C
            foreach (var file in option.Files)
            {
                var verb = option.Override ? "��?" : "�ϥ�";
                Console.WriteLine($"walterlv ���b{verb}��� {file}");
            }
        }
    }
}

