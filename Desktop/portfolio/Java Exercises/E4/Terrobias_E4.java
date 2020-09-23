/*
TERROBIAS, TED N.
ICST214	N3
11.24.2014
Total Sales
7.20 - Java How to Program

PROBLEM:
(Total Sales) Use a two-dimensional array to solve the following problem: A company has
four salespeople (1 to 4) who sell five different products (1 to 5). Once a day, each salesperson passes
in a slip for each type of product sold. Each slip contains the following:
a) The salesperson number
b) The product number
c) The total dollar value of that product sold that day
Thus, each salesperson passes in between 0 and 5 sales slips per day. Assume that the information
from all the slips for last month is available.Write an application that will read all this information for
last month’s sales and summarize the total sales by salesperson and by product. All totals should be
stored in the two-dimensional array sales. After processing all the information for last month, display
the results in tabular format, with each column representing a salesperson and each row representing 
a particular product. Cross-total each row to get the total sales of each product for last month.
Cross-total each column to get the total sales by salesperson for last month. Your output should
include these cross-totals to the right of the totaled rows and to the bottom of the totaled columns.

ALGORITHM:
1. Import all necessary packages to be used in the java application.
2. Declare class Terrobias_E4 and the static method main.
3. Declare twoDimArray as your two dimensional array to be used in the program.
4. Declare other variables for the salesperson, product, total sales by product, total sales by salesperson.
5. Use input as the new Scanner(System.in) to be used to reading data from the user;
6. Use a nested loop to ask the total sales of product sold by the sales person for the month from the user and store it in the
two-dimensional array twoDimArray[][];
7. Compute the total_sales_product by adding all of the salespersons' sales of a specific product, compute for the total_sales_sp
by adding all the products sold by a specific salesperson.
8. Store total sales by product in the array total_sales_product and store total sales by salesperson in the array total_sales_sp.
9. Create a series of for loops that will form the table that will display all of the data gathered from the user and the total_sales_product
and the total_sales_sp.
*/

import java.util.Scanner;
import java.text.DecimalFormat;

class Terrobias_E4
{
public static void main(String [] args)
{
	double [][] twoDimArray = new double [5][4];

	DecimalFormat dec = new DecimalFormat("0.00"); //dec.format()
	
	int sp,prod,counter=0;
	double total_sales_product[] = {0,0,0,0,0};
	double total_sales_sp []= {0,0,0,0};
	
	Scanner input = new Scanner(System.in);

	for(prod = 0; prod < 5; prod++)	
	{
		for(sp = 0; sp < 4; sp++)
		{
			System.out.print("Enter total sales of product #"+ (prod+1)+" sold by salesperson #"+ (sp+1) +" for the last month: ");
			
			twoDimArray[prod][sp] = input.nextDouble();
		}
		System.out.println();
	}

	// solve totals here
	//solve totals by products
	for(int a = 0; a < 5; a++)
	{
		for(int b = 0; b < 4; b++)
		{
			total_sales_product[a] += twoDimArray[a][b];
		}
	}
	//solve totals by salesperson
	for(int a = 0; a < 4; a++)
	{
		for(int b = 0; b < 5; b++)
		{
			total_sales_sp[a] += twoDimArray[b][a];
		}
	}
	counter = 0;
	System.out.println();
	System.out.println();

	//display table
	System.out.print("\t");
	for(sp = 0; sp < 4; sp++)
	{
		System.out.print("\t"+"Salesperson #"+(sp+1));
	}
	
	System.out.print("\tTOTALS: ");
	
	counter = 0;
	System.out.println();
	
	for(prod = 0; prod < 5; prod++)
	{
		System.out.print("product #"+(prod+1));
		for(int a = 0; a < 4; a++)
		{
			System.out.print("\t$"+dec.format(twoDimArray[counter][a])+"\t");
		}
		//display totals by product here
		System.out.print("\t$"+dec.format(total_sales_product[prod])+"\t");
		counter++;
		System.out.println();
	}
	
	System.out.print("TOTALS: ");
	//display totals by salesperson here
	for(int a = 0; a < 4; a++)
	{
		System.out.print("\t$"+dec.format(total_sales_sp[a]));
	}
	System.out.println();
	
	System.exit(0);
}
}
