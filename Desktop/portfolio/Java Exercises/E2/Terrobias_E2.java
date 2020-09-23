/*TERROBIAS, TED N.
 * ICST214	N3
 * 11.12.2015
 * CALCULATING SALES
 * 5.17 - Java How to Program
 
 PROBLEM:
 5.17 (Calculating Sales) An online retailer sells five products whose retail prices are as follows:
Product 1, $2.98; product 2, $4.50; product 3, $9.98; product 4, $4.49 and product 5, $6.87.
Write an application that reads a series of pairs of numbers as follows:
a) product number
b) quantity sold
Your program should use a switch statement to determine the retail price for each product. It
should calculate and display the total retail value of all products sold. Use a sentinel-controlled
loop to determine when the program should stop looping and display the final results.

ALGORITHM:
1.	Import the necessary classes (ex javax.swing.JOptionPane)
2.	Declare the String variables to be used in JOptionPane.showInputDialog(), the double variables for product price and total price,
the int variables for product amount and product number.
3.	Use while() loop to ask input (product number and product amount) from the user through JOPtionPane.
4.	Convert the collected string data (strProdNum and strProdAmt) into its approriate data type.
5.	Assign the price for each product by using the switch() statement.
6.	Assign the formula for the total amount to be paid.
7.	Set the number of significant figures to 2 by using java.text.DecimalFormat class.
8.	Output the total amount to be paid by the user.
*/

import javax.swing.JOptionPane;
import java.text.DecimalFormat;

class Terrobias_E2
{
public static void main(String args [])
{
	int product_num, product_amount = 0;
	double product_price = 0, total = 0;
	
	String strProdNum, strProdAmt;
	
	do
	{
		strProdNum = JOptionPane.showInputDialog("PRODUCTS\n #1 = $2.98\n #2 = $4.50\n #3 = $9.98\n #4 = $4.49\n #5 = $6.87\n ENTER 6 to stop buying\n Enter product number: ");
		product_num = Integer.parseInt(strProdNum);
		if(product_num != 6)
		{
			strProdAmt = JOptionPane.showInputDialog("Enter amount of product #"+product_num+": ");
			product_amount = Integer.parseInt(strProdAmt);
		
		switch(product_num)
		{
			case 1:	product_price = 2.98;
				break;
			case 2:	product_price = 4.50;
				break;
			case 3:	product_price = 9.98;
				break;
			case 4:	product_price = 4.49;
				break;
			case 5:	product_price = 6.87;
				break;
			default: product_price = 0;
		}
		total += (product_amount * product_price);
		}
	}while(product_num != 6);
	
	DecimalFormat digits = new DecimalFormat("0.00");
	
	JOptionPane.showMessageDialog(null, "Total amount to be paid: "+digits.format(total), "Receipt", JOptionPane.PLAIN_MESSAGE);
	
	System.exit(0);
}
}