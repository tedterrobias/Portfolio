//Property loan calculator
//Ted Terrobias
//John PaulPasa

#include <iostream>
#include <fstream>
#include <iomanip>

using namespace std;

class property_loan
{
	public:
	string name, property_type;
	char property_choice, dp_choice;
	double property_price, dp_amount, int_amount, total_amount_dp;
	double dp_percentage, int_rate;
	int	num_years;
	double total_amount, monthly_ammort, yearly_ammort;
	
	
	void askValues(string &name, char &property_choice, char &dp_choice, int &num_years, double &property_price)
	{
		//name
		cout << "Enter Name: ";
		getline(cin, name);
		
		//property type
		cout << "Choose property type: \n[A] House and Lot \n[B] Condominium \n[C] Lot only" << endl;
		cout << "Enter the letter of your choice: ";
		cin >> property_choice;
		
		//downpayment percentage
		cout << "Enter downpayment percentage: \n[A] 20% \n[B] 30% \n[C] 40% \n[D] 50%" << endl;
		cout << "Enter the letter of your choice: ";
		cin >> dp_choice;
		//number of years
		do
		{
			cout << "Enter the number of years to pay (Maximum of 8 years): ";
			cin >> num_years;
			if(num_years > 8)
			{
				cout << "number of years cannot exceed 8 years." << endl;
			}
		}while(num_years > 8);
			
		//property price
		cout << "Enter the Price of the Property: ";
		cin >> property_price;
	}
	
	void setValues(char &property_choice, char &dp_choice, string &property_type, double &dp_percentage)
	{
		//property type
		if(property_choice =='a' || property_choice =='A')
		{
			property_type = "House and Lot";
		}
		else if(property_choice =='b' || property_choice =='B')
		{
			property_type = "Condominum";
		}
		else if(property_choice =='c' || property_choice =='C')
		{
			property_type = "Lot only";
		}
		
		//downpayment percentage
		if(dp_choice == 'a' || dp_choice =='A')
		{
			dp_percentage = 0.2;
		}
		else if(dp_choice == 'b' || dp_choice =='B')
		{
			dp_percentage = 0.3;
		}
		else if(dp_choice == 'c' || dp_choice =='C')
		{
			dp_percentage = 0.4;
		}
		else if(dp_choice == 'd' || dp_choice =='D')
		{
			dp_percentage = 0.5;
		}
		
	}
	
	void processValues(double &property_price, double &dp_percentage, double &dp_amount, int &num_years, double &monthly_ammort, double &yearly_ammort, double &int_rate, double &int_amount, double &total_amount, double &total_amount_dp)
	{	
		//interest rate
		if(dp_percentage==0.2)
		{
			int_rate = 0.10;
		}
		else if(dp_percentage==0.3)
		{
			int_rate = 0.08;
		}
		else if(dp_percentage==0.4)
		{
			int_rate = 0.06;
		}
		else if(dp_percentage==0.5)
		{
			int_rate = 0.04;
		}
		cout << "Interest rate: " << int_rate*100 << "%" << endl;
		//downpayment
		dp_amount = property_price * dp_percentage;
		//temp value
		double payable = property_price - dp_amount;
		//interest amount
		int_amount = property_price * int_rate;
		//total amount with downpayment
		total_amount_dp = int_amount + property_price;
		//total amount w/o downpayment
		total_amount = int_amount + payable;
		//yearly ammortization
		yearly_ammort = total_amount / num_years;
		//monthly ammortization
		monthly_ammort = yearly_ammort / 12;
		
		
	}
	
	void displayInputValues(string &name, string &property_type, double &property_price, double &dp_percentage, double &int_rate)
	{
		cout.setf(ios_base::fixed);
		cout << "---------------------------------" << endl;
		cout << "Information Given: " << endl;
		cout << "Name: " << name << endl;
		cout << "Property type: " << property_type << endl;
		cout << "Property price: " << setprecision(2)<<property_price << endl<< endl;
		cout << "downpayment percentage: " << setprecision(2)<<dp_percentage * 100<< "%" << endl;
		cout << "Interest rate: " << setprecision(2)<<int_rate * 100<< "%" << endl << endl;
	}
	
	void displayProcessedValues(double &dp_amount, double &int_amount, double &total_amount_dp, double &total_amount, double &yearly_ammort, double &monthly_ammort)
	{
		cout.setf(ios_base::fixed);
		cout << "Downpayment amount: " <<setprecision(2)<< dp_amount << endl;
		cout << "Interest amount: " << setprecision(2)<<int_amount << endl<< endl;
		cout << "Total amount with downpayment and interest: " << setprecision(2)<<total_amount_dp << endl;
		cout << "Total amount amount without downpayment (with interest): " <<setprecision(2)<< total_amount << endl<< endl;
		cout << "Yearly ammortization: " << setprecision(2)<<yearly_ammort << endl;
		cout << "Monthly ammortization: " <<setprecision(2)<< monthly_ammort << endl;
	}
	
};

int main(int argc, char** argv)
{
	ofstream fout;
	fout.open(argv[1], ios::app);
	
	string n, pt;
	char pc, dpc;
	double pp, dpa, inta, tadp;
	double dpp, intr;
	int	ny;
	double ta, ma, ya;
	
	property_loan client;
	
	client.askValues(n, pc, dpc, ny, pp);
	client.setValues(pc, dpc, pt, dpp);
	client.processValues(pp, dpp, dpa, ny, ma, ya, intr, inta, ta, tadp);
	client.displayInputValues(n, pt, pp, dpp, intr);
	client.displayProcessedValues(dpa, inta, tadp, ta, ya, ma);
	
	fout.setf(ios_base::fixed);
	
	if(fout.is_open())
	{
		fout << "Name: \t\t\t\t\t\t\t\t\t\t\t" << n << endl;
		fout << "Property type: \t\t\t\t\t\t\t\t\t" << pt << endl;
		fout << "Property price: \t\t\t\t\t\t\t\t" << setprecision(2)<<pp<< endl;
		fout << "downpayment percentage: \t\t\t\t\t\t" << setprecision(2)<<dpp * 100<<"%" << endl;
		fout << "Interest rate: \t\t\t\t\t\t\t\t\t" << setprecision(2)<<intr * 100 <<"%" << endl;
		fout << "Downpayment amount: \t\t\t\t\t\t\t" <<setprecision(2)<< dpa << endl;
		fout << "Interest amount: \t\t\t\t\t\t\t\t" << setprecision(2)<<inta << endl;
		fout << "Total amount with downpayment: \t\t\t\t\t" << setprecision(2)<<tadp << endl;
		fout << "Total amount amount without downpayment: \t\t" <<setprecision(2)<< ta << endl;
		fout << "Yearly ammortization: \t\t\t\t\t\t\t" << setprecision(2)<<ya << endl;
		fout << "Monthly ammortization: \t\t\t\t\t\t\t" <<setprecision(2)<< ma << endl;
		fout << "Years to be paid: \t\t\t\t\t\t\t\t" << ny << " years"<< endl;
		fout << "Months to be paid: \t\t\t\t\t\t\t\t" << ny*12 << " months" << endl;
		fout << "---------------------------------------------------------------------"<<endl;
	}
	else
	{
		cout <<"output file cannot be opened" << endl;
	}
	
return 0;
}
/*
 * interest rate formula (compound interest)
 * 
 */
