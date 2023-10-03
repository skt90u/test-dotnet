﻿// Licence file C:\Users\skt90u\Documents\ReversePOCO.txt not found.
// Please obtain your licence file at www.ReversePOCO.co.uk, and place it in your documents folder shown above.
// Defaulting to Trial version.
// <auto-generated>
// ReSharper disable All

using EntityFramework.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Spatial;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TestEntityFramework
{
    #region Database context

    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    public partial class AdventureWorks2022 
    {
        // 參考資料：
        //   https://github.com/Dixin/EntityFramework.Functions
        //   https://weblogs.asp.net/Dixin/EntityFramework.Functions

        //[Function(FunctionType.NonComposableScalarValuedFunction, nameof(ufnLeadingZeros), Schema = "dbo")]
        [Function(FunctionType.ComposableScalarValuedFunction, nameof(ufnLeadingZeros), Schema = "dbo")]
        [return: Parameter(DbType = "varchar")]
        public string ufnLeadingZeros([Parameter(DbType = "int")] int Value)
        {
            ObjectParameter valueParameter = new ObjectParameter(nameof(Value), Value);
            return this.ObjectContext().ExecuteFunction<string>(
                nameof(this.ufnLeadingZeros), valueParameter).SingleOrDefault();
        }
    }

    #endregion
}
// </auto-generated>
