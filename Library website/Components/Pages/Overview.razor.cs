using Microsoft.AspNetCore.Components;

public partial class Overview : ComponentBase
{
    protected int BookCount = 120;
    protected int UserCount = 35;

    protected void IncreaseBookCount()
    {
        BookCount++;
    }
}

