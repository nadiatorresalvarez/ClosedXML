namespace Lab13Web_NadiaTorres.Application.Interfaces;

public interface IUnitOfWork
{
    IRepository<T> Repository<T>() where T : class;
    Task Complete();
}