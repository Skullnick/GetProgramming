namespace Domain

type Customer =
    { FirstName : string
      LastName: string
      Age: int
      Id: System.Guid
    }

type Account = 
    { CustomerID: System.Guid
      Balance: float
    }

