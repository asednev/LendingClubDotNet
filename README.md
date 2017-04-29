LendingClubDotNet
=========

C# (.NET Core) Client for the Lending Club API

Example usage:
```
// Initialize the client with credentials.
// Replace 'authenticationToken' with the one provided to you by Lending Club
// Replace 'actorId' with your Lending Club Id
LendingClubV1Client lendingClubV1Client = new LendingClubV1Client(authenticationToken, actorId);

// Get all Listed Loans.
ListedLoansResponse listedLoansResponse = lendingClubV1Client.LoanResource.GetListedLoans();

// Get all Portfolios that you have.
PortfoliosOwnedResponse portfoliosOwnedResponse = lendingClubV1Client.AccountResource.GetPortfoliosOwned();

// Submit an Orders Request (invest in loans).
SubmitOrdersRequest submitOrdersRequest = new SubmitOrdersRequest
			{
				aid = Convert.ToInt32(actorId),
				orders = new List<Order> { new Order
				{
					loanId = loanId,
					portfolioId =  portfolioId,
					requestedAmount = 25
				} }
			};

// Congratulations, at this point if the request has been submitted successfully, you will have programatically invested!
SubmitOrdersResponse submitOrdersResponse = lendingClubV1Client.AccountResource.SubmitOrders(submitOrdersRequest);
```

See the official Lending Club API documentation here:
https://www.lendingclub.com/developers/lc-api.action


If you want more information about me, Justin Blackwood, go here:
https://www.linkedin.com/in/justinedwardblackwood
