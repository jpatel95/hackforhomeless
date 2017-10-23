#ifndef BANKACCOUNT_H
#define BANKACCOUNT_H

#include <iostream>

using namespace std;

class BankAccount
{
public:
	BankAccount();
	BankAccount(double, double, double);

	double getBalance();
	double getTotalEarned();
	double getWithdrawn();

	void setBalance(double);
	void setTotalEarned(double);
	void setWithdrawn(double);

	void withdrawMoney(double);

private:
	double currentBalance;
	double totalEarned;
	double withdrawn;
};

BankAccount::BankAccount()
{
	currentBalance=0.0;
	totalEarned=0.0;
	withdrawn=0.0;	
}

BankAccount::BankAccount(double a, double b, double c)
{
	currentBalance=a;
	totalEarned=b;
	withdrawn=c;	
}


double BankAccount::getBalance()
{
	return currentBalance;
}


double BankAccount::getTotalEarned()
{
	return totalEarned;
}

double BankAccount::getWithdrawn()
{
	return withdrawn;
}

void BankAccount::setBalance(double d)
{
	currentBalance = d;
}

void BankAccount::setTotalEarned(double d)
{
	totalEarned = d;
}

void BankAccount::setWithdrawn(double d)
{
	withdrawn = d;
}

void BankAccount::withdrawMoney(double d)
{
	if(currentBalance - d < 0)
	{
		cout<<"You have insufficient funds, withdraw cannot happen."<<endl;
		return;
	}
	if(d < 0)
	{
		cout<<"You cannot withdraw negative amounts of money."<<endl;
		return;
	}
	withdrawn = withdrawn + d;
	currentBalance = totalEarned - withdrawn;
}


#endif