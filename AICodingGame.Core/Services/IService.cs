namespace AICodingGame.Core.Services;

public interface IService<TRepository>
{
    object? GetById(int id);
}