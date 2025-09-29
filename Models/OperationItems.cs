namespace PlanA.Models;

public class Operation_items
{
    public int OperationId { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
}

public class Operation_sources : Operation_items { }
public class Operation_supplies : Operation_items { }
public class Operation_results : Operation_items { }
public class Operation_remains : Operation_items { }