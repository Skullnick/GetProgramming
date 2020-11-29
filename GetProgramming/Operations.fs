

module Operations

open Domain

let deposit (amount: decimal) (account: Account) = 
    {account with Balance = account.Balance + amount}

let withdraw (amount: decimal) (account: Account) =
    if account.Balance >= amount && amount > 0M && account.Balance >= 0M then
        { account with Balance = account.Balance - amount }
    else
        account
