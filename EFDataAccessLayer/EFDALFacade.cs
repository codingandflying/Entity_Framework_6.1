using EFDataAccessLayer.BaseTypes;
using EFDataAccessLayer.Model;
using System;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

namespace EFDataAccessLayer
{
    /// <summary>
    /// Provides a facade to the data access layer. Provides unit of work and 
    /// connection management to the DAL.
    /// </summary>
    public class EFDALFacade : IDALFacade
    {
        //_________________________________________________________________________________________
        #region Stores

        /// <summary>
        /// data base connection used when working in connected state.
        /// </summary>
        private DbConnection _DbConnection = null;

        /// <summary>
        /// Managed instance of the DbContext by DALFacade. Only one context is used at any time.
        /// Injected into the unit of work.
        /// </summary>
        private EFDbContext _Context = null;

        /// <summary>
        /// Instance of unit of work managed by the facade. Only one unit of work is used at any time.
        /// </summary>
        private UnitOfWork _UnitOfWork;

        /// <summary>
        /// Used to initialize the database pre emptively on first run.
        /// </summary>
        private bool _FirstRequest = true;

        #endregion

        //_________________________________________________________________________________________
        #region Properties

        /// <summary>
        /// Data base name used by the application.
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Reads and holds the "KeepConnectionOpen" setting from the app.config file.
        /// If no setting is found, reverts to false for disconnected operation.
        /// </summary>
        public bool KeepConnectionAlive { get; private set; }

        /// <summary>
        /// Reads and holds the "DisableSqlCeAsDefaultProvider" setting from the app.config file.
        /// If no setting is found or false, SqlCe becomes the default provider.
        /// </summary>
        public bool DisableSqlCe { get; private set; }

        #endregion

        //_________________________________________________________________________________________
        #region Constructors

        public EFDALFacade()
        {
            ReadAppConfigSettings();
        }

        #endregion

        //_________________________________________________________________________________________
        #region IDALFacade Implementation

        /// <summary>
        /// Creates and returns a unit of work to the caller. 
        /// If a unit of work is already being used, throws an exception.
        /// Allows only one instance of unit of work to exist.
        /// </summary>
        /// <returns></returns>
        public virtual IUnitOfWork GetUnitOfWork()
        {
            if (_UnitOfWork != null)
                throw new Exception("a unit of work is already in use.");
            else
            {
                //If we are not responsible for keeping connection open,
                //then create and return a unit of work
                if (!KeepConnectionAlive)
                {
                    _Context = new EFDbContext(DatabaseName);

                    if (_FirstRequest)
                    {
                        _Context.Database.Initialize(force: false);
                        _FirstRequest = false;
                    }
                }
                else
                {
                    //We need to create a dbconnection and keep it running.
                    //Type of dbconnection depends on the db engine we are using
                    //SqlConnection for SqlServer, SqlCeConnection for CE
                    if (_DbConnection == null)
                    {
                        string connectionString = null;

                        if (DisableSqlCe)
                        {
                            //Using SqlServer
                            _DbConnection = new SqlConnection();
                            //localDb string
                            //connectionString = "Server=(localdb)\\v11.0;Integrated Security=true;";
                            //"Server=(localdb)\\Test;Integrated Security=true;AttachDbFileName= myDbFile;"
                            connectionString = @" Server=.\SQLEXPRESS; Database=" +
                                                DatabaseName +
                                                "; Trusted_Connection=true";
                        }
                        else
                        {
                            //Using SqlCe
                            _DbConnection = new SqlCeConnection();
                            connectionString = "Data Source=" + DatabaseName;
                        }

                        //Create a context and initialize the db on startup. 
                        if (_FirstRequest)
                        {
                            using (var tempContext = new EFDbContext(connectionString))
                            {
                                tempContext.Database.Initialize(force: false);
                            }

                            _FirstRequest = false;
                        }


                        _DbConnection.ConnectionString = connectionString;
                        _DbConnection.Open();
                    }

                    _Context = new EFDbContext(_DbConnection, false);

                }

                _UnitOfWork = new UnitOfWork(_Context);
                return _UnitOfWork;
            }
        }

        /// <summary>
        /// Closes a previously created unit of work and disposes the underlying resources.
        /// If no context was created, throws an exception.
        /// </summary>
        public virtual void ReturnUnitOfWork()
        {
            if (_UnitOfWork != null)
            {
                //If we do not own the connection, it should be already closed/
                if (!KeepConnectionAlive)
                {
                    if (_DbConnection != null)
                        throw new Exception("Database connection is not null in disconnected state.");
                }
                else if (_DbConnection == null || _DbConnection.State != System.Data.ConnectionState.Open)
                    throw new Exception("Database connection is not open in connected state.");

                //disposes dbcontext as well.
                _UnitOfWork.Dispose();
                _UnitOfWork = null;
                _Context = null;
            }
        }

        #endregion

        //_________________________________________________________________________________________
        #region Private Methods

        private void ReadAppConfigSettings()
        {
            //Get the default provider choice from the app.config file
            string defaultProvider = ConfigurationManager.AppSettings["DisableSqlCeAsDefaultProvider"] ?? "NONE";
            switch (defaultProvider.ToUpper())
            {
                case "FALSE":
                case "NONE":
                    DisableSqlCe = false;
                    break;
                case "TRUE":
                    DisableSqlCe = true;
                    break;

                default:
                    throw new ConfigurationErrorsException("Unrecognized value for \"DisableSqlCeAsDefaultProvider\" key in app.config file");
            }

            //Get the connection management option from the app.config
            string connectionOption = ConfigurationManager.AppSettings["KeepConnectionOpen"] ?? "FALSE";
            switch (connectionOption.ToUpper())
            {
                case "TRUE":
                    KeepConnectionAlive = true;
                    break;
                case "NONE":
                case "FALSE":
                    KeepConnectionAlive = false;
                    break;
                default:
                    throw new ConfigurationErrorsException("Unrecognized value for \"KeepConnectionOpen\" key in app.config file");
            }

            //Get the default database name. If none set, we use the default "EFDALDatabase"
            DatabaseName = ConfigurationManager.AppSettings["DefaultDatabase"] ?? "EFDALDatabase";

            //If SQLCE is used, get the db directory
            if (!DisableSqlCe)
            {
                string directory = ConfigurationManager.AppSettings["DatabaseDirectory"] ?? AppDomain.CurrentDomain.BaseDirectory;
                DatabaseName = directory + DatabaseName;
            }
        }

        #endregion

    }
}
