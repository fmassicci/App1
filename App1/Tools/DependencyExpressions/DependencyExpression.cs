namespace App1;
public class DependencyExpression
{
    public DependencyExpression(string name, string[] dependencies)
    {
        this.Name = name;
        this.Dependencies = dependencies;
    }

    public string Name { get; }
    public string[] Dependencies { get; }
}
