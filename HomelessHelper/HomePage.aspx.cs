using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Linq;
using System.Net;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class HomePage : System.Web.UI.Page
{
    public class BankAccount
    {
        public double currentBalance;
        public double totalEarned;
        public double withdrawn;

        public BankAccount()
        {
            currentBalance = 0.0;
            totalEarned = 0.0;
            withdrawn = 0.0;	
        }

        public BankAccount(double a, double b, double c)
        {
            currentBalance = a;
            totalEarned = b;
            withdrawn = c;
        }

        public double getBalance()
        {
            return currentBalance;
        }

        public double getTotalEarned()
        {
	        return totalEarned;
        }

        public double getWithdrawn()
        {
	        return withdrawn;
        }

        public void setBalance(double d)
        {
	        currentBalance = d;
        }

        public void setTotalEarned(double d)
        {
	        totalEarned = d;
        }

        public void setWithdrawn(double d)
        {
	        withdrawn = d;
        }

        public void withdrawMoney(double d)
        {
	        if(currentBalance - d < 0)
	        {
		        //"You have insufficient funds, withdraw cannot happen.";
		        return;
	        }
	        if(d < 0)
        	{
		        //"You cannot withdraw negative amounts of money.";
		        return;
        	}
	        withdrawn = withdrawn + d;
	        currentBalance = totalEarned - withdrawn;
        }
    }

    public class Person
    {
        public BankAccount account;
        public string name;
        public string stateId;
        public int agencyId;

        public Person()
        {
            account = new BankAccount(0.0, 0.0, 0.0);
            name = "NULL";
            stateId = "NULL";
            agencyId = 0;
        }

        public Person(BankAccount a, string b, string c, int d)
        {
	        account = a;
            name = b;
            stateId = c;
            agencyId = d;
        }

        public BankAccount getAccount()
        {
	        return account;
        }

        public string getName()
        {
	        return name;
        }

        public string getStateId()
        {
	        return stateId;
        }

        public int getAgencyId()
        {
	        return agencyId;
        }

        public void setAccount(BankAccount a)
        {
	        account=a;
        }

        public void setName(string s)
        {
	        name = s;
        }

        public void setStateId(string s)
        {
	        stateId = s;
        }

        public void setAgencyId(int i)
        {
	        agencyId = i;
        }
    }

    public class Node
    {
        public Node left;
        public Node right;
        public Person person;

        public Node()
        {
            left = null;
            right = null;
        }

        public Node(Person p, Node l, Node r)
        {
	        left = l;
	        right = r;
	        person = p;
        }
    }

    public class AVLTree
    {
        public Node treeRoot;

        public AVLTree()
        {
	        treeRoot = null;
        }

        //public ~AVLTree()
        //{
        //    destroyTree(treeRoot);
        //}

        //public void destroyTree(Node *r) //recursive delete helper function
        //{
        //    if(r!=NULL)
        //    {
        //        destroyTree(r.left);
        //        destroyTree(r.right);
        //        delete r;
        //        r=NULL;
        //    }
        //}

        public AVLTree(AVLTree RHS)
        {
	        treeRoot = RHS.treeRoot;
        }

        //public static AVLTree operator =(AVLTree RHS)
        //{
        //    if(this == &RHS) //check for self alignment
        //    {
        //        return *this;
        //    }
        //    destroyTree(treeRoot);
        //    treeRoot = makeCopy(treeRoot);
        //    return *this;
        //}

        public Node makeCopy(Node r)
        {
            if (r != null)
            {
                return new Node(r.person, makeCopy(r.left),makeCopy(r.right));
            }
            else
                return null;
        }

        public int height(Node r)
        {
	        int h = 0;
	        if(r != null)
	        {
		        int lHeight = height(r.left);
		        int rHeight = height(r.right);
		        int maxHeight;
                if (lHeight > rHeight)
                    maxHeight = lHeight;
                else
                    maxHeight = rHeight;
		        h=maxHeight+1;
	        }
	        return h;
        }

        public int difference(Node r)
        {
	        int lHeight = height(r.left);
	        int rHeight = height(r.right);
	        return (lHeight-rHeight);
        }

        public Node rrRotation(ref Node parent)
        {
	        Node temp;
	        temp = parent.right;
	        parent.right = temp.left;
	        temp.left = parent;
	        return temp;
        }

        public Node llRotation(ref Node parent)
        {
	        Node temp;
	        temp = parent.left;
	        parent.left=temp.right;
	        temp.right=parent;
	        return temp;
        }

        public Node lrRotation(ref Node parent)
        {
	        Node temp;
	        temp = parent.left;
	        parent.left=rrRotation(ref temp);
	        return llRotation(ref parent);
        }

        public Node rlRotation(ref Node parent)
        {
	        Node temp;
	        temp = parent.right;
	        parent.right = llRotation(ref temp);
	        return rrRotation(ref parent);
        }

        public Node balance(ref Node temp)
        {
	        int diff=difference(temp);
	        if(diff>1)
	        {
		        if(difference(temp.left)>0)
			        temp=llRotation(ref temp);
		        else
			        temp=lrRotation(ref temp);
	        }
	        else if (diff<-1)
	        {
		        if(difference(temp.right)>0)
			        temp = rlRotation(ref temp);
		        else
			        temp = rrRotation(ref temp);
	        }
	        return temp;
        }



        public Node insert(ref Node root, Person p)
        {
	        if(root==null)
	        {
		        root = new Node(p, null, null);
		        return root;
	        }
	        else if (p.getAgencyId() < root.person.getAgencyId())
	        {
		        root.left = insert(ref root.left,p);
		        root = balance(ref root);
	        }
	        else if(p.getAgencyId() >= root.person.getAgencyId())
	        {
		        root.right = insert(ref root.right, p);
		        root=balance(ref root);
	        }
	        return root;
        }

        public Node search(int code)
        {
	        Node temp=treeRoot;
	        while(temp!=null)
	        {
		        if(code < temp.person.getAgencyId())
		        {
			        temp=temp.left;
		        }
		        else if (code > temp.person.getAgencyId())
		        {
			        temp=temp.right;
		        }
		        else
		        {
			        break;
		        }
	        }
	        return temp;
        }

        public Node destroy(ref Node root, int code)
        {
            if (root == null)
                return root;
            if (code < root.person.getAgencyId())
                root.left = destroy(ref root.left, code);
            else if (code > root.person.getAgencyId())
                root.right = destroy(ref root.right, code);
            else
            {
                if (root.left == null || root.right == null)
                {
                    Node temp;
                    if (root.left != null)
                        temp = root.left;
                    else
                        temp = root.right;

                    if (temp == null)
                    {
                        temp = root;
                        if (treeRoot.right == null && treeRoot.left == null)
                            treeRoot = null;
                        else
                            root = null;
                    }
                    else
                        root = temp;
                    //delete temp;
                }
                else
                {
                    Node temp = minValue(root.right);
                    root.person.setAgencyId(temp.person.getAgencyId());
                    root.person.setStateId(temp.person.getStateId());
                    root.person.setName(temp.person.getName());
                    root.person.getAccount().setBalance(temp.person.getAccount().getBalance());
                    root.person.getAccount().setTotalEarned(temp.person.getAccount().getTotalEarned());
                    root.person.getAccount().setWithdrawn(temp.person.getAccount().getWithdrawn());
                    root.right = destroy(ref root.right, temp.person.getAgencyId());
                }
            }
            if (root == null)
                return root;
            balance(ref root);

            return root;
        }


        public Node minValue(Node Nptr)
        {
	        while (Nptr.left!=null)
		        Nptr=Nptr.left;
	        return Nptr;
        }
    }

    public void print(Node r)
    {
        if (r != null)
        {
            print(r.left);

            TableRow tRow = new TableRow();
            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            TableCell cell4 = new TableCell();
            TableCell cell5 = new TableCell();


            cell1.Text = Convert.ToString(r.person.agencyId);
            cell2.Text = r.person.name;
            cell3.Text = r.person.stateId;
            cell4.Text = Convert.ToString(r.person.account.currentBalance);
            cell5.Text = Convert.ToString(r.person.account.totalEarned);
            tRow.Cells.Add(cell1);
            tRow.Cells.Add(cell2);
            tRow.Cells.Add(cell3);
            tRow.Cells.Add(cell4);
            tRow.Cells.Add(cell5);
            Table2.Rows.Add(tRow);

            print(r.right);
        }
    }

    int flag1 = 0; //if flag1 == 1, we want to execute the post back
    static AVLTree tree = new AVLTree();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //cases: Insert, Search, Delete, and List
        if (flag1 == 1)
        {
            if (ActionDropDown.SelectedItem.Text == "Insert")
            {
                //All of the TextBoxes should be visible and enabled
                Table2.Visible = false;
                Table1.Visible = true;
                Name.Visible = true;
                StateID.Visible = true;
                CurrBalance.Visible = true;
                TotalEarned.Visible = true;
                CellName.Visible = true;
                CellStateID.Visible = true;
                CellCurrBalance.Visible = true;
                CellTotalEarned.Visible = true;
                AgencyID.Text = null;
                Name.Text = null;
                StateID.Text = null;
                CurrBalance.Text = null;
                TotalEarned.Text = null;
            }

            else if (ActionDropDown.SelectedItem.Text == "Search" || ActionDropDown.SelectedItem.Text == "Delete" || ActionDropDown.SelectedItem.Text == "Update")
            {
                //Only searching by agency ID, therefore other textboxes will not be visible
                Table2.Visible = false;
                Table1.Visible = true;
                Name.Visible = false;
                StateID.Visible = false;
                CurrBalance.Visible = false;
                TotalEarned.Visible = false;
                CellName.Visible = false;
                CellStateID.Visible = false;
                CellCurrBalance.Visible = false;
                CellTotalEarned.Visible = false;
                AgencyID.Text = null;
            }

            else
            {
                Table1.Visible = false;
            }
            flag1 = 0;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int flag = 0; // if the flag becomes 1, then there is an input error
        int agencyID = 0;
        double balance = 0, total = 0;

        switch (ActionDropDown.SelectedItem.Text)
        {
            case ("Insert"):
                {
                    Table2.Visible = false;
                    flag = 0;
                    //Insert this entry into the table
                    try
                    {
                        agencyID = int.Parse(AgencyID.Text);
                    }
                    catch
                    {
                        AgencyID.Text = "Must be an integer";
                        flag = 1;
                    }
                    try
                    {
                        balance = Double.Parse(CurrBalance.Text);
                    }
                    catch
                    {
                        CurrBalance.Text = "Must be a numerical value";
                        flag = 1;
                    }
                    try
                    {
                        total = Double.Parse(TotalEarned.Text);
                    }
                    catch
                    {
                        TotalEarned.Text = "Must be a numerical value";
                        flag = 1;
                    }

                    string inputName = Name.Text;
                    string stateID = StateID.Text;

                    if (inputName == "")
                        Name.Text = "Please enter a name";

                    if (stateID == "")
                        StateID.Text = "Please enter the state ID";

                    if (flag == 1)
                        return;

                    BankAccount b = new BankAccount(balance, total, 0);
                    Person p = new Person(b, inputName, stateID, agencyID);
                    tree.treeRoot = tree.insert(ref tree.treeRoot, p);

                    break;
                }
            case ("Search"):
                {
                    Table2.Visible = false;
                    flag = 0;

                    //Search for this entry and display the results, giving the user the option to edit the fields
                    try
                    {
                        agencyID = int.Parse(AgencyID.Text);
                    }
                    catch
                    {
                        AgencyID.Text = "Must be an integer";
                        flag = 1;
                    }

                    if (flag == 1)
                        return;

                    //display the fields of the searched person
                    Name.Visible = true;
                    StateID.Visible = true;
                    CurrBalance.Visible = true;
                    TotalEarned.Visible = true;
                    CellName.Visible = true;
                    CellStateID.Visible = true;
                    CellCurrBalance.Visible = true;
                    CellTotalEarned.Visible = true;

                    Node result = tree.search(agencyID);
                    if (result == null)
                    {
                        AgencyID.Text = "Could not find";
                        Name.Text = "";
                        StateID.Text = "";
                        CurrBalance.Text = "";
                        TotalEarned.Text = "";
                    }
                    else
                    {
                        Name.Text = result.person.name;
                        StateID.Text = result.person.stateId;
                        CurrBalance.Text = Convert.ToString(result.person.account.currentBalance);
                        TotalEarned.Text = Convert.ToString(result.person.account.totalEarned);
                    }
                    break;
                }
            case ("Update"):
                {
                    Table2.Visible = false;
                    flag = 0;
                    try
                    {
                        agencyID = int.Parse(AgencyID.Text);
                    }
                    catch
                    {
                        AgencyID.Text = "Must be an integer";
                        flag = 1;
                    }

                    Name.Visible = true;
                    StateID.Visible = true;
                    CurrBalance.Visible = true;
                    TotalEarned.Visible = true;
                    CellName.Visible = true;
                    CellStateID.Visible = true;
                    CellCurrBalance.Visible = true;
                    CellTotalEarned.Visible = true;

                    Node result = tree.search(agencyID);
                    Name.Text = result.person.name;
                    StateID.Text = result.person.stateId;
                    result.person.account.currentBalance = double.Parse(CurrBalance.Text);
                    result.person.account.totalEarned = double.Parse(TotalEarned.Text);

                    break;
                }
            case ("Delete"):
                {
                    Table2.Visible = false;
                    flag = 0;

                    //Delete just this entry, edit the table accordingly
                    try
                    {
                        agencyID = int.Parse(AgencyID.Text);
                    }
                    catch
                    {
                        AgencyID.Text = "Must be an integer";
                        flag = 1;
                    }

                    if (flag == 1)
                        return;

                    tree.destroy(ref tree.treeRoot, agencyID);

                    break;
                }
            case ("List"):
                {
                    //List all the entries of homeless people
                    Table2.Visible = true;
                    print(tree.treeRoot);
                    break;
                }
        }
    }
    protected void ActionDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        flag1 = 1;
        Page_Load(sender, e);
    }
}