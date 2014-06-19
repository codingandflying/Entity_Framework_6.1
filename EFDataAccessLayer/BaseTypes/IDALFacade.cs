namespace EFDataAccessLayer.BaseTypes
{
    /// <summary>
    /// Interface for the facade used by the data access layer.
    /// </summary>
    public interface IDALFacade
    {
        /// <summary>
        /// Creates and returns a unit of work to the caller. 
        /// If a unit of work is already being used, throws an exception.
        /// Allows only one instance of unit of work to exist.
        /// </summary>
        /// <returns></returns>
        IUnitOfWork GetUnitOfWork();

        /// <summary>
        /// Closes a previously created unit of work and disposes the underlying resources.
        /// If no context was created, throws an exception.
        /// </summary>
        void ReturnUnitOfWork();

        /// <summary>
        /// Data base name used by the application.
        /// </summary>
        string DatabaseName { get; set; }
    }
}