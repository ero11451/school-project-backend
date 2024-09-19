using Microsoft.EntityFrameworkCore.Storage;

public class NonRetryingExecutionStrategy : ExecutionStrategy
{
    public NonRetryingExecutionStrategy(ExecutionStrategyDependencies dependencies)
        : base(dependencies, DefaultMaxRetryCount, DefaultMaxDelay)
    {
    }

    protected override bool ShouldRetryOn(Exception exception)
    {
        return false; // Disable retrying
    }
}
