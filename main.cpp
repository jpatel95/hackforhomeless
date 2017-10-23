#include "AVLTree.h"
#include <iostream>

using namespace std;

int main(void)
{
	AVLTree tree;
	BankAccount b;
	string first, last, stateId;
	int agencyID;
	int choice;
	while(1)
	{
		cout<<"Press 1 to Insert"<<endl;
		cout<<"Press 2 to Search"<<endl;
		cout<<"Press 3 to List"<<endl;
		cout<<"Press 4 to delete"<<endl;
		cin>>choice;

		switch(choice)
		{
			case 1:
			{
				cout<<"What is the first name?"<<endl;
				cin>>first;
				cout<<"What is the last name?"<<endl;
				cin>>last;
				cout<<"What is the state ID number?"<<endl;
				cin>>stateId;
				cout<<"Enter an Agency ID Number?"<<endl;
				cin>>agencyID;

				Person p(b, first + " " + last, stateId, agencyID);

				tree.treeRoot = tree.insert(tree.treeRoot, p);
				break;
			}
			case 2:
			{
				Node *temp;
				cout<<"What is the Agency ID Number?"<<endl;
				cin>>agencyID;
				temp = tree.search(agencyID);
				if(temp==NULL)
				{
					cout<<"Could not find that number" << endl;
				}
				else 
				{
					int c;
					cout<<"Name: " << temp->person.getName()<< endl;
					cout<<"Agency ID: " << temp->person.getAgencyId()<< endl;
					cout<<"State ID: " << temp->person.getStateId()<< endl;
					cout<<"Current Balance: " << temp->person.getAccount().getBalance()<< endl;
					cout<<"Total Withdrawn: " << temp->person.getAccount().getWithdrawn()<< endl;
					cout<<"Total Earned: " << temp->person.getAccount().getTotalEarned()<< endl << endl;
					
					cout<<"Press 1 to withdraw money or 2 to go back "<< endl;
					cin>>c;
					if(c==1)
					{
						int money;
						cout<<"How much would you like to withdraw?"<< endl;
						cin>>money;
						temp->person.getAccount().withdrawMoney(money);
					}
				}
				break;
			}
			case 3:
			{
				tree.print(tree.treeRoot);
				break;
			}
			case 4:
			{
				cout<<"What is the Agency ID Number for the person you would like to remove?"<<endl;
				cin>>agencyID;
				tree.destroy(tree.treeRoot,agencyID);
				break;
			}
			default:
			{
				cout<<"Invalid Option"<<endl;
				return 0;
				break;
			}
		}
	}

	return 0;
}