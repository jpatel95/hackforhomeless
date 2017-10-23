#ifndef PERSON_H
#define PERSON_H

#include "BankAccount.h"

using namespace std;

class Person
{
public:
	Person();
	Person(BankAccount, string, string, int);

	BankAccount getAccount();
	string getName();
	string getStateId();
	int getAgencyId();

	void setAccount(BankAccount);
	void setName(string);
	void setStateId(string);
	void setAgencyId(int);

private:
	BankAccount account;
	string name;
	string stateId;
	int agencyId;
};

Person::Person(): account(0.0,0.0,0.0)
{
	name = "NULL";
	stateId = "NULL";
	agencyId = 0;
}

Person::Person(BankAccount a, string b, string c, int d): account(a), name(b), stateId(c), agencyId(d)
{
	//no need for anything
}

BankAccount Person::getAccount()
{
	return account;
}

string Person::getName()
{
	return name;
}

string Person::getStateId()
{
	return stateId;
}

int Person::getAgencyId()
{
	return agencyId;
}

void Person::setAccount(BankAccount a)
{
	account=a;
}

void Person::setName(string s)
{
	name = s;
}

void Person::setStateId(string s)
{
	stateId = s;
}

void Person::setAgencyId(int i)
{
	agencyId = i;
}






#endif