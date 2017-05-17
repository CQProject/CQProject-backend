using Microsoft.AspNet.Identity.EntityFramework;
using CQPROJ.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQPROJ.Database.Context
{
    public class DBContext : IdentityDbContext<Tbl_User>
    {
        /**************************************************************************************************************************
         * especificar onde será criada a Base de dados
         * a localização é especificada no ficheiro Web.config
         * ----------------------------------------------------
         *  depois de definidas as configurações -> NuGet Console:
         *          PM> Enable-Migrations -EnableAutomaticMigrations
         *      para habilitar as migrações entre a base de dados definida e a aplicação
         *          PM> Update-Database
         *      para atualizar a base de dados tendo em conta as migrações definidas em Migrations/Configurations.cs
         ***************************************************************************************************************************/
        public DBContext(): base("Connection", throwIfV1Schema: false) { }




        public static DBContext Create()
        {
            return new DBContext();
        }

    }
}