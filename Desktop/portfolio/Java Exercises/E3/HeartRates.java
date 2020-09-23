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


public class HeartRates
{
String firstName, lastName;
int month, day, year;

public HeartRates(String fname, String lname, int mm, int yy, int dd)
{
	firstName = fname;
	lastName = lname;
	month = mm;
	day = dd;
	year = yy;
}
public void setFirstName(String fname)
{
	firstName = fname;
}

public String getFirstName()
{
	return firstName;
}

public void setLastName(String lname)
{
	lastName = lname;
}

public String getLastName()
{
	return lastName;
}

public void setDay(int dd)
{
	day = dd;
}

public int getDay()
{
	return day;
}
public void setMonth(int mm)
{
	month = mm;
}

public int getMonth()
{
	return month;
}
public void setYear(int yy)
{
	year = yy;
}

public int getYear()
{
	return year;
}

public int calcAge(int year)
{
	int current_year = 2015;
	int age = current_year - year;
	return age;
}

public int maxHeartRate(int age)
{
	int maxHR = 220 - age;
	return maxHR;
}

public double minTargetHeartRate(int maxHR)
{
	double minTargetHR = maxHR * 0.5;
	return minTargetHR;
}

public double maxTargetHeartRate(int maxHR)
{
	double maxTargetHR = maxHR * 0.85;
	return maxTargetHR;
}
}