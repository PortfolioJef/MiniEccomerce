using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Collection.Generic;
using FluentNHibernate.Mapping;

    public class NHibernateHelper
    {
        private static void CreateSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString).ShowSql)
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ServerData>())
               .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
            .BuildSessionFactory();
        } 
    }
}