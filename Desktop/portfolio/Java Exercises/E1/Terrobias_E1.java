/*TERROBIAS, TED N.
 * ICST214	N3
 * 11.11.2015
 * BODY MASS INDEX CALCULATOR
 * 2.33 - Java How to Program
 
PROBLEM: 
2.33 (Body Mass Index Calculator) We introduced the body mass index (BMI) calculator in
Exercise 1.10. The formulas for calculating BMI are
weightInPounds × 703
BMI = ------------------------------------------------------------------------------------
heightInInches × heightInInches
or
weightInKi log rams
BMI = ---------------------------------------------------------------------------------------
heightInMeters × heightInMeters
Create a BMI calculator that reads the user’s weight in pounds and height in inches (or, if you pre-
fer, the user’s weight in kilograms and height in meters), then calculates and displays the user’s
body mass index. Also, display the following information from the Department of Health and
Human Services/National Institutes of Health so the user can evaluate his/her BMI:
BMI VALUES
Underweight:less than 18.5
Normal:		between 18.5 and 24.9
Overweight:	between 25 and 29.9
Obese:		30 or greater

ALGORITHM: 
1. intialize the variables to be used in the program.
2. ask input from the user.
3. use the input to compute for the BMi of the user.
4. output the result.
* */

import javax.swing.JOptionPane;
import java.text.DecimalFormat;

class Terrobias_E1
{
public static void main(String args [])
{
	String strWeightKg, strHeightM;
	
	double kg, m, bmi;
	
	strWeightKg = JOptionPane.showInputDialog("Weight in Kg: ");
	strHeightM = JOptionPane.showInputDialog("Height in M: ");
	
	kg = Double.parseDouble(strWeightKg);
	m = Double.parseDouble(strHeightM);
	
	bmi = kg/(m*m);
	
	DecimalFormat digits = new DecimalFormat("0.00");	
	
	JOptionPane.showMessageDialog(null, "BMI = "+digits.format(bmi)+"\n \n BMI VALUES\n UnderWeight:\t less than 18.5\n Normal:\t between 18.5 and 24.9\n Overweight:\t between 25 and 29.9\n Obese:\t 30 or greater","Result", JOptionPane.PLAIN_MESSAGE);
	
	System.exit(0);
}
}

