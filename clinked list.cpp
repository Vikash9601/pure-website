# pure- circular linked list
it is circular linked list by using c++ programming language


#include<iostream>
#include<conio.h>
using namespace std;

struct node
{
int data;
node *next;


};

class clist
{
  node *last;
  public:
  clist()
  {

  last=NULL;
  }

  void append(int value)
  {
     node *temp=new node;
     temp->data=value;
     if(last==NULL)
     {
        last=temp;
        temp->next=last;

     }
     else
     {
        temp->next=last->next;
        last->next=temp;
        last=temp;


     }


  }
  void display()
  {
    node *temp=new node;
    temp=last->next;
    do
    {
       cout<<temp->data;
       temp=temp->next;

    }
    while(temp!=last->next);
    }


    void insatstart(int value)
    {
        node *temp=new node;
        temp->data=value;
        temp->next=last->next;
        last->next=temp;


    }
    void insatlast(int value)
    {
        node *temp=new node;
        temp->data=value;

       temp->next=last->next;
       last->next=temp;
       last=temp;


    }
    void insatpos(int pos,int value)
    {
        node *cur=new node;
        node *prev=new node;
        node *temp=new node;
        temp->data=value;
        cur=last->next;
        for(int i=1;i<pos;i++)
        {
             prev=cur;
             cur=cur->next;

        }
        prev->next=temp;
        temp->next=cur;





    }
    void delatstart()
    {
       node *cur=new node;
       cur=last->next;
       last->next=cur->next;
       delete cur;




    }
    void delatlast()
    {
        node *cur=new node;
        node *pre=new node;
        cur=last->next;
        while(cur!=last)
        {
            pre=cur;
            cur=cur->next;

        }
        pre->next=cur->next;
        last=pre;
        delete cur;


    }

    void delatpos(int pos)
    {
         node *cur=new node;
         node *prev=new node;
         cur=last->next;
         for(int i=1;i<pos;i++)
         {

             prev=cur;
             cur=cur->next;

         }
         prev->next=cur->next;
    }

    void search(int value)
    {
        node *temp=new node;
        int pos=1;
        temp=last->next;
        do
        {



            if(value==temp->data)
            {
                cout<<value<<" is available at "<<pos;
                break;
            }

            else
            {
                temp=temp->next;
                pos++;

            }
        }
           while(temp!=last->next);






    }
    void sort()
    {
       node *cur=new node;
       node *pre=new node;
       int temp;
       cur=last->next;
        pre=cur;
        for(pre;pre!=last;pre=pre->next)
        {
            for(cur=pre->next;cur!=last->next;cur=cur->next)
            {
                if(pre->data > cur->data)
                {
                    temp=pre->data;
                    pre->data=cur->data;
                    cur->data=temp;
                }

            }

        }




    }

    void update(int old,int newv)
    {

        node *temp=new node;
        int pos=0;
        temp=last->next;
      do
        {
            if(temp->data==old)
            {

                temp->data=newv;
            }

            temp=temp->next;

            pos++;

        }
  while(temp!=last->next);
       cout<<"\n value is updated at position : "<<pos;

    }
};

int main()
{
clist v;
int a,b,c,d,e,f,g,h,i,j;
cout<<"\n 1>insert";
cout<<"\n 2>display";
cout<<"\n 3>insert at start";
cout<<"\n 4>insert at last";
cout<<"\n 5>insert at any position";
cout<<"\n 6>delete at start";
cout<<"\n 7>delete at last";
cout<<"\n 8>delete at any position";
cout<<"\n 9>search";
cout<<"\n 10>sort";
cout<<"\n 11>update";
cout<<"\n 12>exit";
do
{
  cout<<"\n enter the option: ";
  cin>>a;
  switch(a)
  {
   case 1:cout<<"\n enter the value: ";
     cin>>b;
        v.append(b);
     break;
     case 2:v.display();
     break;
     case 3:cout<<"\n enter the value: ";
      cin>>c;
      v.insatstart(c);
      break;
      case 4:cout<<"\n enter the value: ";
      cin>>d;
      v.insatlast(d);
      break;
      case 5:cout<<"\n enter the position where you want to enter: ";
         cin>>e;
         cout<<"\n enter the value: ";
         cin>>f;
        v.insatpos(e,f);
        break;
    case 6:v.delatstart();
    break;
    case 7:v.delatlast();
    break;
    case 8:cout<<"\n enter the position where you want to delete: ";
       cin>>g;
        v.delatpos(g);
    break;
    case 9:cout<<"\n enter the value which you want to search: ";
       cin>>h;
       v.search(h);
       break;
       case 10:v.sort();
       break;
       case 11: cout<<"\n enter the old value where you want to perform  updation: ";
         cin>>i;
         cout<<"\n enter the new value: ";
         cin>>j;

        v.update(i,j);
        break;
     case 12:cout<<"\n exit";
     break;
     default:cout<<"\n entered wrong option";



  }
  }
  while(a!=12);
  return 0;



}
