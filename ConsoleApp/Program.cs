using CommandLine.Text;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Security.Application;
using System.Data.Entity;
using System.Data.SqlClient;
using TestEntityFramework;

namespace ConsoleApp
{
    class Program
    {
        public class Options
        {
            [Option('f', "file", Required = true, HelpText = "需要处理的文件。")]
            public IEnumerable<string> Files { get; set; }

            [Option('o', "override", Required = false, HelpText = "是否覆盖原有文件。")]
            public bool Override { get; set; }
        }

        static void Main(string[] args)
        {
            var sb = new SqlConnectionStringBuilder();

            sb.DataSource = "DESKTOP-VQEUHM2\\SQLEXPRESS";
            sb.InitialCatalog = "AdventureWorks2022";
            sb.IntegratedSecurity = true;
            var connStr = sb.ToString();

            using (var db = new MyDbContext(connStr))
            {
                var count = db.Person.Count();
                Console.WriteLine(count);
            }
            // Parser.Default.ParseArguments<Options>(args).WithParsed(Run);
        }

        private static void Run(Options option)
        {
            // 使用解析后的命令行参数进行操作。
            foreach (var file in option.Files)
            {
                var verb = option.Override ? "覆盖" : "使用";
                Console.WriteLine($"walterlv 正在{verb}文件 {file}");
            }
        }
    }
}
