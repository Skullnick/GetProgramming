namespace Domain

type Customer =
    { Name : string
      Id: System.Guid
    }

type Account = 
    { AccountID: System.Guid 
      Customer: Customer
      Balance: decimal
    }

