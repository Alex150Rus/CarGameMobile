using System.Collections.Generic;

internal class RepositoryBaseController: BaseController
{
    private List<IRepository> _repositories;

    protected override void OnDisposed()
    {
        DisposeRepositories();
    }

    private void DisposeRepositories()
    {
        foreach (IRepository repository in _repositories)
            repository?.Dispose();
        _repositories.Clear();
    }

    protected void AddRepository(IRepository repository)
    {
        _repositories ??= new List<IRepository>();
        _repositories.Add(repository);
    }
}
