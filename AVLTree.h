#ifndef AVLTree_H
#define AVLTree_H

#include "Person.h"
#include <iostream>
#include <algorithm>

using namespace std;

class Node
	{
	public:
		Node();
		Node(Person p, Node *l, Node *r);

		Node *left;
		Node *right;
		Person person;
	};


class AVLTree
{
public:

	AVLTree(); //done
	~AVLTree(); //done
    AVLTree(const AVLTree &RHS); //done
	const AVLTree& operator=(const AVLTree&); //done

	Node * insert(Node *, Person); //done
	Node * search(int);  //done
	Node * destroy(Node*,int); //done
	void destroyTree(Node *); //done
	Node * minValue(Node*); //done

	void print(Node *r);

    Node *makeCopy(Node *r); //done
	Node * balance(Node *); //done
	Node * rrRotation(Node *); //done
	Node * llRotation(Node *); //done
	Node * lrRotation(Node *); //done
	Node * rlRotation(Node *); //done
	int difference(Node *); //done
	int height(Node *); //done



	Node *treeRoot;
};


AVLTree::AVLTree()
{
	treeRoot=NULL;
}

AVLTree::~AVLTree()
{
	destroyTree(treeRoot);
}

void AVLTree::destroyTree(Node *r) //recursive delete helper function
{
    if(r!=NULL)
    {
        destroyTree(r->left);
        destroyTree(r->right);
        delete r;
        r=NULL;
    }
}

AVLTree::AVLTree(const AVLTree &RHS)
{
	treeRoot=NULL;
    *this = RHS; //uses overloaded = operator
}

const AVLTree& AVLTree::operator=(const AVLTree& RHS)
{
    if(this == &RHS) //check for self alignment
    {
        return *this;
    }
    destroyTree(treeRoot);
    treeRoot = makeCopy(treeRoot);
    return *this;
}

Node* AVLTree::makeCopy(Node *r)
{
    if(r!=NULL)
    {
        return new Node(r->person, makeCopy(r->left),makeCopy(r->right));
    } else
        return NULL;
}

int AVLTree::difference(Node *r)
{
	int lHeight = height(r->left);
	int rHeight = height(r->right);
	return (lHeight-rHeight);
}

int AVLTree::height(Node *r)
{
	int h = 0;
	if(r!=NULL)
	{
		int lHeight = height(r->left);
		int rHeight = height(r->right);
		int maxHeight=max(lHeight, rHeight);
		h=maxHeight+1;
	}
	return h;
}

Node * AVLTree::balance(Node *temp)
{
	int diff=difference(temp);
	if(diff>1)
	{
		if(difference(temp->left)>0)
			temp=llRotation(temp);
		else
			temp=lrRotation(temp);
	}
	else if (diff<-1)
	{
		if(difference(temp->right)>0)
			temp = rlRotation(temp);
		else
			temp = rrRotation(temp);
	}
	return temp;
}

Node * AVLTree::rrRotation(Node *parent)
{
	Node *temp;
	temp = parent->right;
	parent->right = temp->left;
	temp->left = parent;
	return temp;
}

Node * AVLTree::llRotation(Node *parent)
{
	Node *temp;
	temp = parent->left;
	parent->left=temp->right;
	temp->right=parent;
	return temp;
}

Node * AVLTree::lrRotation(Node *parent)
{
	Node *temp;
	temp = parent->left;
	parent->left=rrRotation(temp);
	return llRotation(parent);
}

Node * AVLTree::rlRotation(Node *parent)
{
	Node *temp;
	temp = parent->right;
	parent->right = llRotation(temp);
	return rrRotation(parent);
}

Node * AVLTree::insert(Node *root, Person p)
{
	if(root==NULL)
	{
		root = new Node(p, NULL, NULL);
		return root;
	}
	else if (p.getAgencyId() < root->person.getAgencyId())
	{
		root->left = insert(root->left,p);
		root = balance(root);
	}
	else if(p.getAgencyId() >= root->person.getAgencyId())
	{
		root->right = insert(root->right, p);
		root=balance(root);
	}
	return root;
}

Node * AVLTree::search(int code)
{
	Node *temp=treeRoot;
	while(temp!=NULL)
	{
		if(code < temp->person.getAgencyId())
		{
			temp=temp->left;
		}
		else if (code > temp->person.getAgencyId())
		{
			temp=temp->right;
		}
		else
		{
			break;
		}
	}
	return temp;
}

Node* AVLTree::destroy(Node* root, int code)
{
	if (root==NULL)
		return root;
	if (code < root->person.getAgencyId())
		root->left = destroy(root->left, code);
	else if (code > root->person.getAgencyId())
		root->right = destroy(root->right, code);
	else
	{
		if (root->left == NULL || root->right == NULL)
		{
			Node* temp = root->left ? root->left : root->right;
			
			if (temp==NULL)
			{
				temp = root;
				if(treeRoot->right==NULL && treeRoot->left==NULL)
					treeRoot=NULL;
				else
					root=NULL;
			}
			else
				*root = *temp;
			delete temp;
		}
		else
		{
			Node* temp = minValue (root->right);
			root->person.setAgencyId(temp->person.getAgencyId());
			root->person.setStateId(temp->person.getStateId());
			root->person.setName(temp->person.getName());
			root->person.getAccount().setBalance(temp->person.getAccount().getBalance());
			root->person.getAccount().setTotalEarned(temp->person.getAccount().getTotalEarned());
			root->person.getAccount().setWithdrawn(temp->person.getAccount().getWithdrawn());
			root->right = destroy(root->right, temp->person.getAgencyId());
		}
	}
	if (root == NULL)
		return root;
	balance(root);

	return root;
}


Node* AVLTree::minValue(Node* Nptr)
{
	while (Nptr->left!=NULL)
		Nptr=Nptr->left;
	return Nptr;
}
void AVLTree::print(Node *r)
{
    if(r!=NULL)
    {
        print(r->left);

        cout<<"Name: " << r->person.getName() << "  Agency ID: " << r->person.getAgencyId() << "  State ID: " << r->person.getStateId() << "  Current Balance: " << r->person.getAccount().getBalance();
       	cout<<"  Total Earned: " << r->person.getAccount().getTotalEarned() << "  Total Withdrawn: " << r->person.getAccount().getWithdrawn()<<endl;

        print(r->right);
    }
}

Node::Node()
{
	left=NULL;
	right=NULL;
}

Node::Node(Person p, Node *l, Node *r)
{
	left=l;
	right=r;
	person=p;
}

#endif