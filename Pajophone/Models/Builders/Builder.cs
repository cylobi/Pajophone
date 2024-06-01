namespace Pajophone.Models.Builders;

public abstract class Builder<T>
{
    protected T Model { get; set; }

    public abstract IModel Build();
}