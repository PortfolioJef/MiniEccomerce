using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace SwEcommerce.Models
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                  .ConnectionString(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\DBProdutos.mdf;Integrated Security=True") 
                              .ShowSql()
                )
               .Mappings(m =>
                          m.FluentMappings
                              .AddFromAssemblyOf<Produtos>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                .Create(false,false))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }

}