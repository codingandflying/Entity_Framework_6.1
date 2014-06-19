using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServerCompact;
using System.IO;

namespace EFDataAccessLayer.Model
{
    /// <summary>
    /// Class used to configure the default provider and connection factory to SqlCe.
    /// <para>If the "DisableSqlCeAsDefaultProvider" setting in app.config file is "true",
    /// will not make any changes by leaving the SQL Express as the defualt provider.</para>
    /// <para>If it is false or missing, will use the SqlCe as the default provider.</para>
    /// <para>Note that the settings in the executing assembly's app.config file will override this behavior.</para>
    /// </summary>
    class DatabaseConfiguration : DbConfiguration
    {
        public DatabaseConfiguration()
        {
            string defaultProvider = ConfigurationManager.AppSettings["DisableSqlCeAsDefaultProvider"] ?? "NONE";

            switch (defaultProvider.ToUpper())
            {
                case "FALSE":
                case "NONE":
                    //Set drop create always for debugging
#if DEBUG
                    SetDatabaseInitializer<EFDbContext>(new EFDbContextDebugInitializer());
#else
                        SetDatabaseInitializer<EFDbContext>(new CreateDatabaseIfNotExists<EFDbContext>());
#endif

                    SetProviderServices(SqlCeProviderServices.ProviderInvariantName, SqlCeProviderServices.Instance);
                    SetDefaultConnectionFactory(new SqlCeConnectionFactory(SqlCeProviderServices.ProviderInvariantName));
                    break;
                case "TRUE":
                    break;

                default:
                    throw new ConfigurationErrorsException("Unrecognized value for \"DisableSqlCeAsDefaultProvider\" key in app.config file");
            }
        }
    }
}
