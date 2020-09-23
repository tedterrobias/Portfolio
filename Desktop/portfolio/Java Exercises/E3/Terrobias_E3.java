/* TERROBIAS, TED N.
 * ICST214	N3
 * 11.12.2015
 * TARGET HEART RATE CALCULATOR
 * 3.16 - Java How to Program
 
 PROBLEM:
Making a Difference
3.16 (Target-Heart-Rate Calculator) While exercising, you can use a heart-rate monitor to see
that your heart rate stays within a safe range suggested by your trainers and doctors. According to the
American Heart Association
(AHA) (www.americanheart.org/presenter.jhtml?identifier=4736),
the formula for calculating your maximum heart rate in beats per minute is 220 minus your age in
years. Your target heart rate is a range that’s 50–85% of your maximum heart rate.
 
[Note: These formulas are estimates provided by the AHA. Maximum and target heart rates may vary based on the
health, fitness and gender of the individual. Always consult a physician or qualified health care professional
before beginning or modifying an exercise program.] 

Create a class called HeartRates. The class attributes should include the person’s first name, 
last name and date of birth (consisting of separate attributes for the month, day and year of birth).
Your class should have a constructor that receives this data as parameters. For each attribute provide set 
and get methods. The class also should include a method that calculates and returns the person’s 
age (in years), a method that calculates and returns the person’s maximum heart rate and a method
that calculates and returns the person’s target heart rate. Write a Java application that prompts 
for the person’s information, instantiates an object of class HeartRates and prints the information 
from that object—including the person’s first name, last name and date of birth—then calculates 
and prints the person’s age in (years), maximum heart rate and target-heart-rate range.

ALGORITHM:

*/

import javax.swing.JOptionPane;
import java.text.DecimalFormat;

class Terrobias_E3
{
public static void main(String [] args)
{
	String strFirstName, strLastName, strDay, strMonth, strYear, monthName;
	int day, month, year;
	int age, maxHR;
	double minTargetHR, maxTargetHR;
	DecimalFormat dec = new DecimalFormat("0.00");
	
	//JOptionPane input
	strFirstName	= JOptionPane.showInputDialog("First name: ");
	strLastName		= JOptionPane.showInputDialog("Last name: ");
	strDay			= JOptionPane.showInputDialog("Day of birth (1-31): ");
	strMonth		= JOptionPane.showInputDialog("Month of birth (1-12): ");
	strYear			= JOptionPane.showInputDialog("Year of birth: ");
	
	day		= Integer.parseInt(strDay);
	month	= Integer.parseInt(strMonth);
	year	= Integer.parseInt(strYear);
	
	HeartRates HeartRates1 = new HeartRates(strFirstName, strLastName, month, year, day);
	
	age			= HeartRates1.calcAge(year);
	maxHR		= HeartRates1.maxHeartRate(age);
	minTargetHR	= HeartRates1.minTargetHeartRate(maxHR);
	maxTargetHR	= HeartRates1.maxTargetHeartRate(maxHR);
	
	switch(month)
	{
		case 1:
			monthName = "January";
			break;
		case 2:
			monthName = "February";
			break;
		case 3:
			monthName = "March";
			break;
		case 4:
			monthName = "April";
			break;
		case 5:
			monthName = "May";
			break;
		case 6:
			monthName = "June";
			break;
		case 7:
			monthName = "July";
			break;
		case 8:
			monthName = "August";
			break;
		case 9:
			monthName = "September";
			break;
		case 10:
			monthName = "October";
			break;
		case 11:
			monthName = "November";
			break;
		case 12:
			monthName = "December";
			break;
		default: monthName = "Unidentified";
	}
	
	JOptionPane.showMessageDialog(null, "First name: " + HeartRates1.getFirstName()
	+ "\n Last name: " + HeartRates1.getLastName() 
	+ "\n Birthdate: " + monthName + " " + HeartRates1.getDay() + ", " + HeartRates1.getYear() 
	+ "\n Age: " + age 
	+ "\n Max heart rate: " + maxHR 
	+ "\n Target heart rate range: " + dec.format(minTargetHR) + " - " + dec.format(maxTargetHR),
	"Heart Rate Calculator Results", JOptionPane.PLAIN_MESSAGE);
}
}