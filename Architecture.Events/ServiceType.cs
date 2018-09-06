using System;

namespace Architecture.Events
{
    [Flags]
    public enum ServiceType : long
    {
        Users = 0,
        Companies = 1,
        Products = 2,
        Batches = 4,
        Warehouses = 8,
        WarehouseBalances = 16,
        SimpleIncome = 32,
        Movements = 64
    }
}